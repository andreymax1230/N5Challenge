using N5.Kafka.Eda.Interfaces;

namespace N5.Kafka.Eda.Configuration
{
    public class KafkaConfig : IKafkaConfig
    {
        /// <summary>
        /// Hosts to connect kafka intermediary
        /// </summary>
        public string StrapServers { get; set; } = string.Empty;

        /// <summary>
        /// Group Consumer to Kafka(Collections Instances)
        /// </summary>
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// Message Max Bytes to kafka
        /// </summary>
        public int MessageMaxBytes { get; set; } = 0;
    }
}
