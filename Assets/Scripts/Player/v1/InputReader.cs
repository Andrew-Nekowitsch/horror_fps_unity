using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace My.Assets.Scripts.Player.v1
{
    [CreateAssetMenu(menuName = "My/InputReader/v1")]
    public class InputReader : ScriptableObject, InputSystem_Actions.IPlayerActions, InputSystem_Actions.IUIActions
    {
        [SerializeField]
        private InputSystem_Actions _inputActions;

        public event Action<Vector2> OnMoveEvent;
        public event Action<Vector2> OnLookEvent;
        public event Action OnAttackEvent;
        public event Action OnJumpEvent;
        public event Action OnJumpCanceledEvent;
        public event Action OnCrouchEvent;
        public event Action OnCrouchCanceledEvent;
        public event Action OnInteractEvent;
        public event Action OnSprintEvent;
        public event Action OnSprintCanceledEvent;

        private void OnEnable()
        {
            Debug.Log("InputReader enabled");
            if (_inputActions == null)
            {
                _inputActions = new InputSystem_Actions();
                _inputActions.Player.SetCallbacks(this);
                _inputActions.UI.SetCallbacks(this);
            }
            _inputActions.Enable();

            SetPlayer();
        }

        private void OnDisable()
        {
            Debug.Log("InputReader disabled");
            _inputActions.Disable();
            _inputActions.Player.Disable();
            _inputActions.UI.Disable();
        }

        public void SetPlayer()
        {
            _inputActions.Player.Enable();
            _inputActions.UI.Disable();
        }

        public void SetUI()
        {
            _inputActions.Player.Disable();
            _inputActions.UI.Enable();
        }

        #region Player Actions
        void InputSystem_Actions.IPlayerActions.OnMove(InputAction.CallbackContext context)
        {
            Debug.Log("OnMove");
            OnMoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        void InputSystem_Actions.IPlayerActions.OnLook(InputAction.CallbackContext context)
        {
            Debug.Log("OnLook");
            OnLookEvent?.Invoke(context.ReadValue<Vector2>());
        }

        void InputSystem_Actions.IPlayerActions.OnAttack(InputAction.CallbackContext context)
        {
            Debug.Log("OnAttack");
            OnAttackEvent?.Invoke();
        }

        void InputSystem_Actions.IPlayerActions.OnInteract(InputAction.CallbackContext context)
        {
            Debug.Log("OnInteract");
            if (context.phase == InputActionPhase.Canceled)
            {
                OnInteractEvent?.Invoke();
            }
        }

        void InputSystem_Actions.IPlayerActions.OnCrouch(InputAction.CallbackContext context)
        {
            Debug.Log("OnCrouch");
            if (context.phase == InputActionPhase.Performed)
            {
                OnCrouchEvent?.Invoke();
            }
            else if (context.phase == InputActionPhase.Canceled)
            {
                OnCrouchCanceledEvent?.Invoke();
            }
        }

        void InputSystem_Actions.IPlayerActions.OnJump(InputAction.CallbackContext context)
        {
            Debug.Log("OnJump");
            if (context.phase == InputActionPhase.Performed)
            {
                OnJumpEvent?.Invoke();
            }
            else if (context.phase == InputActionPhase.Canceled)
            {
                OnJumpCanceledEvent?.Invoke();
            }
        }

        void InputSystem_Actions.IPlayerActions.OnSprint(InputAction.CallbackContext context)
        {
            Debug.Log("OnSprint");
            if (context.phase == InputActionPhase.Performed)
            {
                OnSprintEvent?.Invoke();
            }
            else if (context.phase == InputActionPhase.Canceled)
            {
                OnSprintCanceledEvent?.Invoke();
            }
        }

        void InputSystem_Actions.IPlayerActions.OnSlot1(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        void InputSystem_Actions.IPlayerActions.OnSlot2(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        void InputSystem_Actions.IPlayerActions.OnSlot3(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        void InputSystem_Actions.IPlayerActions.OnSlot4(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region UI Actions
        void InputSystem_Actions.IUIActions.OnNavigate(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        void InputSystem_Actions.IUIActions.OnSubmit(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        void InputSystem_Actions.IUIActions.OnCancel(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        void InputSystem_Actions.IUIActions.OnPoint(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        void InputSystem_Actions.IUIActions.OnClick(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        void InputSystem_Actions.IUIActions.OnRightClick(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        void InputSystem_Actions.IUIActions.OnMiddleClick(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        void InputSystem_Actions.IUIActions.OnScrollWheel(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        void InputSystem_Actions.IUIActions.OnTrackedDevicePosition(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        void InputSystem_Actions.IUIActions.OnTrackedDeviceOrientation(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
