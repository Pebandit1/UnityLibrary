using System;
namespace DetectionSystem
{
    /// <summary>
    /// Interface to put on a GameObject that can be detected and disabled
    /// </summary>
    public interface IDetectableDisable : IDetectable
    {
        /// <summary>
        /// Event lance quand l'IDetectableDisable est disable
        /// </summary>
        event Action<IDetectableDisable> OnDisabled;
    }
}