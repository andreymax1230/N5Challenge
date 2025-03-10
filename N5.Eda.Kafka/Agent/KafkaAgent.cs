﻿using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.Extensions.DependencyInjection;
using N5.Kafka.Eda.Interface;
using N5.Kafka.Eda.Interfaces;
using N5.Kafka.Eda.Model;

namespace N5.Kafka.Eda.Agent;

public class KafkaAgent(IAdminClient _adminClient,
                        IConsumer<Ignore, string> _consumer,
                        IKafkaHandlerList _kafkaHandlerList,
                        IServiceProvider _serviceProvider) : IKafkaAgent
{

    /// <summary>
    /// Generate topic in Kafka Broker
    /// </summary>
    /// <returns></returns>
    private async Task GenerateTopic(string topic)
    {
        _ = Task.Factory.StartNew(() =>
        {
            try
            {
                _adminClient.GetMetadata(topic, new TimeSpan(0, 1, 0));
            }
            catch (CreateTopicsException e)
            {
                Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
            }
        });
    }

    /// <summary>
    /// Suscribe topic to broker, execute handler intance for interface implement IKafkaEvent, to integrator library 
    /// </summary>
    /// <returns>Task action</returns>
    public async Task Subscribe()
    {
        _ = Task.Factory.StartNew(() =>
        {
            string[] topics = _kafkaHandlerList.GetEvents().Select(x => x.Key).ToArray();
            topics.ToList().ForEach(topic =>
            {
                GenerateTopic(topic);
            });

            bool cancelled = false;
            CancellationToken cancellationToken = new();
            //List suscribe topics events, these events for consumer
            _consumer.Subscribe(topics);

            Console.WriteLine("Suscribed List Topics: \n" + string.Join("\n", topics));

            try
            {
                while (!cancelled)
                {
                    //Lister consumer Kafka, return topic for generate query get assemblye instance of type (IKafkaEvent)
                    var consumeResult = _consumer.Consume(cancellationToken);
                    var listEventIntegrator = _kafkaHandlerList.GetEvents().Where(x => x.Key == consumeResult.Topic).SelectMany(x => x.Value);
                    foreach (var itemEvent in listEventIntegrator)
                    {
                        var scope = _serviceProvider.CreateScope();
                        var instance = scope.ServiceProvider.GetService(itemEvent) as IKafkaEvent;
                        ArgumentNullException.ThrowIfNull(instance);
                        instance.Handler(new KafkaMessage(consumeResult), cancellationToken);
                        _consumer.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Kafka: {ex.Message}");
            }
            finally
            {
                _consumer.Close();
            }
        });
    }
}