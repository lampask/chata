// GENERATED AUTOMATICALLY FROM 'Assets/Settings/InputSetting.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSetting : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSetting()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSetting"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""c32da6ab-a3ca-40b3-9024-6d9974932cae"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b7f01dbc-c8e6-45c0-8556-4498e57878a4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""View"",
                    ""type"": ""Value"",
                    ""id"": ""3007d1b6-32ab-48c6-824e-845f0411247f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""06711f53-6e39-4edb-ac07-aceb7fddc64c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Focus"",
                    ""type"": ""Button"",
                    ""id"": ""340fa31e-aad1-4d9d-a795-aa6181b4269a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Value"",
                    ""id"": ""19a5b8dd-295f-4888-a03f-efe9435d32d0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Value"",
                    ""id"": ""42dd78c3-dae3-4779-b978-0942620c6cc7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9a021cc1-9041-40b9-b9a7-8241fe265125"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9de007ba-09d2-4088-b8ea-416a3f12b37e"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04a2d3c9-bc04-410a-8b03-98e8e2c30b71"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e445f25f-4618-492b-8bac-f91f431ef967"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6dbfaf2a-2a0b-43ec-b20b-33edd50cb1db"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""08944bc4-15f7-432e-95bc-3df526591826"",
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
                    ""id"": ""394b8ffd-e8e3-4882-8b2a-59127a5a2f5e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ca0cbe8e-2ee3-47fd-bf1e-fc4e8e0947c1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""83c6f355-e1ce-4496-a0e8-c5587cece4dc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6bdfdb0b-074e-4f08-b28d-d425b28e851d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1c0981dc-448a-4db2-b3bf-6b88bef61611"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5c171be-3f31-4c6b-8314-267a3b88d9bd"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8eda425-c050-44f6-b80a-b4bed2f02fa7"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3959750a-f648-4b27-9fd5-9c2cb59a641a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Focus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4aac7514-b73d-4191-bf42-2f6945d479b2"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Focus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a16a57b-bbb7-4424-b87c-528eab271399"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4e773f95-c383-400b-ac0c-cb3aefd5eee8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""15dd505b-74fc-4629-bbbd-c8f1aced9bf5"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b903ec95-008f-4adb-a8aa-9f6da31ca8dc"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""87f3a89e-5759-4bd2-a775-7213f29a3b8a"",
            ""actions"": [
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Value"",
                    ""id"": ""1690c331-b2e7-4ce4-92f7-4f29beab5af2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""03ff71ee-f9a9-4608-85f6-b4fd50c6d099"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""299e397a-0e0f-443f-992c-2abc0e7aab1b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32d61ae5-c5f3-4b13-aff4-1b9c011bc580"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0c56876-3130-4591-9b45-f8964fd96c5b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
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
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": []
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_View = m_Gameplay.FindAction("View", throwIfNotFound: true);
        m_Gameplay_Interaction = m_Gameplay.FindAction("Interaction", throwIfNotFound: true);
        m_Gameplay_Focus = m_Gameplay.FindAction("Focus", throwIfNotFound: true);
        m_Gameplay_Drag = m_Gameplay.FindAction("Drag", throwIfNotFound: true);
        m_Gameplay_Select = m_Gameplay.FindAction("Select", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Interaction = m_Menu.FindAction("Interaction", throwIfNotFound: true);
        m_Menu_Confirm = m_Menu.FindAction("Confirm", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_View;
    private readonly InputAction m_Gameplay_Interaction;
    private readonly InputAction m_Gameplay_Focus;
    private readonly InputAction m_Gameplay_Drag;
    private readonly InputAction m_Gameplay_Select;
    public struct GameplayActions
    {
        private @InputSetting m_Wrapper;
        public GameplayActions(@InputSetting wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @View => m_Wrapper.m_Gameplay_View;
        public InputAction @Interaction => m_Wrapper.m_Gameplay_Interaction;
        public InputAction @Focus => m_Wrapper.m_Gameplay_Focus;
        public InputAction @Drag => m_Wrapper.m_Gameplay_Drag;
        public InputAction @Select => m_Wrapper.m_Gameplay_Select;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @View.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnView;
                @View.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnView;
                @View.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnView;
                @Interaction.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteraction;
                @Focus.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFocus;
                @Focus.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFocus;
                @Focus.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFocus;
                @Drag.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrag;
                @Select.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @View.started += instance.OnView;
                @View.performed += instance.OnView;
                @View.canceled += instance.OnView;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @Focus.started += instance.OnFocus;
                @Focus.performed += instance.OnFocus;
                @Focus.canceled += instance.OnFocus;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Interaction;
    private readonly InputAction m_Menu_Confirm;
    public struct MenuActions
    {
        private @InputSetting m_Wrapper;
        public MenuActions(@InputSetting wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interaction => m_Wrapper.m_Menu_Interaction;
        public InputAction @Confirm => m_Wrapper.m_Menu_Confirm;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Interaction.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnInteraction;
                @Confirm.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnConfirm;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
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
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnView(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnFocus(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnInteraction(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
    }
}
