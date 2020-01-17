// GENERATED AUTOMATICALLY FROM 'Assets/HumanExtinction/_player/_input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace CS
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        private InputActionAsset asset;
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""34b439f2-37aa-4b81-b27c-32ab1955d99c"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""fe3463b2-786f-461b-8429-ce6c7ac6d3a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""b767d4e7-acfe-4dfa-b86e-7c1319d85ee8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""52d08b4d-e427-4a2d-849b-049c1bb2746b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Esc"",
                    ""type"": ""Button"",
                    ""id"": ""826d9387-62ef-4667-baa9-b1333ea0f0c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""b7a7a081-22dc-4f75-ab62-63a39265b18c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""75b5c03b-ec52-4532-b288-56f55d45c4ae"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5d41bb27-77c9-470b-a6c5-18d67405cadf"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""034d6e88-6550-4bc4-aea4-000d204acd8e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f33e30e6-a599-4dd7-8dd7-15b1a5e9a5fb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fa8b0402-1f4f-47e0-b638-cd4e818dbbec"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ef746be3-7feb-4344-a7db-254dbe86f240"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e5c2aa92-09e0-4b52-9ef9-626e173d09c3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""ddb7d17f-05eb-4ce2-83cd-4f64111bf2e8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5fbd8383-f92e-461e-a655-50bc8f2c2d02"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1711f534-a575-48e5-b9d7-c67cae447b2e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3e35e98b-1c0b-4e65-88ca-cb694b619ae3"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7b6cc6c3-b405-40d9-99f2-bfe5fb733a5d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3eda089e-78a6-4a16-a3e9-81c65370d1de"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f765627-c790-47ec-9368-7e5df6ecd3a0"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c12c846-a3f5-49f9-bdce-07659028101f"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abd745cd-f6eb-4646-a1f8-5ab419aa014a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": []
        }
    ]
}");
            // PlayerControls
            m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
            m_PlayerControls_Jump = m_PlayerControls.FindAction("Jump", throwIfNotFound: true);
            m_PlayerControls_Run = m_PlayerControls.FindAction("Run", throwIfNotFound: true);
            m_PlayerControls_Crouch = m_PlayerControls.FindAction("Crouch", throwIfNotFound: true);
            m_PlayerControls_Esc = m_PlayerControls.FindAction("Esc", throwIfNotFound: true);
            m_PlayerControls_Movement = m_PlayerControls.FindAction("Movement", throwIfNotFound: true);
            m_PlayerControls_Mouse = m_PlayerControls.FindAction("Mouse", throwIfNotFound: true);
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

        // PlayerControls
        private readonly InputActionMap m_PlayerControls;
        private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
        private readonly InputAction m_PlayerControls_Jump;
        private readonly InputAction m_PlayerControls_Run;
        private readonly InputAction m_PlayerControls_Crouch;
        private readonly InputAction m_PlayerControls_Esc;
        private readonly InputAction m_PlayerControls_Movement;
        private readonly InputAction m_PlayerControls_Mouse;
        public struct PlayerControlsActions
        {
            private @Controls m_Wrapper;
            public PlayerControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Jump => m_Wrapper.m_PlayerControls_Jump;
            public InputAction @Run => m_Wrapper.m_PlayerControls_Run;
            public InputAction @Crouch => m_Wrapper.m_PlayerControls_Crouch;
            public InputAction @Esc => m_Wrapper.m_PlayerControls_Esc;
            public InputAction @Movement => m_Wrapper.m_PlayerControls_Movement;
            public InputAction @Mouse => m_Wrapper.m_PlayerControls_Mouse;
            public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerControlsActions instance)
            {
                if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
                {
                    @Jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                    @Run.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRun;
                    @Run.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRun;
                    @Run.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRun;
                    @Crouch.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCrouch;
                    @Crouch.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCrouch;
                    @Crouch.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCrouch;
                    @Esc.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnEsc;
                    @Esc.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnEsc;
                    @Esc.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnEsc;
                    @Movement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                    @Mouse.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouse;
                    @Mouse.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouse;
                    @Mouse.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouse;
                }
                m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Run.started += instance.OnRun;
                    @Run.performed += instance.OnRun;
                    @Run.canceled += instance.OnRun;
                    @Crouch.started += instance.OnCrouch;
                    @Crouch.performed += instance.OnCrouch;
                    @Crouch.canceled += instance.OnCrouch;
                    @Esc.started += instance.OnEsc;
                    @Esc.performed += instance.OnEsc;
                    @Esc.canceled += instance.OnEsc;
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Mouse.started += instance.OnMouse;
                    @Mouse.performed += instance.OnMouse;
                    @Mouse.canceled += instance.OnMouse;
                }
            }
        }
        public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
        private int m_KeyboardandMouseSchemeIndex = -1;
        public InputControlScheme KeyboardandMouseScheme
        {
            get
            {
                if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
                return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
            }
        }
        public interface IPlayerControlsActions
        {
            void OnJump(InputAction.CallbackContext context);
            void OnRun(InputAction.CallbackContext context);
            void OnCrouch(InputAction.CallbackContext context);
            void OnEsc(InputAction.CallbackContext context);
            void OnMovement(InputAction.CallbackContext context);
            void OnMouse(InputAction.CallbackContext context);
        }
    }
}
