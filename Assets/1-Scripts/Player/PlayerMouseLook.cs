using UnityEngine;

/* 
 * Responsible for looking around with the mouse
 */ 

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class PlayerMouseLook : MonoBehaviour {
        [SerializeField] private Transform playerCamera; // main camera of scene
        [SerializeField] private float cameraVerticalClamp = 85f; // limits maximum vertical rotation of camera
        private float verticalRotation; // stores camera rotation

        [SerializeField] private float sensitivityX = 8f; // mouse sensitivity on x and y axis
        [SerializeField] private float sensitivityY = 8f;
        private float mouseX, mouseY; // stores mouse movement
        
        private void Start() {
            // hide and lock cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update() {
            // rotate player body horizontally
            transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

            // rotate main camera vertically
            verticalRotation -= mouseY * Time.deltaTime;
            verticalRotation = Mathf.Clamp(verticalRotation, -cameraVerticalClamp, cameraVerticalClamp);

            Vector3 targetRotation = transform.eulerAngles;
            targetRotation.x = verticalRotation;
            playerCamera.eulerAngles = targetRotation;
        }

        // get mouse input
        public void ReceiveInput(Vector2 mouseInput) {
            if (!PlayerLock.instance.IsLocked) {
                mouseX = mouseInput.x *sensitivityX;
                mouseY = mouseInput.y *sensitivityY;
            }
            else {
                mouseX = 0f;
                mouseY = 0f;
            }
        }
    }
}