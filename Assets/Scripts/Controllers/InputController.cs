using GeekBrains;
using UnityEngine;

namespace Geekbrains
{
    public sealed class InputController : BaseController, IExecute
    {
        private KeyCode _activeFlashLight = KeyCode.F;
        
        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Execute()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                ServiceLocator.Resolve<FlashLightController>().Switch();
            }
        }
    }
}
