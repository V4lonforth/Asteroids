namespace Scripts.EntityComponents.Removers
{
    public class DisableLifeCycleController : LifeCycleController
    {
        protected override void HandleSpawn()
        {
            gameObject.SetActive(true);
        }
        
        protected override void HandleDestroy()
        {
            gameObject.SetActive(false);
        }
    }
}