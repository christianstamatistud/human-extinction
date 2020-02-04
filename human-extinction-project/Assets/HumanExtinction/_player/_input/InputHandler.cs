using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;

namespace CS
{    
    public class InputHandler : MonoBehaviour, Controls.IPlayerControlsActions
    {
        #region Data
            [BoxGroup("Input Data")]
            public CameraInputData cameraInputData;
            [BoxGroup("Input Data")]
            public MovementInputData movementInputData;

        #endregion

        #region Variables
        Controls m_controls; //Input Actions

        public Vector2 m_movementVector;
        Vector2 m_mouseVector;
        public bool isRunning;

        #endregion

        #region BuiltIn Methods
        private void Awake()
        {
            m_controls = new Controls();
            m_controls.PlayerControls.SetCallbacks(this);
        }

        private void OnEnable()
        {
            m_controls.Enable();
        }

        private void OnDisable()
        {
            m_controls.Disable();
        }

        void Start()
            {
                cameraInputData.ResetInput();
                movementInputData.ResetInput();

            m_mouseVector.x = 0;
            m_mouseVector.y = 0;
        }

            void Update()
            {
                GetCameraInput();
                GetMovementInputData();
            }
        #endregion

        #region Delegates
        public delegate void OnPlayerInteract();
        public event OnPlayerInteract playerInteract;

        #endregion

        #region CallBack Actions

        public void OnRunPressed(InputAction.CallbackContext context)
        {
            if (!GameManager.Instance.pauseGame && !GameManager.Instance.disableInput)
            {
                isRunning = true;
            }
        }

        public void OnRunReleased(InputAction.CallbackContext context)
        {
            if (!GameManager.Instance.pauseGame && !GameManager.Instance.disableInput)
            {
                isRunning = false;
            }
        }



        public void OnEsc(InputAction.CallbackContext context)
        {
            if (context.performed && !GameManager.Instance.onMainMenu)
            {
                GameManager.Instance.TogglePause();
            }
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            if (!GameManager.Instance.pauseGame && !GameManager.Instance.disableInput)
                m_movementVector = context.ReadValue<Vector2>();

        }

        public void OnMouse(InputAction.CallbackContext context)
        {
            if(!GameManager.Instance.pauseGame && !GameManager.Instance.disableInput)
                m_mouseVector = context.ReadValue<Vector2>();

        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed && !GameManager.Instance.pauseGame && !GameManager.Instance.disableInput)
            {
                //Call Interaction Event
                playerInteract();
                print("Interacted");
            }
        }

        public void OnToggleInventory(InputAction.CallbackContext context)
        {
            if (context.performed && !GameManager.Instance.pauseGame)
            {
                ResetInput();
                GameManager.Instance.ToggleCursorState();
                GameManager.Instance.ToggleInventory();
            }
        }



        #endregion

        #region Custom Methods


        void GetCameraInput()
            {
                cameraInputData.InputVectorX = m_mouseVector.x;
                cameraInputData.InputVectorY = m_mouseVector.y;
            }

            void GetMovementInputData()
            {
                movementInputData.InputVectorX = m_movementVector.x;
                movementInputData.InputVectorY = m_movementVector.y;

                movementInputData.RunClicked = Input.GetKeyDown(KeyCode.LeftShift);
                movementInputData.RunReleased = Input.GetKeyUp(KeyCode.LeftShift);

                if(movementInputData.RunClicked)
                    movementInputData.IsRunning = true;

                if(movementInputData.RunReleased)
                    movementInputData.IsRunning = false;

                //movementInputData.JumpClicked = Input.GetKeyDown(KeyCode.Space);
                //movementInputData.CrouchClicked = Input.GetKeyDown(KeyCode.LeftControl);
            }

        void ResetInput()
        {
            m_movementVector = Vector2.zero;
            m_mouseVector = Vector2.zero;
        }

        #endregion
    }
}