namespace Scripts.EntityComponents.AttackControllers
{
    /// <summary>
    /// Base interface for class controlling weapons
    /// </summary>
    public interface IAttackController
    {
        /// <summary>
        /// Checks if attack controller can attack
        /// </summary>
        bool CanAttack { get; }
        /// <summary>
        /// Attack using weapons
        /// </summary>
        void Attack();
    }
}