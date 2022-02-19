// GENERATED AUTOMATICALLY FROM 'Assets/1-Scripts/Player/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""e45e4c5e-b573-408e-aa53-5c64a4e1ad5a"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""PassThrough"",
                    ""id"": ""38073cc8-3d60-447d-8c0d-b2ae129dda06"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""56472616-b798-4775-981d-c54bea590936"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""298a3f9f-edf2-449e-beba-c29fe0e08496"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Screenshot"",
                    ""type"": ""Button"",
                    ""id"": ""f54300ad-c945-4dbd-8714-14d09b5485ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0c958753-469b-4fbe-b085-740659493a59"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5b4752a2-f856-4763-ac8f-bbc033d601c9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseDrag"",
                    ""type"": ""Value"",
                    ""id"": ""8b1f3dd9-32f0-4a49-baa2-ae0b1dab35c2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""b0af2e05-b23f-4e9d-9a24-20e7541741a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""adce43c7-dd2d-4f17-89b3-c9ab5de16c59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Report"",
                    ""type"": ""Button"",
                    ""id"": ""578bb725-9d58-4c8f-a323-f1ddc00fce1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""ffd61359-cbbe-4ff3-a25f-88fb12d0fd02"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0ed04baa-8952-4933-b628-62f6e79ba24d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""33bab3fa-c03f-4cb1-9d6e-6443e414c372"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""55133baa-0ef6-423e-91c9-05f05be70f84"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c5707350-aa2f-40af-9713-6d2c668b7ed8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cd114520-86ba-4b43-b173-86966a2bf3d6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f54e858-b802-4cd4-9d52-c264bb08fae7"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b242192-aecb-4c00-8aa7-4993ba475a7c"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1090a01-eb20-4f30-aded-d57a6355e226"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f264fb90-b7c0-415e-9e0c-dc78d43072af"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8810b176-68ec-461a-9b1f-ebf5c6718481"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""847f3406-4c91-4e25-8fd8-54d4a25ddcf0"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfdb4bae-b61a-4a3b-8c10-6047cb46545d"",
                    ""path"": ""<Keyboard>/#(R)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Report"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96e80e98-03f6-41ea-bee4-f240c0a93b7b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Screenshot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8ba35b7-4dd1-44a1-8c56-104d793df9b9"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inventory"",
            ""id"": ""e8064da3-ee60-422d-8864-b54ac574e8fb"",
            ""actions"": [
                {
                    ""name"": ""OpenDisable"",
                    ""type"": ""Button"",
                    ""id"": ""14fe0f04-2796-4c41-aaf4-376cfd34d368"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5054870d-33d1-42f2-8f5c-16c1ea671bed"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenDisable"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pause"",
            ""id"": ""8c42c946-a562-42fa-af34-a1d73c412c2d"",
            ""actions"": [
                {
                    ""name"": ""Execute"",
                    ""type"": ""Button"",
                    ""id"": ""fb0c9174-0605-4977-bc82-ae65b0f5c52a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a1fd35a0-6c84-4d69-a2ef-42d745af81b0"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Execute"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3099019-8699-417e-a769-586eb0866fb2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Execute"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movement
        m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
        m_PlayerMovement_Walk = m_PlayerMovement.FindAction("Walk", throwIfNotFound: true);
        m_PlayerMovement_Crouch = m_PlayerMovement.FindAction("Crouch", throwIfNotFound: true);
        m_PlayerMovement_Jump = m_PlayerMovement.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovement_Screenshot = m_PlayerMovement.FindAction("Screenshot", throwIfNotFound: true);
        m_PlayerMovement_MouseX = m_PlayerMovement.FindAction("MouseX", throwIfNotFound: true);
        m_PlayerMovement_MouseY = m_PlayerMovement.FindAction("MouseY", throwIfNotFound: true);
        m_PlayerMovement_MouseDrag = m_PlayerMovement.FindAction("MouseDrag", throwIfNotFound: true);
        m_PlayerMovement_LeftClick = m_PlayerMovement.FindAction("LeftClick", throwIfNotFound: true);
        m_PlayerMovement_RightClick = m_PlayerMovement.FindAction("RightClick", throwIfNotFound: true);
        m_PlayerMovement_Report = m_PlayerMovement.FindAction("Report", throwIfNotFound: true);
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_OpenDisable = m_Inventory.FindAction("OpenDisable", throwIfNotFound: true);
        // Pause
        m_Pause = asset.FindActionMap("Pause", throwIfNotFound: true);
        m_Pause_Execute = m_Pause.FindAction("Execute", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player Movement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Walk;
    private readonly InputAction m_PlayerMovement_Crouch;
    private readonly InputAction m_PlayerMovement_Jump;
    private readonly InputAction m_PlayerMovement_Screenshot;
    private readonly InputAction m_PlayerMovement_MouseX;
    private readonly InputAction m_PlayerMovement_MouseY;
    private readonly InputAction m_PlayerMovement_MouseDrag;
    private readonly InputAction m_PlayerMovement_LeftClick;
    private readonly InputAction m_PlayerMovement_RightClick;
    private readonly InputAction m_PlayerMovement_Report;
    public struct PlayerMovementActions
    {
        private @PlayerController m_Wrapper;
        public PlayerMovementActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_PlayerMovement_Walk;
        public InputAction @Crouch => m_Wrapper.m_PlayerMovement_Crouch;
        public InputAction @Jump => m_Wrapper.m_PlayerMovement_Jump;
        public InputAction @Screenshot => m_Wrapper.m_PlayerMovement_Screenshot;
        public InputAction @MouseX => m_Wrapper.m_PlayerMovement_MouseX;
        public InputAction @MouseY => m_Wrapper.m_PlayerMovement_MouseY;
        public InputAction @MouseDrag => m_Wrapper.m_PlayerMovement_MouseDrag;
        public InputAction @LeftClick => m_Wrapper.m_PlayerMovement_LeftClick;
        public InputAction @RightClick => m_Wrapper.m_PlayerMovement_RightClick;
        public InputAction @Report => m_Wrapper.m_PlayerMovement_Report;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnWalk;
                @Crouch.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouch;
                @Jump.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Screenshot.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnScreenshot;
                @Screenshot.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnScreenshot;
                @Screenshot.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnScreenshot;
                @MouseX.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMouseX;
                @MouseX.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMouseX;
                @MouseX.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMouseX;
                @MouseY.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMouseY;
                @MouseY.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMouseY;
                @MouseY.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMouseY;
                @MouseDrag.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMouseDrag;
                @MouseDrag.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMouseDrag;
                @MouseDrag.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMouseDrag;
                @LeftClick.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLeftClick;
                @RightClick.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRightClick;
                @Report.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnReport;
                @Report.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnReport;
                @Report.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnReport;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Screenshot.started += instance.OnScreenshot;
                @Screenshot.performed += instance.OnScreenshot;
                @Screenshot.canceled += instance.OnScreenshot;
                @MouseX.started += instance.OnMouseX;
                @MouseX.performed += instance.OnMouseX;
                @MouseX.canceled += instance.OnMouseX;
                @MouseY.started += instance.OnMouseY;
                @MouseY.performed += instance.OnMouseY;
                @MouseY.canceled += instance.OnMouseY;
                @MouseDrag.started += instance.OnMouseDrag;
                @MouseDrag.performed += instance.OnMouseDrag;
                @MouseDrag.canceled += instance.OnMouseDrag;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @Report.started += instance.OnReport;
                @Report.performed += instance.OnReport;
                @Report.canceled += instance.OnReport;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Inventory
    private readonly InputActionMap m_Inventory;
    private IInventoryActions m_InventoryActionsCallbackInterface;
    private readonly InputAction m_Inventory_OpenDisable;
    public struct InventoryActions
    {
        private @PlayerController m_Wrapper;
        public InventoryActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @OpenDisable => m_Wrapper.m_Inventory_OpenDisable;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void SetCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
            {
                @OpenDisable.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnOpenDisable;
                @OpenDisable.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnOpenDisable;
                @OpenDisable.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnOpenDisable;
            }
            m_Wrapper.m_InventoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OpenDisable.started += instance.OnOpenDisable;
                @OpenDisable.performed += instance.OnOpenDisable;
                @OpenDisable.canceled += instance.OnOpenDisable;
            }
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);

    // Pause
    private readonly InputActionMap m_Pause;
    private IPauseActions m_PauseActionsCallbackInterface;
    private readonly InputAction m_Pause_Execute;
    public struct PauseActions
    {
        private @PlayerController m_Wrapper;
        public PauseActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Execute => m_Wrapper.m_Pause_Execute;
        public InputActionMap Get() { return m_Wrapper.m_Pause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActions set) { return set.Get(); }
        public void SetCallbacks(IPauseActions instance)
        {
            if (m_Wrapper.m_PauseActionsCallbackInterface != null)
            {
                @Execute.started -= m_Wrapper.m_PauseActionsCallbackInterface.OnExecute;
                @Execute.performed -= m_Wrapper.m_PauseActionsCallbackInterface.OnExecute;
                @Execute.canceled -= m_Wrapper.m_PauseActionsCallbackInterface.OnExecute;
            }
            m_Wrapper.m_PauseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Execute.started += instance.OnExecute;
                @Execute.performed += instance.OnExecute;
                @Execute.canceled += instance.OnExecute;
            }
        }
    }
    public PauseActions @Pause => new PauseActions(this);
    public interface IPlayerMovementActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnScreenshot(InputAction.CallbackContext context);
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
        void OnMouseDrag(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnReport(InputAction.CallbackContext context);
    }
    public interface IInventoryActions
    {
        void OnOpenDisable(InputAction.CallbackContext context);
    }
    public interface IPauseActions
    {
        void OnExecute(InputAction.CallbackContext context);
    }
}
