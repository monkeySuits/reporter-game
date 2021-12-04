using UnityEngine.InputSystem;

/*
 * Mouse functions to be implemented on interactable objects
 */ 

namespace devlog98.Backdoor {
    public interface IMouse {
        void OnMouseDown(InputAction.CallbackContext context);
        void OnMouseDrag(InputAction.CallbackContext context);
        void OnMouseUp(InputAction.CallbackContext context);
    }
}