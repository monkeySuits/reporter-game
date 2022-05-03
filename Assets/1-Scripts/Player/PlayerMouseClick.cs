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
        public float outlineHighlightScale = 0.5f;
        public float normalOutline = 0f;
        Transform previousHit;

        // mouse clic setup
        public void Initialize(InputAction drag) {
            mouse = Mouse.current;
            mouseDrag = drag;
        }
        private async void Update() {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hit, maxClickDistance)) {
                IMouse dragger = hit.collider.gameObject.GetComponent<IMouse>();
                if (dragger != null) {
                    previousHit = hit.collider.transform.GetChild(1);


                    if(reticleActive == false){
                        findInteractableReticleFeed.PlayFeedbacks();
                        // hit.collider.gameObject.GetComponent<Renderer>().settings.thickness = 10;
                        if(previousHit.childCount != 0){
                            for(int i = 0; i < previousHit.childCount; i++){
                                Transform curObj;
                                curObj = previousHit.GetChild(i);
                                if(curObj.GetComponent<Renderer>() != null)                        
                                    curObj.GetComponent<Renderer>().material.SetFloat(Shader.PropertyToID("_OutlineWidth"), outlineHighlightScale);
                                // Debug.Log("Get child : " + previousHit);
                            }
                        }
                        else{
                            previousHit.GetComponent<Renderer>().material.SetFloat(Shader.PropertyToID("_OutlineWidth"), outlineHighlightScale);
                        }
                        reticleActive = true;
                    }
                }
            }
            else{
                if(reticleActive == true){
                    loseInteractableReticleFeed.PlayFeedbacks();
                    reticleActive = false;
                    if(previousHit.childCount != 0){
                        for(int i = 0; i < previousHit.childCount; i++){
                            Transform curObj;
                            if(previousHit.GetChild(i) != null)
                                curObj = previousHit.GetChild(i);
                            else
                                curObj = null;    

                            if(curObj.GetComponent<Renderer>() != null)                           
                                curObj.GetComponent<Renderer>().material.SetFloat(Shader.PropertyToID("_OutlineWidth"), normalOutline);
                        }
                    }
                    else{
                        previousHit.GetComponent<Renderer>().material.SetFloat(Shader.PropertyToID("_OutlineWidth"), normalOutline);
                    }
                    // previousHit.GetComponent<Renderer>().material.SetFloat(Shader.PropertyToID("_OutlineWidth"), normalOutline);
                    previousHit = null;
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