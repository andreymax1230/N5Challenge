namespace N5.Kafka.Eda.Attribute;

/// <summary>
/// Unit attribuite for topic events kafka
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class KafkaTopicAttribute : System.Attribute
{
    /// <summary>
    /// Name event topic
    /// </summary>
    public string Topic { get; private set; }

    /// <summary>
    /// Constructor base Kafka topic
    /// </summary>
    /// <param name="topic">Name event to subcribed</param>
    public KafkaTopicAttribute(string topic)
    {
        Topic = topic;
    }
}
