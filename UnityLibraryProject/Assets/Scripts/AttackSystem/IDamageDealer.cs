namespace AttackSystem
{
    /// <summary>
    /// Interface of a GameObject that can deal damages
    /// </summary>
    public interface IDamageDealer 
    {
        /// <summary>
        /// The damages of the IDamageDealer
        /// </summary>
        public int Damages { get; }
    }
}