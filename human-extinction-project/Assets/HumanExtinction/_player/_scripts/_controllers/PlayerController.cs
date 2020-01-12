using UnityEngine;
using NaughtyAttributes;

namespace CS
{

    public class PlayerController : MonoBehaviour
    {
        #region Variables
        InputManager inputManager;
        CharacterController characterController;
        
        //Move
        enum CurrentState { Forward, Backward, Right, Left, None, Crouch, Run}
        Vector2 m_smoothMovementInput;
        Vector3 m_movementInput;

        [BoxGroup("Player")] [SerializeField] [ReadOnly] CurrentState m_currentState;
        [BoxGroup("Player")] [SerializeField] float m_speed = 3f;
        [BoxGroup("Player")] [SerializeField] float m_backSpeed = 1.5f;
        [BoxGroup("Player")] [SerializeField] float m_horizontalSpeed = 2.1f;
        [BoxGroup("Player")] [SerializeField] float m_jumpHeight = 1.2f;

        //Gravity
        [BoxGroup("Player")] [SerializeField] float m_gravity = -21f;
        [BoxGroup("Player")] [SerializeField] float m_radius = 0.2f;
        [BoxGroup("Player")] [SerializeField] LayerMask m_layer;
        Vector3 velocity;

        //Debug
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] float m_smoothInput = 7f;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] float m_currentSpeed;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] bool m_isGrounded;



        #endregion

        #region BuiltIn Methods
        private void Awake()
        {
            GetReferences();
        }

        void GetReferences()
        {
            inputManager = GameObject.FindObjectOfType<InputManager>();
            characterController = GetComponent<CharacterController>();
            m_currentSpeed = m_speed;
        }

        private void Update()
        {
            CalculateState();
            SmoothInput();

            ApplyGravity();
            MovePlayer();
            GroundChecker();
        }


        #endregion

        //events
        #region Input Listeners
        private void OnEnable()
        {
            inputManager.isJumping += Jump;
            inputManager.isCrouching += HandleCrouch;
            inputManager.isRunning += HandleRun;
        }

        private void OnDisable()
        {
            inputManager.isJumping -= Jump;
            inputManager.isCrouching -= HandleCrouch;
            inputManager.isRunning -= HandleRun;

        }
        #endregion


        #region Custom Methods
        void Jump()
        {
            if (m_isGrounded)
            {
                velocity.y = Mathf.Sqrt(m_jumpHeight * -2f * m_gravity);
            }
            Debug.Log("Jump Event");
        }

        void HandleCrouch()
        {
            Debug.Log("Crouch Event");
        }

        void HandleRun()
        {
            Debug.Log("Run Event");
        }

        void SmoothInput()
        {
            m_smoothMovementInput = Vector2.Lerp(m_smoothMovementInput, inputManager.InputVector, Time.deltaTime * m_smoothInput);
            m_movementInput = transform.right * m_smoothMovementInput.x + transform.forward * m_smoothMovementInput.y;
        }

        void MovePlayer()
        {
            characterController.Move(m_movementInput * (Time.deltaTime * m_currentSpeed));
        }

        void ApplyGravity()
        {
            velocity.y += m_gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);

            if(m_isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }

        void GroundChecker()
        {
            m_isGrounded = Physics.CheckSphere(transform.position, m_radius, m_layer);
        }


        void CalculateState()
        {

            #region State
            if (inputManager.IsMoving)
            {
                if (inputManager.InputVector.x < -0.1)
                {
                    m_currentState = CurrentState.Left;
                }

                if (inputManager.InputVector.x > 0.1)
                {
                    m_currentState = CurrentState.Right;
                }

                if (inputManager.InputVector.y > 0.1)
                {
                    m_currentState = CurrentState.Forward;
                }

                if (inputManager.InputVector.y < -0.1)
                {
                    m_currentState = CurrentState.Backward;
                }

            }
            else
            {
                m_currentState = CurrentState.None;
            }
            #endregion

            if(m_currentState == CurrentState.Backward)
            {
                m_currentSpeed = m_backSpeed;
            }

            if (m_currentState == CurrentState.Right || m_currentState == CurrentState.Left)
            {
                m_currentSpeed = m_horizontalSpeed;
            }

            if (m_currentState == CurrentState.Forward)
            {
                m_currentSpeed = m_speed;
            }

            if (m_currentState == CurrentState.None)
            {
                m_currentSpeed = m_speed;
            }



        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, m_radius);
        }
        #endregion


    }
}
