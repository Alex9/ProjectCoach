namespace Xemio.ProjectCoach.Entities.Projects
{
    public enum PhaseState
    {
        /// <summary>
        /// The phase is planned.
        /// </summary>
        IsPlanned,
        /// <summary>
        /// The phase is in progress.
        /// </summary>
        InProgress,
        /// <summary>
        /// The phase is finished.
        /// </summary>
        IsDone,
        /// <summary>
        /// The phase is in testing environment.
        /// </summary>
        InTesting
    }
}