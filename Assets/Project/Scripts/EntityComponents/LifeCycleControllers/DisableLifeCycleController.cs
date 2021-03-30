namespace Scripts.EntityComponents.LifeCycleControllers
{
    /// <summary>
    /// Class that disables game object
    /// </summary>
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