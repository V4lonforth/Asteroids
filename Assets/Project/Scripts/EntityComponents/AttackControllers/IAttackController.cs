namespace Scripts.EntityComponents.AttackControllers
{
    public interface IAttackController
    {
        bool CanAttack { get; }
        void Attack();
    }
}