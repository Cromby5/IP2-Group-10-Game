//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/PlayerControl.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControl : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""PlayerMove"",
            ""id"": ""32f29615-1d0a-4c8b-82b5-7938bca86e18"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""054e0244-6b78-4b15-a445-ada58cd0222b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a0a75a32-8eb1-41a6-ba9c-6ee6e54b4bce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Place Trap"",
                    ""type"": ""Button"",
                    ""id"": ""59a5e5da-7550-4c15-8c29-1eb6572e75c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""c356b82b-9516-452b-ad14-ec5272cc3595"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""3dc1a064-46d1-430a-91b6-0def5cc41a2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""673c3600-70dd-453e-b854-e40580da88be"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardP1"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fca2543a-f404-47e1-9983-a3c7fc04bab1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1f1a907-8e04-42a9-959c-1c225d386648"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardP2"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""94e18473-fa78-4d6b-b8a9-082f97bd11d5"",
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
                    ""id"": ""40d33b72-4df2-424c-8732-6c44306b4708"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardP1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""04f9af30-9dd2-4d10-9fb6-e5c69d581183"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardP1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d9de72ab-c56c-44e8-ac7c-2b2d8fa2091f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardP1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2cbd6d55-9049-4d1c-addc-8d725fbe07fd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardP1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""68ba6a20-0aca-4086-abea-8bd07e4d984f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""1587d53a-e0e2-4b1c-a795-0f9b47bf0db2"",
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
                    ""id"": ""d4893d96-65e7-4998-94e7-4bd75abc23de"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardP2"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""efd8c3d1-9569-4ad1-ad15-8cbc3322f632"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardP2"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c5621633-85ec-4abd-929c-da7661721655"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardP2"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a6b71f1a-eb76-452c-b3bd-9f1e232720d3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardP2"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2b235173-005b-4baa-8ef0-9563276abf67"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""KeyboardP1"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d8576b5-e211-4056-b61f-7f8c26036706"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8688aa6-d06b-4d44-b904-76ba1adeed08"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""KeyboardP1"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74e5db12-02cf-4093-acfd-1cfb688c7e71"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13ad2232-01cb-4a43-b072-90d71a7becb4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Place Trap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94eb638b-ad68-4650-a05e-27418886c7e4"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardP1"",
                    ""action"": ""Place Trap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardP1"",
            ""bindingGroup"": ""KeyboardP1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardP2"",
            ""bindingGroup"": ""KeyboardP2"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerMove
        m_PlayerMove = asset.FindActionMap("PlayerMove", throwIfNotFound: true);
        m_PlayerMove_Movement = m_PlayerMove.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMove_Jump = m_PlayerMove.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMove_PlaceTrap = m_PlayerMove.FindAction("Place Trap", throwIfNotFound: true);
        m_PlayerMove_Select = m_PlayerMove.FindAction("Select", throwIfNotFound: true);
        m_PlayerMove_Cancel = m_PlayerMove.FindAction("Cancel", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerMove
    private readonly InputActionMap m_PlayerMove;
    private IPlayerMoveActions m_PlayerMoveActionsCallbackInterface;
    private readonly InputAction m_PlayerMove_Movement;
    private readonly InputAction m_PlayerMove_Jump;
    private readonly InputAction m_PlayerMove_PlaceTrap;
    private readonly InputAction m_PlayerMove_Select;
    private readonly InputAction m_PlayerMove_Cancel;
    public struct PlayerMoveActions
    {
        private @PlayerControl m_Wrapper;
        public PlayerMoveActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMove_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerMove_Jump;
        public InputAction @PlaceTrap => m_Wrapper.m_PlayerMove_PlaceTrap;
        public InputAction @Select => m_Wrapper.m_PlayerMove_Select;
        public InputAction @Cancel => m_Wrapper.m_PlayerMove_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMove; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMoveActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMoveActions instance)
        {
            if (m_Wrapper.m_PlayerMoveActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnJump;
                @PlaceTrap.started -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnPlaceTrap;
                @PlaceTrap.performed -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnPlaceTrap;
                @PlaceTrap.canceled -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnPlaceTrap;
                @Select.started -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnSelect;
                @Cancel.started -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_PlayerMoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @PlaceTrap.started += instance.OnPlaceTrap;
                @PlaceTrap.performed += instance.OnPlaceTrap;
                @PlaceTrap.canceled += instance.OnPlaceTrap;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public PlayerMoveActions @PlayerMove => new PlayerMoveActions(this);
    private int m_KeyboardP1SchemeIndex = -1;
    public InputControlScheme KeyboardP1Scheme
    {
        get
        {
            if (m_KeyboardP1SchemeIndex == -1) m_KeyboardP1SchemeIndex = asset.FindControlSchemeIndex("KeyboardP1");
            return asset.controlSchemes[m_KeyboardP1SchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_KeyboardP2SchemeIndex = -1;
    public InputControlScheme KeyboardP2Scheme
    {
        get
        {
            if (m_KeyboardP2SchemeIndex == -1) m_KeyboardP2SchemeIndex = asset.FindControlSchemeIndex("KeyboardP2");
            return asset.controlSchemes[m_KeyboardP2SchemeIndex];
        }
    }
    public interface IPlayerMoveActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPlaceTrap(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
}