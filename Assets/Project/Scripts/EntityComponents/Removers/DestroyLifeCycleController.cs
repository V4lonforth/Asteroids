namespace Scripts.EntityComponents.Removers
{
    public class DestroyLifeCycleController : LifeCycleController
    {
        protected override void HandleSpawn()
        {
            gameObject.SetActive(true);
        }

        protected override void HandleDestroy()
        {
            Destroy(gameObject);
        }
    }
}