namespace Scripts.EntityComponents.LifeCycleControllers
{
    /// <summary>
    /// Class that completely destroys game object
    /// </summary>
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