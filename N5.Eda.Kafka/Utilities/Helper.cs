
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace N5.Kafka.Eda.Utilities;

public static class Helper
{
    /// <summary>
    /// Serialize json.
    /// </summary>
    /// <param name="Value"></param>
    /// <returns></returns>
    public static string ToSerializeJSON(this object Value)
    {
        return JsonConvert.SerializeObject(Value, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        });
    }

    /// <summary>
    /// Deserialize json.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Value"></param>
    /// <returns></returns>
    public static T? ToDeserializeJSON<T>(this string Value)
        => JsonConvert.DeserializeObject<T>(Value, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        });

    /// <summary>
    /// Deserialize json.
    /// </summary>
    /// <param name="Value"></param>
    /// <param name="TypeDeserialize"></param>
    /// <returns></returns>
    public static object? ToDeserializeJSON(this string Value, Type TypeDeserialize)
        => JsonConvert.DeserializeObject(Value, TypeDeserialize, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        });
}
