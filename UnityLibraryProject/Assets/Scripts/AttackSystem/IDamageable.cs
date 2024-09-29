using System;

namespace AttackSystem
{
    /// <summary>
    /// Interface to put on everything that can be hit/damaged
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// The maximum health of the IDamageable
        /// </summary>
        public int MaxHealth { get; }

        /// <summary>
        /// The current health of the IDamageable
        /// </summary>
        public int CurrHealth { get; }

        /// <summary>
        /// Makes the IDamageable inheritor take damages
        /// </summary>
        /// <param name="dealer">The IDamageDealer that just damaged the IDamageable</param>
        /// <returns>True if the IDamageabled dies, else False</returns>
        public bool TakeDamage(IDamageDealer dealer);

        /// <summary>
        /// Checks if the IDamageable inheritor is resistant to the IDamageDealer
        /// </summary>
        /// <param name="dealer">The IDamageDealer</param>
        /// <returns>True if it's reistant to the dealer, else False</returns>
        public bool IsResistantTo(IDamageDealer dealer);

        /// <summary>
        /// Event launched when the IDamageable changes HP
        /// </summary>
        public event Action<int> OnHealthChange;

        /// <summary>
        /// Subscribes to the OnHealthChange event
        /// </summary>
        /// <param name="onHealthChange">The function to subscribe</param>
        public void SubscribeToOnHealthChange(Action<int> onHealthChange);

        /// <summary>
        /// Unsubscribes from the OnHealthChange event
        /// </summary>
        /// <param name="onHealthChange">The function to unsubscribe</param>
        public void UnsubscribeToOnHealthChange(Action<int> onHealthChange);

        /// <summary>
        /// Event launch when the IDamageable dies
        /// </summary>
        public event Action OnDeath;

        /// <summary>
        /// Subscribes to the OnDeath event
        /// </summary>
        /// <param name="onDeath">The function to subscribe</param>
        public void SubscribeToOnDeath(Action onDeath);

        /// <summary>
        /// Unsubscribes from the OnDeath event
        /// </summary>
        /// <param name="onDeath">The function to unsubscribe</param>
        public void UnsubscribeToOnDeath(Action onDeath);
    }
}