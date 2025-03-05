namespace N5.Events;

/// <summary>
/// List Events Topic for Kafka
/// </summary>
public static class UserEvent
{
    /// <summary>
    /// Generate User Permission Event
    /// </summary>
    public const string GeneratePermission = "User.Permission.Generate";

    /// <summary>
    /// Update User Permission Event
    /// </summary>
    public const string UpdatePermission = "User.Permission.Update";

    /// <summary>
    /// Get List User Permisssion Event
    /// </summary>
    public const string GetPermission = "User.Permission.Get";

    /// <summary>
    /// Success respinse event
    /// </summary>
    public const string GenerateGenericSucessEvent = "User.Permission.Generate.Generic.Success.Event";
}