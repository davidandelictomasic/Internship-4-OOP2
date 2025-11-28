using System.Text.Json.Serialization;

namespace UserManagement.Domain.Enumumerations.Validation
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ValidationSeverity
    {
        Error,
        Warning,
        Info


    }
}
