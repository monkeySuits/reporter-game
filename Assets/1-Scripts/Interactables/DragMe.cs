using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Put in a game object with rigidbody to drag it around
 */ 

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class DragMe : MonoBehaviour, IMouse {
        [SerializeField] private Rigidbody rb; // reference to rigidbody
        private Vector3 mouseOffset; // offset between game object and mouse world position
        private float mouseZCoordinate; // mouse z coordinate based on distance from game object

        // IMouse implementations
        public void OnMouseDown(InputAction.CallbackContext context) {
            rb.isKinematic = true;
            mouseZCoordinate = Camera.main.WorldToScreenPoint(transform.position).z;
            mouseOffset = transform.position - GetMouseWorldPosition();
        }

        public void OnMouseDrag(InputAction.CallbackContext context) {
            rb.MovePosition(GetMouseWorldPosition() + mouseOffset);
        }

        public void OnMouseUp(InputAction.CallbackContext context) {
            rb.isKinematic = false;
        }

        // get mouse world position
        private Vector3 GetMouseWorldPosition() {
            // get mouse screen space point
            Vector3 mousePoint = Mouse.current.position.ReadValue();

            // get z coordinate from game object
            mousePoint.z = mouseZCoordinate;

            // return world position
            return Camera.main.ScreenToWorldPoint(mousePoint);
        }
    }
}