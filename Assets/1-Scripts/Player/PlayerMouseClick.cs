using UnityEngine;
using UnityEngine.InputSystem;
using MoreMountains.Feedbacks;
using FlatKit;
/*
 * Responsible for mouse interactions with multiple game objects
 */

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class PlayerMouseClick : MonoBehaviour, IMouse {
        [SerializeField] private float maxClickDistance; // distance to be used when raycasting clicks
        [SerializeField] private float doubleClickThreshold; // speed between clicks to trigger a double click

        private Mouse mouse; // reference to current mouse
        private InputAction mouseDrag; // reference to drag action from new Input System
        private IMouse currentDragger; // current object to be dragged
        private float clickCount; // current clicks executed
        private float clickTimer; // time between clicks
        public MMFeedbacks findInteractableReticleFeed;
        public MMFeedbacks loseInteractableReticleFeed;
        bool reticleActive = false;

        // mouse clic setup
        public void Initialize(InputAction drag) {
            mouse = Mouse.current;
            mouseDrag = drag;
        }
        private void Update() {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hit, maxClickDistance)) {
                IMouse dragger = hit.collider.gameObject.GetComponent<IMouse>();
                if (dragger != null) {
                    Debug.Log("Looking at Interactable");
                    if(reticleActive == false){
                        findInteractableReticleFeed.PlayFeedbacks();
                        reticleActive = true;
                    }
                }
            }
            else{
                if(reticleActive == true){
                    loseInteractableReticleFeed.PlayFeedbacks();
                    reticleActive = false;
                }
            }
        }
        // left click events
        public void OnLeftClickStarted(InputAction.CallbackContext context) {
            mouse = Mouse.current;
            RaycastHit hit;

            // reset click if not fast enough
            if (Time.time > clickTimer) {
                clickCount = 0;
                clickTimer = Time.time + doubleClickThreshold;
            }

            clickCount++;
            switch (clickCount) {
                case 1:
                    // single click
                    currentDragger = this;

                    // try to get dragger object on screen
                    if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hit, maxClickDistance)) {
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

                case 2:
                    // double click
                    if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hit, maxClickDistance)) {
                        // if hit object can be double clicked
                        IDoubleClick doubleClick = hit.collider.gameObject.GetComponent<IDoubleClick>();
                        doubleClick?.OnDoubleClick();
                    }

                    // reset click
                    clickCount = 0;

                    break;
            }
        }

        public void OnLeftClickCanceled(InputAction.CallbackContext context) {
            // deactivate dragger object functions
            mouseDrag.performed -= currentDragger.OnMouseDrag;
            currentDragger.OnMouseUp(context);
        }

        // unused methods
        public void OnRightClickStarted(InputAction.CallbackContext context) { }
        public void OnRightClickCanceled(InputAction.CallbackContext context) { }

        // IMouse implementation is not used on this script, but avoids error when clicking in no object
        public void OnMouseDown(InputAction.CallbackContext context) { }
        public void OnMouseDrag(InputAction.CallbackContext context) { }
        public void OnMouseUp(InputAction.CallbackContext context) { }
    }
}