using Reporter;
using UnityEngine;

/*
 * Controls all inputs from game
 */

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class InputManager : MonoBehaviour {
        [SerializeField] private PlayerMovement movement; // reference to player movement script
        [SerializeField] private PlayerMouseLook mouseLook; // reference to mouse look script
        [SerializeField] private PlayerMouseClick mouseClick; // reference to mouse click script
         [SerializeField] private PlayerLock lockScript; // reference to player lock script
        [SerializeField] private PlayerReport report;

        private PlayerController controller; // reference to Input System class
        private PlayerController.PlayerMovementActions playerMovement; // reference to Input System group of inputs
        private PlayerController.InventoryActions playerInventory; 
        private PlayerController.PauseActions playerPause;
        private Vector2 horizontalInput; // stores horizontal movement
        private Vector2 mouseInput; // stores mouse movement
        private bool inventory;
        private bool pause;

        // input manager setup
        private void Awake() {
            controller = new PlayerController();
            playerMovement = controller.PlayerMovement;
            playerInventory = controller.Inventory;
            playerPause = controller.Pause;

            // horizontal input
            playerMovement.Walk.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

            // crouch input
            playerMovement.Crouch.performed += _ => movement.OnCrouchPressed();

            // jump input
            playerMovement.Jump.performed += _ => movement.OnJumpPressed();

            // screenshot input
            playerMovement.Screenshot.performed += _ => PlayerCamera.instance.ActivateCamera();
            playerMovement.RightClick.started += _ => PlayerCamera.instance.AimCamera();
            playerMovement.RightClick.canceled += _ => PlayerCamera.instance.StopCamera();

            // mouse input
            playerMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
            playerMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

            // mouse click input
            playerMovement.LeftClick.started += mouseClick.OnLeftClickStarted;
            playerMovement.LeftClick.canceled += mouseClick.OnLeftClickCanceled;
            // playerMovement.RightClick.started += mouseClick.OnRightClickStarted;
            // playerMovement.RightClick.canceled += mouseClick.OnRightClickCanceled;
            mouseClick.Initialize(playerMovement.MouseDrag);

            // restart input
            playerMovement.Report.performed += _ => report.Report();

            //playerMovement.Inventory.started += _ => CreateInventory.instance.OpenClose();
            playerInventory.OpenDisable.started += _ => Inventory();

            playerPause.Execute.started += _ => Pause();
        }

        // send inputs to movement scripts
        private void Update() {
            movement.ReceiveInput(horizontalInput);
            mouseLook.ReceiveInput(mouseInput);
        }

        // you must always enable and disable the new input system
        private void OnEnable() {
            controller.Enable();
        }

        private void OnDisable() {
            controller.Disable();
        }

        private void Inventory(){
            CreateInventory.instance.OpenClose();
            inventory = !inventory;
            lockScript.LockPlayer(inventory);
            Debug.Log("Inventario: " + inventory);
            Movement();
        }

        private void Pause(){
            PauseController.instance.PanelController();
            pause = !pause;
            lockScript.LockPlayer(pause);
        }

        private void Movement(){
                controller.PlayerMovement.Enable();
        }
    }
}