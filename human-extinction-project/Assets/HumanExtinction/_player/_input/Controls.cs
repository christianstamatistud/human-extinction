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
                    ""name"": ""RunPressed"",
                    ""type"": ""Button"",
                    ""id"": ""b767d4e7-acfe-4dfa-b86e-7c1319d85ee8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RunReleased"",
                    ""type"": ""Button"",
                    ""id"": ""eeb3f5f5-7a90-48e3-bb58-ab81b8b102fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
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
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""6c0f8608-9643-43ae-aa8a-7b8bfc5a6c2b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ToggleInventory"",
                    ""type"": ""Button"",
                    ""id"": ""87f24e3b-a488-4e76-96ff-0b715c585e01"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
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
                    ""name"": ""Joystick"",
                    ""id"": ""e725cfee-8bb6-421a-b7c9-fa482c7c857b"",
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
                    ""id"": ""9067e20f-ea38-4459-bb49-45d26f6cdbbe"",
                    ""path"": ""<DualShockGamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9add1f3d-9e48-447f-bb38-7a699c3fee2c"",
                    ""path"": ""<DualShockGamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e19dcb3e-9b19-493e-9f66-269c57b033d3"",
                    ""path"": ""<DualShockGamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8fb862ec-5e6c-4d13-82f2-3eb27c5f2c62"",
                    ""path"": ""<DualShockGamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""e204e7d8-7cd2-4638-bcb0-f8ad394ed69c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""642565f7-9889-4e48-8962-8ea665b8a002"",
                    ""path"": ""<DualShockGamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""81b122d0-35a3-4597-8618-a752ed09a2a6"",
                    ""path"": ""<DualShockGamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""96ee5ab5-e63a-4ce9-8965-52a71527297b"",
                    ""path"": ""<DualShockGamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""88987ccb-acfb-42ee-8afa-5064b8d11921"",
                    ""path"": ""<DualShockGamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
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
                    ""name"": ""2D Vector"",
                    ""id"": ""0afd0683-2945-4099-9c4e-3d2f27227670"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6d6ae62e-8072-4228-9dee-cbee403a7eba"",
                    ""path"": ""<DualShockGamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1ac0c588-85d0-405e-b918-556d983f02b6"",
                    ""path"": ""<DualShockGamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""abdf5dd0-5b9b-433a-b017-ed17d6b144cd"",
                    ""path"": ""<DualShockGamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0904de4e-0e8a-4cf3-80cd-dea3c792aa83"",
                    ""path"": ""<DualShockGamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6f765627-c790-47ec-9368-7e5df6ecd3a0"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""RunPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74ffe199-fecb-437e-a171-897214edc0f1"",
                    ""path"": ""<DualShockGamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""RunPressed"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""6736746e-982e-475f-ad41-464e0256613b"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ec71603-2f9b-4bbd-9316-5365fbdfea4b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1035764e-6023-4184-9163-45b4d61b78ca"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9f31255-984d-436b-9e18-3812205d6439"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""ToggleInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f774ca1d-bd11-425a-bdc5-42e9ef1e0781"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""ToggleInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adaa3214-df4c-4859-9a2d-d2701a6ab66d"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""RunReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9ab3805-b707-4037-8251-7fca36144919"",
                    ""path"": ""<DualShockGamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""RunReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerMaze"",
            ""id"": ""fa91c1c9-c0a6-4698-ba83-ce4fa4a37c7b"",
            ""actions"": [
                {
                    ""name"": ""OnUpAction"",
                    ""type"": ""Button"",
                    ""id"": ""fc60b9eb-e7fa-4f7c-92dc-cd439b88a43a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""OnDownAction"",
                    ""type"": ""Button"",
                    ""id"": ""96d9cd2b-7e4e-411b-bb11-4cf471d58ce8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""OnRightAction"",
                    ""type"": ""Button"",
                    ""id"": ""e36ca0fd-c4a9-42be-93f6-7a7aa9851b24"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""OnLeftAction"",
                    ""type"": ""Button"",
                    ""id"": ""58a50e86-7a6b-4e24-b46d-a67bf907f4e7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""OnQuitInteraction"",
                    ""type"": ""Button"",
                    ""id"": ""fe047e05-31c7-4ec7-b2c7-ab82e4b0b036"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9f69a789-52ff-486c-8c0f-46e84c3c4a80"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""OnUpAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd0aeae1-2ffc-46b5-aeb0-8868071b37ec"",
                    ""path"": ""<DualShockGamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""OnUpAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1645112-3051-4718-b74b-3220fd0ae72d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""OnDownAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0acee80d-56d2-47f9-8738-c8071b2349e7"",
                    ""path"": ""<DualShockGamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""OnDownAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d40be7b-9a17-4720-8a38-c79d705455c5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""OnRightAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fa00053-174a-44c3-add7-ca30f625df89"",
                    ""path"": ""<DualShockGamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""OnRightAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""305c5c19-8613-47e7-9d16-d927023a91b4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""OnLeftAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8486b58-db66-467a-9f58-001e52ef6fd0"",
                    ""path"": ""<DualShockGamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""OnLeftAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5d50dbb-a0f2-4771-8f19-3e73746b46df"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""OnQuitInteraction"",
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
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": []
        }
    ]
}");
            // PlayerControls
            m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
            m_PlayerControls_RunPressed = m_PlayerControls.FindAction("RunPressed", throwIfNotFound: true);
            m_PlayerControls_RunReleased = m_PlayerControls.FindAction("RunReleased", throwIfNotFound: true);
            m_PlayerControls_Esc = m_PlayerControls.FindAction("Esc", throwIfNotFound: true);
            m_PlayerControls_Movement = m_PlayerControls.FindAction("Movement", throwIfNotFound: true);
            m_PlayerControls_Mouse = m_PlayerControls.FindAction("Mouse", throwIfNotFound: true);
            m_PlayerControls_Interact = m_PlayerControls.FindAction("Interact", throwIfNotFound: true);
            m_PlayerControls_ToggleInventory = m_PlayerControls.FindAction("ToggleInventory", throwIfNotFound: true);
            // PlayerMaze
            m_PlayerMaze = asset.FindActionMap("PlayerMaze", throwIfNotFound: true);
            m_PlayerMaze_OnUpAction = m_PlayerMaze.FindAction("OnUpAction", throwIfNotFound: true);
            m_PlayerMaze_OnDownAction = m_PlayerMaze.FindAction("OnDownAction", throwIfNotFound: true);
            m_PlayerMaze_OnRightAction = m_PlayerMaze.FindAction("OnRightAction", throwIfNotFound: true);
            m_PlayerMaze_OnLeftAction = m_PlayerMaze.FindAction("OnLeftAction", throwIfNotFound: true);
            m_PlayerMaze_OnQuitInteraction = m_PlayerMaze.FindAction("OnQuitInteraction", throwIfNotFound: true);
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
        private readonly InputAction m_PlayerControls_RunPressed;
        private readonly InputAction m_PlayerControls_RunReleased;
        private readonly InputAction m_PlayerControls_Esc;
        private readonly InputAction m_PlayerControls_Movement;
        private readonly InputAction m_PlayerControls_Mouse;
        private readonly InputAction m_PlayerControls_Interact;
        private readonly InputAction m_PlayerControls_ToggleInventory;
        public struct PlayerControlsActions
        {
            private @Controls m_Wrapper;
            public PlayerControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @RunPressed => m_Wrapper.m_PlayerControls_RunPressed;
            public InputAction @RunReleased => m_Wrapper.m_PlayerControls_RunReleased;
            public InputAction @Esc => m_Wrapper.m_PlayerControls_Esc;
            public InputAction @Movement => m_Wrapper.m_PlayerControls_Movement;
            public InputAction @Mouse => m_Wrapper.m_PlayerControls_Mouse;
            public InputAction @Interact => m_Wrapper.m_PlayerControls_Interact;
            public InputAction @ToggleInventory => m_Wrapper.m_PlayerControls_ToggleInventory;
            public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerControlsActions instance)
            {
                if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
                {
                    @RunPressed.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRunPressed;
                    @RunPressed.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRunPressed;
                    @RunPressed.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRunPressed;
                    @RunReleased.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRunReleased;
                    @RunReleased.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRunReleased;
                    @RunReleased.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRunReleased;
                    @Esc.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnEsc;
                    @Esc.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnEsc;
                    @Esc.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnEsc;
                    @Movement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                    @Mouse.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouse;
                    @Mouse.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouse;
                    @Mouse.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouse;
                    @Interact.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnInteract;
                    @ToggleInventory.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnToggleInventory;
                    @ToggleInventory.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnToggleInventory;
                    @ToggleInventory.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnToggleInventory;
                }
                m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @RunPressed.started += instance.OnRunPressed;
                    @RunPressed.performed += instance.OnRunPressed;
                    @RunPressed.canceled += instance.OnRunPressed;
                    @RunReleased.started += instance.OnRunReleased;
                    @RunReleased.performed += instance.OnRunReleased;
                    @RunReleased.canceled += instance.OnRunReleased;
                    @Esc.started += instance.OnEsc;
                    @Esc.performed += instance.OnEsc;
                    @Esc.canceled += instance.OnEsc;
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Mouse.started += instance.OnMouse;
                    @Mouse.performed += instance.OnMouse;
                    @Mouse.canceled += instance.OnMouse;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @ToggleInventory.started += instance.OnToggleInventory;
                    @ToggleInventory.performed += instance.OnToggleInventory;
                    @ToggleInventory.canceled += instance.OnToggleInventory;
                }
            }
        }
        public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

        // PlayerMaze
        private readonly InputActionMap m_PlayerMaze;
        private IPlayerMazeActions m_PlayerMazeActionsCallbackInterface;
        private readonly InputAction m_PlayerMaze_OnUpAction;
        private readonly InputAction m_PlayerMaze_OnDownAction;
        private readonly InputAction m_PlayerMaze_OnRightAction;
        private readonly InputAction m_PlayerMaze_OnLeftAction;
        private readonly InputAction m_PlayerMaze_OnQuitInteraction;
        public struct PlayerMazeActions
        {
            private @Controls m_Wrapper;
            public PlayerMazeActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @OnUpAction => m_Wrapper.m_PlayerMaze_OnUpAction;
            public InputAction @OnDownAction => m_Wrapper.m_PlayerMaze_OnDownAction;
            public InputAction @OnRightAction => m_Wrapper.m_PlayerMaze_OnRightAction;
            public InputAction @OnLeftAction => m_Wrapper.m_PlayerMaze_OnLeftAction;
            public InputAction @OnQuitInteraction => m_Wrapper.m_PlayerMaze_OnQuitInteraction;
            public InputActionMap Get() { return m_Wrapper.m_PlayerMaze; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerMazeActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerMazeActions instance)
            {
                if (m_Wrapper.m_PlayerMazeActionsCallbackInterface != null)
                {
                    @OnUpAction.started -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnUpAction;
                    @OnUpAction.performed -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnUpAction;
                    @OnUpAction.canceled -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnUpAction;
                    @OnDownAction.started -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnDownAction;
                    @OnDownAction.performed -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnDownAction;
                    @OnDownAction.canceled -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnDownAction;
                    @OnRightAction.started -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnRightAction;
                    @OnRightAction.performed -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnRightAction;
                    @OnRightAction.canceled -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnRightAction;
                    @OnLeftAction.started -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnLeftAction;
                    @OnLeftAction.performed -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnLeftAction;
                    @OnLeftAction.canceled -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnLeftAction;
                    @OnQuitInteraction.started -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnQuitInteraction;
                    @OnQuitInteraction.performed -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnQuitInteraction;
                    @OnQuitInteraction.canceled -= m_Wrapper.m_PlayerMazeActionsCallbackInterface.OnOnQuitInteraction;
                }
                m_Wrapper.m_PlayerMazeActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @OnUpAction.started += instance.OnOnUpAction;
                    @OnUpAction.performed += instance.OnOnUpAction;
                    @OnUpAction.canceled += instance.OnOnUpAction;
                    @OnDownAction.started += instance.OnOnDownAction;
                    @OnDownAction.performed += instance.OnOnDownAction;
                    @OnDownAction.canceled += instance.OnOnDownAction;
                    @OnRightAction.started += instance.OnOnRightAction;
                    @OnRightAction.performed += instance.OnOnRightAction;
                    @OnRightAction.canceled += instance.OnOnRightAction;
                    @OnLeftAction.started += instance.OnOnLeftAction;
                    @OnLeftAction.performed += instance.OnOnLeftAction;
                    @OnLeftAction.canceled += instance.OnOnLeftAction;
                    @OnQuitInteraction.started += instance.OnOnQuitInteraction;
                    @OnQuitInteraction.performed += instance.OnOnQuitInteraction;
                    @OnQuitInteraction.canceled += instance.OnOnQuitInteraction;
                }
            }
        }
        public PlayerMazeActions @PlayerMaze => new PlayerMazeActions(this);
        private int m_KeyboardandMouseSchemeIndex = -1;
        public InputControlScheme KeyboardandMouseScheme
        {
            get
            {
                if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
                return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
            }
        }
        private int m_JoystickSchemeIndex = -1;
        public InputControlScheme JoystickScheme
        {
            get
            {
                if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
                return asset.controlSchemes[m_JoystickSchemeIndex];
            }
        }
        public interface IPlayerControlsActions
        {
            void OnRunPressed(InputAction.CallbackContext context);
            void OnRunReleased(InputAction.CallbackContext context);
            void OnEsc(InputAction.CallbackContext context);
            void OnMovement(InputAction.CallbackContext context);
            void OnMouse(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnToggleInventory(InputAction.CallbackContext context);
        }
        public interface IPlayerMazeActions
        {
            void OnOnUpAction(InputAction.CallbackContext context);
            void OnOnDownAction(InputAction.CallbackContext context);
            void OnOnRightAction(InputAction.CallbackContext context);
            void OnOnLeftAction(InputAction.CallbackContext context);
            void OnOnQuitInteraction(InputAction.CallbackContext context);
        }
    }
}
