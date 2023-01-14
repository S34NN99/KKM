// GENERATED AUTOMATICALLY FROM 'Assets/Input/MyGameActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MyGameActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyGameActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyGameActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""53991ebf-f491-4f4c-a798-8df3da30cb64"",
            ""actions"": [
                {
                    ""name"": ""PlateMovement"",
                    ""type"": ""Value"",
                    ""id"": ""4a778566-6739-4bb0-b456-39515e1a897d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Plate DoubleTap W"",
                    ""type"": ""Button"",
                    ""id"": ""a0550b63-59d0-4af0-a6d2-90653ca79d73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Plate DoubleTap S"",
                    ""type"": ""Button"",
                    ""id"": ""a2c89333-6f99-4980-bb0a-73b52028a120"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Plate W"",
                    ""type"": ""Button"",
                    ""id"": ""29247036-4fab-4651-8f75-3e7ff0c993c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Plate S"",
                    ""type"": ""Button"",
                    ""id"": ""221dc6f5-07d6-45b3-bd55-ac189b64a0ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""e71e2278-6561-4f4d-98a8-035e8f223bc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6a2d5424-195d-4215-8085-c7c1bb18f640"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""MultiTap"",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Plate DoubleTap W"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbd55443-e54a-4cf0-882e-e432a1c3e4f8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""MultiTap"",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Plate DoubleTap S"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cbaee9c-cff5-440e-9756-bc416934988f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Plate W"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3f34ed3-9538-497d-99bf-8c0999761193"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Plate S"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f0e3dea7-c652-44b9-af88-3d107c600089"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlateMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0fc14d7b-d96b-4ba8-9994-a3036a23ba10"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""PlateMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3072e713-4891-4861-988f-491aa0ab676e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""PlateMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3339c506-9b99-475f-89dc-af30b5f0f98f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_PlateMovement = m_Player.FindAction("PlateMovement", throwIfNotFound: true);
        m_Player_PlateDoubleTapW = m_Player.FindAction("Plate DoubleTap W", throwIfNotFound: true);
        m_Player_PlateDoubleTapS = m_Player.FindAction("Plate DoubleTap S", throwIfNotFound: true);
        m_Player_PlateW = m_Player.FindAction("Plate W", throwIfNotFound: true);
        m_Player_PlateS = m_Player.FindAction("Plate S", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_PlateMovement;
    private readonly InputAction m_Player_PlateDoubleTapW;
    private readonly InputAction m_Player_PlateDoubleTapS;
    private readonly InputAction m_Player_PlateW;
    private readonly InputAction m_Player_PlateS;
    private readonly InputAction m_Player_Pause;
    public struct PlayerActions
    {
        private @MyGameActions m_Wrapper;
        public PlayerActions(@MyGameActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlateMovement => m_Wrapper.m_Player_PlateMovement;
        public InputAction @PlateDoubleTapW => m_Wrapper.m_Player_PlateDoubleTapW;
        public InputAction @PlateDoubleTapS => m_Wrapper.m_Player_PlateDoubleTapS;
        public InputAction @PlateW => m_Wrapper.m_Player_PlateW;
        public InputAction @PlateS => m_Wrapper.m_Player_PlateS;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @PlateMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateMovement;
                @PlateMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateMovement;
                @PlateMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateMovement;
                @PlateDoubleTapW.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateDoubleTapW;
                @PlateDoubleTapW.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateDoubleTapW;
                @PlateDoubleTapW.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateDoubleTapW;
                @PlateDoubleTapS.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateDoubleTapS;
                @PlateDoubleTapS.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateDoubleTapS;
                @PlateDoubleTapS.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateDoubleTapS;
                @PlateW.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateW;
                @PlateW.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateW;
                @PlateW.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateW;
                @PlateS.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateS;
                @PlateS.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateS;
                @PlateS.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlateS;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlateMovement.started += instance.OnPlateMovement;
                @PlateMovement.performed += instance.OnPlateMovement;
                @PlateMovement.canceled += instance.OnPlateMovement;
                @PlateDoubleTapW.started += instance.OnPlateDoubleTapW;
                @PlateDoubleTapW.performed += instance.OnPlateDoubleTapW;
                @PlateDoubleTapW.canceled += instance.OnPlateDoubleTapW;
                @PlateDoubleTapS.started += instance.OnPlateDoubleTapS;
                @PlateDoubleTapS.performed += instance.OnPlateDoubleTapS;
                @PlateDoubleTapS.canceled += instance.OnPlateDoubleTapS;
                @PlateW.started += instance.OnPlateW;
                @PlateW.performed += instance.OnPlateW;
                @PlateW.canceled += instance.OnPlateW;
                @PlateS.started += instance.OnPlateS;
                @PlateS.performed += instance.OnPlateS;
                @PlateS.canceled += instance.OnPlateS;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
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
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnPlateMovement(InputAction.CallbackContext context);
        void OnPlateDoubleTapW(InputAction.CallbackContext context);
        void OnPlateDoubleTapS(InputAction.CallbackContext context);
        void OnPlateW(InputAction.CallbackContext context);
        void OnPlateS(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
