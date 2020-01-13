using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;


namespace CS
{
    public class InputManager : MonoBehaviour, Controls.IPlayerControlsActions
    {
        Controls m_controls; //Input Actions

        #region Delegates
        public delegate void OnPlayerJumped();
        public event OnPlayerJumped isJumping;

        public delegate void OnPlayerCrouch();
        public event OnPlayerCrouch isCrouching;

        public delegate void OnEscape();
        public event OnEscape escape;

        public delegate void OnRunning();
        public event OnRunning isRunning;

        public delegate void isInteracting();
        public event isInteracting Interacting;

        public delegate void isDraggable();
        public event isDraggable draggableObjectClick;




        #endregion

        #region DEBUG
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] bool m_disableInput;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] Vector2 m_inputVector;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] Vector2 m_mouseInputVector;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] bool m_isMoving;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] bool m_isJumping;
        #endregion

        #region GETTERS & SETTERS
        public Vector2 InputVector { get => m_inputVector; }
        public Vector2 MouseInputVector { get => m_mouseInputVector; set => m_mouseInputVector = value; }
        public bool IsMoving { get => m_isMoving; }
        public bool IsJumping { get => m_isJumping; }

        public bool DisableInput { get => m_disableInput; set => m_disableInput = value; }

        #endregion

        #region BuiltIn Methods
        private void Awake()
        {
            m_controls = new Controls();
            m_controls.PlayerControls.SetCallbacks(this);
        }

        private void Update()
        {
            m_isJumping = false;

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

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed && !m_disableInput)
            {
                isJumping();
                m_isJumping = true;
            }
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            if (context.performed && !m_disableInput )
            {
                m_isMoving = true;
            }
            else
            {
                m_isMoving = false;
            }

            if(!m_disableInput)
            m_inputVector = context.ReadValue<Vector2>();
        }

        public void OnMouse(InputAction.CallbackContext context)
        {
            if(!m_disableInput )
            m_mouseInputVector = context.ReadValue<Vector2>();
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            if (!m_disableInput && context.performed)
                isRunning();
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            if (context.performed && !m_disableInput) 
            {
                isCrouching();
            }
        }

        public void OnEsc(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                escape();
            }
        }

        public void OnLeftMouse(InputAction.CallbackContext context)
        {
            if(context.performed && !m_disableInput)
            draggableObjectClick();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed && !m_disableInput)
            {
                Interacting();
            }

        }

        public void OnRightMouse(InputAction.CallbackContext context)
        {

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

