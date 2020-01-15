using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;


namespace CS
{
    public class InputManager : MonoBehaviour, Controls.IPlayerControlsActions
    {
        Controls m_controls; //Input Actions

        #region DEBUG
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] bool m_disableInput;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] Vector2 m_inputVector;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] Vector2 m_mouseInputVector;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] bool m_isMoving;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] public bool isJumping;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] public bool isRunning;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] public bool isCrouching;
        #endregion

        public delegate void OnInteractPressed();
        public event OnInteractPressed playerInteracting;

        public delegate void OnLeftMousePressed();
        public event OnLeftMousePressed leftMousePressed;

        #region GETTERS & SETTERS
        public Vector2 InputVector { get => m_inputVector; }
        public Vector2 MouseInputVector { get => m_mouseInputVector; set => m_mouseInputVector = value; }
        public bool IsMoving { get => m_isMoving; }
        public bool DisableInput { get => m_disableInput; set => m_disableInput = value; }

        #endregion

        public delegate void TogglePause();
        public event TogglePause m_togglePuse;

        #region BuiltIn Methods
        private void Awake()
        {
            m_controls = new Controls();
            m_controls.PlayerControls.SetCallbacks(this);
        }

        #endregion

        #region Controls
        private void OnEnable()
        {
            m_controls.Enable();
        }
        private void OnDisable()
        {
            m_controls.Disable();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            if (!m_disableInput)
                m_inputVector = context.ReadValue<Vector2>();
        }

        public void OnMouse(InputAction.CallbackContext context)
        {
            if(!m_disableInput)
            m_mouseInputVector = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed && !m_disableInput)
            {
                isJumping = !isJumping;
                Debug.Log("Jump Action IM");
            }

        }

        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.performed && !m_disableInput)
            {
                isRunning = !isRunning;
                Debug.Log("Run Action IM");
            }

        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            if (context.performed && !m_disableInput) 
            {
                isCrouching = !isCrouching;
            }
        }

        public void OnEsc(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_togglePuse();
            }
        }

        public void OnLeftMouse(InputAction.CallbackContext context)
        {
            if(context.performed && !m_disableInput)
            {
                leftMousePressed();
            }

        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed && !m_disableInput)
            {
                playerInteracting();
            }

        }

        public void OnRightMouse(InputAction.CallbackContext context)
        {
            if (context.performed && !m_disableInput)
            {

            }

        }



        public void ResetInput()
        {
            m_inputVector = new Vector2(0,0);
            m_mouseInputVector = new Vector2(0, 0);
            m_isMoving = false;
        }


        #endregion

    }
}

