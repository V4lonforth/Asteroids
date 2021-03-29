namespace Scripts.EntityComponents.Removers
{
    public class DestroyRemover : Remover
    {
        protected override void HandleRemove()
        {
            Destroy(gameObject);
        }
    }
}