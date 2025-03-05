namespace N5.Kafka.Eda.Interfaces;

public interface IKafkaAgent
{
    /// <summary>
    /// Suscribe topic to broker, execute handler intance for interface implement IKafkaEvent, to integrator library 
    /// </summary>
    /// <returns>Task action</returns>
    Task Subscribe();
}
