﻿using Confluent.Kafka;

namespace N5.Kafka.Eda.Model
{
    public class KafkaMessage 
    {
        public string Value { get; set; }
        public string Topic { get; set; }

        public KafkaMessage(ConsumeResult<Ignore, string> message)
        {
            Value = message.Message.Value;
            Topic = message.Topic;
        }
    }
}
