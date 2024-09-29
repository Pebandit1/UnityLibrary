namespace DetectionSystem
{
    /// <summary>
    /// An interface containing the required information to keep track of a IDetectable GameObject
    /// </summary>
    public interface IDetectableElement
    {
        /// <summary>
        /// The object that was detected as a IDetectable
        /// </summary>
        public IDetectable Detectable { get; }
    }
}