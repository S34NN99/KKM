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
                    ""name"": ""Tray A"",
                    ""type"": ""Button"",
                    ""id"": ""c98ce848-cbd9-4326-b533-378e7f9de407"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tray D"",
                    ""type"": ""Button"",
                    ""id"": ""38bd83e1-d045-4cc9-b8fa-bc340387ad7c"",
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
                    ""name"": """",
                    ""id"": ""386a38b8-3ba2-4c7f-b6ec-ace796d940e2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tray A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""812958ea-c713-4cae-b0c1-1479a3b9eade"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tray D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Tutorial1"",
            ""id"": ""fdfd9e30-7ba5-479e-b5be-eb794b9813e5"",
            ""actions"": [
                {
                    ""name"": ""Tray A"",
                    ""type"": ""Button"",
                    ""id"": ""df88e6c7-1a99-4bb4-8b1b-52cfb806330d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tray D"",
                    ""type"": ""Button"",
                    ""id"": ""42017cb5-5338-4533-a248-8f30c1178dba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""becda62f-8709-4144-a459-d733fa91fc0d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tray A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd143456-8599-41e8-8f8f-3e26433236b9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tray D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Tutorial2"",
            ""id"": ""504e3693-18e5-4b01-8c28-ae41740fefe1"",
            ""actions"": [
                {
                    ""name"": ""Plate DoubleTap W"",
                    ""type"": ""Button"",
                    ""id"": ""bf410e64-b9a9-49ae-b781-b9aaaf354bea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Plate DoubleTap S"",
                    ""type"": ""Button"",
                    ""id"": ""5218b428-a542-4c33-ae57-1b141eebcef4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Plate W"",
                    ""type"": ""Button"",
                    ""id"": ""2c0588bf-2f14-4b71-aad1-b415ed8755b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tray A"",
                    ""type"": ""Button"",
                    ""id"": ""048b4125-5883-4997-9696-cca2a13a3df3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tray D"",
                    ""type"": ""Button"",
                    ""id"": ""9481fdfc-2d53-4428-805a-98d85e7877b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b7212dd7-197a-4f6e-a69b-e06b2d6e9597"",
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
                    ""id"": ""a17d02ca-9895-442b-9a18-345233f281fd"",
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
                    ""id"": ""b030d262-b94f-49ac-bc32-737df5d541fa"",
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
                    ""id"": ""54c150c2-cba5-466a-af00-a786b30fba6a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tray A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3be0caa-2e27-4bbe-935c-171e101fea9c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tray D"",
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
        m_Player_PlateDoubleTapW = m_Player.FindAction("Plate DoubleTap W", throwIfNotFound: true);
        m_Player_PlateDoubleTapS = m_Player.FindAction("Plate DoubleTap S", throwIfNotFound: true);
        m_Player_PlateW = m_Player.FindAction("Plate W", throwIfNotFound: true);
        m_Player_PlateS = m_Player.FindAction("Plate S", throwIfNotFound: true);
        m_Player_TrayA = m_Player.FindAction("Tray A", throwIfNotFound: true);
        m_Player_TrayD = m_Player.FindAction("Tray D", throwIfNotFound: true);
        // Tutorial1
        m_Tutorial1 = asset.FindActionMap("Tutorial1", throwIfNotFound: true);
        m_Tutorial1_TrayA = m_Tutorial1.FindAction("Tray A", throwIfNotFound: true);
        m_Tutorial1_TrayD = m_Tutorial1.FindAction("Tray D", throwIfNotFound: true);
        // Tutorial2
        m_Tutorial2 = asset.FindActionMap("Tutorial2", throwIfNotFound: true);
        m_Tutorial2_PlateDoubleTapW = m_Tutorial2.FindAction("Plate DoubleTap W", throwIfNotFound: true);
        m_Tutorial2_PlateDoubleTapS = m_Tutorial2.FindAction("Plate DoubleTap S", throwIfNotFound: true);
        m_Tutorial2_PlateW = m_Tutorial2.FindAction("Plate W", throwIfNotFound: true);
        m_Tutorial2_TrayA = m_Tutorial2.FindAction("Tray A", throwIfNotFound: true);
        m_Tutorial2_TrayD = m_Tutorial2.FindAction("Tray D", throwIfNotFound: true);
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
    private readonly InputAction m_Player_PlateDoubleTapW;
    private readonly InputAction m_Player_PlateDoubleTapS;
    private readonly InputAction m_Player_PlateW;
    private readonly InputAction m_Player_PlateS;
    private readonly InputAction m_Player_TrayA;
    private readonly InputAction m_Player_TrayD;
    public struct PlayerActions
    {
        private @MyGameActions m_Wrapper;
        public PlayerActions(@MyGameActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlateDoubleTapW => m_Wrapper.m_Player_PlateDoubleTapW;
        public InputAction @PlateDoubleTapS => m_Wrapper.m_Player_PlateDoubleTapS;
        public InputAction @PlateW => m_Wrapper.m_Player_PlateW;
        public InputAction @PlateS => m_Wrapper.m_Player_PlateS;
        public InputAction @TrayA => m_Wrapper.m_Player_TrayA;
        public InputAction @TrayD => m_Wrapper.m_Player_TrayD;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
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
                @TrayA.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTrayA;
                @TrayA.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTrayA;
                @TrayA.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTrayA;
                @TrayD.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTrayD;
                @TrayD.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTrayD;
                @TrayD.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTrayD;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
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
                @TrayA.started += instance.OnTrayA;
                @TrayA.performed += instance.OnTrayA;
                @TrayA.canceled += instance.OnTrayA;
                @TrayD.started += instance.OnTrayD;
                @TrayD.performed += instance.OnTrayD;
                @TrayD.canceled += instance.OnTrayD;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Tutorial1
    private readonly InputActionMap m_Tutorial1;
    private ITutorial1Actions m_Tutorial1ActionsCallbackInterface;
    private readonly InputAction m_Tutorial1_TrayA;
    private readonly InputAction m_Tutorial1_TrayD;
    public struct Tutorial1Actions
    {
        private @MyGameActions m_Wrapper;
        public Tutorial1Actions(@MyGameActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @TrayA => m_Wrapper.m_Tutorial1_TrayA;
        public InputAction @TrayD => m_Wrapper.m_Tutorial1_TrayD;
        public InputActionMap Get() { return m_Wrapper.m_Tutorial1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Tutorial1Actions set) { return set.Get(); }
        public void SetCallbacks(ITutorial1Actions instance)
        {
            if (m_Wrapper.m_Tutorial1ActionsCallbackInterface != null)
            {
                @TrayA.started -= m_Wrapper.m_Tutorial1ActionsCallbackInterface.OnTrayA;
                @TrayA.performed -= m_Wrapper.m_Tutorial1ActionsCallbackInterface.OnTrayA;
                @TrayA.canceled -= m_Wrapper.m_Tutorial1ActionsCallbackInterface.OnTrayA;
                @TrayD.started -= m_Wrapper.m_Tutorial1ActionsCallbackInterface.OnTrayD;
                @TrayD.performed -= m_Wrapper.m_Tutorial1ActionsCallbackInterface.OnTrayD;
                @TrayD.canceled -= m_Wrapper.m_Tutorial1ActionsCallbackInterface.OnTrayD;
            }
            m_Wrapper.m_Tutorial1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TrayA.started += instance.OnTrayA;
                @TrayA.performed += instance.OnTrayA;
                @TrayA.canceled += instance.OnTrayA;
                @TrayD.started += instance.OnTrayD;
                @TrayD.performed += instance.OnTrayD;
                @TrayD.canceled += instance.OnTrayD;
            }
        }
    }
    public Tutorial1Actions @Tutorial1 => new Tutorial1Actions(this);

    // Tutorial2
    private readonly InputActionMap m_Tutorial2;
    private ITutorial2Actions m_Tutorial2ActionsCallbackInterface;
    private readonly InputAction m_Tutorial2_PlateDoubleTapW;
    private readonly InputAction m_Tutorial2_PlateDoubleTapS;
    private readonly InputAction m_Tutorial2_PlateW;
    private readonly InputAction m_Tutorial2_TrayA;
    private readonly InputAction m_Tutorial2_TrayD;
    public struct Tutorial2Actions
    {
        private @MyGameActions m_Wrapper;
        public Tutorial2Actions(@MyGameActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlateDoubleTapW => m_Wrapper.m_Tutorial2_PlateDoubleTapW;
        public InputAction @PlateDoubleTapS => m_Wrapper.m_Tutorial2_PlateDoubleTapS;
        public InputAction @PlateW => m_Wrapper.m_Tutorial2_PlateW;
        public InputAction @TrayA => m_Wrapper.m_Tutorial2_TrayA;
        public InputAction @TrayD => m_Wrapper.m_Tutorial2_TrayD;
        public InputActionMap Get() { return m_Wrapper.m_Tutorial2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Tutorial2Actions set) { return set.Get(); }
        public void SetCallbacks(ITutorial2Actions instance)
        {
            if (m_Wrapper.m_Tutorial2ActionsCallbackInterface != null)
            {
                @PlateDoubleTapW.started -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnPlateDoubleTapW;
                @PlateDoubleTapW.performed -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnPlateDoubleTapW;
                @PlateDoubleTapW.canceled -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnPlateDoubleTapW;
                @PlateDoubleTapS.started -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnPlateDoubleTapS;
                @PlateDoubleTapS.performed -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnPlateDoubleTapS;
                @PlateDoubleTapS.canceled -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnPlateDoubleTapS;
                @PlateW.started -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnPlateW;
                @PlateW.performed -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnPlateW;
                @PlateW.canceled -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnPlateW;
                @TrayA.started -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnTrayA;
                @TrayA.performed -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnTrayA;
                @TrayA.canceled -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnTrayA;
                @TrayD.started -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnTrayD;
                @TrayD.performed -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnTrayD;
                @TrayD.canceled -= m_Wrapper.m_Tutorial2ActionsCallbackInterface.OnTrayD;
            }
            m_Wrapper.m_Tutorial2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlateDoubleTapW.started += instance.OnPlateDoubleTapW;
                @PlateDoubleTapW.performed += instance.OnPlateDoubleTapW;
                @PlateDoubleTapW.canceled += instance.OnPlateDoubleTapW;
                @PlateDoubleTapS.started += instance.OnPlateDoubleTapS;
                @PlateDoubleTapS.performed += instance.OnPlateDoubleTapS;
                @PlateDoubleTapS.canceled += instance.OnPlateDoubleTapS;
                @PlateW.started += instance.OnPlateW;
                @PlateW.performed += instance.OnPlateW;
                @PlateW.canceled += instance.OnPlateW;
                @TrayA.started += instance.OnTrayA;
                @TrayA.performed += instance.OnTrayA;
                @TrayA.canceled += instance.OnTrayA;
                @TrayD.started += instance.OnTrayD;
                @TrayD.performed += instance.OnTrayD;
                @TrayD.canceled += instance.OnTrayD;
            }
        }
    }
    public Tutorial2Actions @Tutorial2 => new Tutorial2Actions(this);
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
        void OnPlateDoubleTapW(InputAction.CallbackContext context);
        void OnPlateDoubleTapS(InputAction.CallbackContext context);
        void OnPlateW(InputAction.CallbackContext context);
        void OnPlateS(InputAction.CallbackContext context);
        void OnTrayA(InputAction.CallbackContext context);
        void OnTrayD(InputAction.CallbackContext context);
    }
    public interface ITutorial1Actions
    {
        void OnTrayA(InputAction.CallbackContext context);
        void OnTrayD(InputAction.CallbackContext context);
    }
    public interface ITutorial2Actions
    {
        void OnPlateDoubleTapW(InputAction.CallbackContext context);
        void OnPlateDoubleTapS(InputAction.CallbackContext context);
        void OnPlateW(InputAction.CallbackContext context);
        void OnTrayA(InputAction.CallbackContext context);
        void OnTrayD(InputAction.CallbackContext context);
    }
}
