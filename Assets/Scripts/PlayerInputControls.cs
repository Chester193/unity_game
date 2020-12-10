// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""4fbf580f-6e25-46a2-8b08-b2062783d1f7"",
            ""actions"": [
                {
                    ""name"": ""MoveHorizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ba7402c7-32a6-47bf-bac4-ac884a04f2af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveVertical"",
                    ""type"": ""Button"",
                    ""id"": ""a64f7ce6-c3f4-44d0-82b7-eea55c444146"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""35c74122-df3e-45ce-a9f1-373efb6ce7ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""ce097cfb-211b-452e-84d4-ae1a738f36b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""eff9bf56-8e2c-4f4d-a2c8-e28fea39ba7d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ffff09cc-daf4-478e-a42e-ea57dafb7bc6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""038d15c5-e457-4023-a7fa-3ef37a04ca71"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c16dd42b-dd28-4d7c-a5d3-85d57e90b26e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""30b5de0d-b680-40bd-986e-242c624d216d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7e619102-7ad1-49b6-8f12-2d8515d31819"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ddb8eeb8-a280-4677-b1cf-b23516f0b8ac"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aea75279-d4ef-4de0-97e7-b284b533b6c5"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_MoveHorizontal = m_Default.FindAction("MoveHorizontal", throwIfNotFound: true);
        m_Default_MoveVertical = m_Default.FindAction("MoveVertical", throwIfNotFound: true);
        m_Default_Fire = m_Default.FindAction("Fire", throwIfNotFound: true);
        m_Default_ChangeWeapon = m_Default.FindAction("ChangeWeapon", throwIfNotFound: true);
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

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_MoveHorizontal;
    private readonly InputAction m_Default_MoveVertical;
    private readonly InputAction m_Default_Fire;
    private readonly InputAction m_Default_ChangeWeapon;
    public struct DefaultActions
    {
        private @PlayerInputControls m_Wrapper;
        public DefaultActions(@PlayerInputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveHorizontal => m_Wrapper.m_Default_MoveHorizontal;
        public InputAction @MoveVertical => m_Wrapper.m_Default_MoveVertical;
        public InputAction @Fire => m_Wrapper.m_Default_Fire;
        public InputAction @ChangeWeapon => m_Wrapper.m_Default_ChangeWeapon;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @MoveHorizontal.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMoveHorizontal;
                @MoveHorizontal.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMoveHorizontal;
                @MoveHorizontal.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMoveHorizontal;
                @MoveVertical.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMoveVertical;
                @MoveVertical.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMoveVertical;
                @MoveVertical.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMoveVertical;
                @Fire.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFire;
                @ChangeWeapon.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnChangeWeapon;
                @ChangeWeapon.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnChangeWeapon;
                @ChangeWeapon.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnChangeWeapon;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveHorizontal.started += instance.OnMoveHorizontal;
                @MoveHorizontal.performed += instance.OnMoveHorizontal;
                @MoveHorizontal.canceled += instance.OnMoveHorizontal;
                @MoveVertical.started += instance.OnMoveVertical;
                @MoveVertical.performed += instance.OnMoveVertical;
                @MoveVertical.canceled += instance.OnMoveVertical;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @ChangeWeapon.started += instance.OnChangeWeapon;
                @ChangeWeapon.performed += instance.OnChangeWeapon;
                @ChangeWeapon.canceled += instance.OnChangeWeapon;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnMoveHorizontal(InputAction.CallbackContext context);
        void OnMoveVertical(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnChangeWeapon(InputAction.CallbackContext context);
    }
}
