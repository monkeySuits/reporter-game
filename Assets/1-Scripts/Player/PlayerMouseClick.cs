using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Responsible for mouse interactions with multiple game objects
 */

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class PlayerMouseClick : MonoBehaviour, IMouse {
        [SerializeField] private float maxClickDistance; // distance to be used when raycasting clicks

        private Mouse mouse; // reference to current mouse
        private InputAction mouseDrag; // reference to drag action from new Input System
        private IMouse currentDragger; // current object to be dragged

        // mouse clic setup
        public void Initialize(InputAction drag) {
            mouse = Mouse.current;
            mouseDrag = drag;
        }

        // left click events
        public void OnLeftClickStarted(InputAction.CallbackContext context) {
            RaycastHit hit;

            switch (mouse.clickCount.ReadValue()) {
                // single click
                case 1:
                    currentDragger = this;

                    // try to get dragger object on screen
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(mouse.position.ReadValue()), out hit, maxClickDistance)) {
                        // if hit object can be dragged
                        IMouse dragger = hit.collider.gameObject.GetComponent<IMouse>();
                        if (dragger != null) {
                            currentDragger = dragger;
                        }
                    }

                    // activate dragger object functions
                    currentDragger.OnMouseDown(context);
                    mouseDrag.performed += currentDragger.OnMouseDrag;

                    break;

                // double click
                case 2:
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(mouse.position.ReadValue()), out hit, maxClickDistance)) {
                        // if hit object can be double clicked
                        IDoubleClick doubleClick = hit.collider.gameObject.GetComponent<IDoubleClick>();
                        doubleClick?.OnDoubleClick();
                    }

                    break;
            }
        }

        public void OnLeftClickCanceled(InputAction.CallbackContext context) {
            // deactivate dragger object functions
            mouseDrag.performed -= currentDragger.OnMouseDrag;
            currentDragger.OnMouseUp(context);
        }

        // right click events
        public void OnRightClickStarted(InputAction.CallbackContext context) { }
        public void OnRightClickCanceled(InputAction.CallbackContext context) { }

        // IMouse implementation is not used on this script, but avoids error when clicking in no object
        public void OnMouseDown(InputAction.CallbackContext context) { }
        public void OnMouseDrag(InputAction.CallbackContext context) { }
        public void OnMouseUp(InputAction.CallbackContext context) { }
    }
}