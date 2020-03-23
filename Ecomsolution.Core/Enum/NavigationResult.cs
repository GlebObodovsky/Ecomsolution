namespace Ecomsolutions.Core.Enum
{
    /// <summary>
    /// The result of a robot navigation attempt
    /// </summary>
    public enum NavigationResult
    {
        /// <summary>
        /// The navigation succeeded
        /// </summary>
        Success,
        /// <summary>
        /// The navigation failed
        /// </summary>
        Failure,
        /// <summary>
        /// The navigation succeded but the navigating robot got lost because of it
        /// </summary>
        Lost
    }
}
