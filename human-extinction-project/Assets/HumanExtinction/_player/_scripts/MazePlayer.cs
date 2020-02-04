using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine.InputSystem;

namespace CS
{
    public class MazePlayer : MonoBehaviour, Controls.IPlayerMazeActions
    {
        Controls m_controls; //Input Actions


        public delegate void OnResetGame();
        public event OnResetGame resetGame;

        public delegate void OnMazeComplete();
        public event OnMazeComplete mazeComplete;

        public delegate void OnWrongPath();
        public event OnWrongPath wrongPath;

        public delegate void OnPlayerStart();
        public event OnPlayerStart playerStart;


        public enum CurrentDirection
        {
            start,
            idle,
            moving
        }
        [HideInInspector]public bool playerMovedFirstTime;

        [BoxGroup("Player")]  [ReadOnly] public CurrentDirection currentDirection = CurrentDirection.start;
        [BoxGroup("Player")] public float moveSpeed = 2f;

        // Ray
        Transform rayOrigin;
        [BoxGroup("Ray Settings")] public LayerMask layerMask;
        [BoxGroup("Ray Settings")] public float rayDistance = 0.3f;
        [BoxGroup("Ray Settings")] [ReadOnly]public Transform currentTarget;
        Transform lastTarget;
        int playerIndex;


        //Check Position
        [BoxGroup("Direction")] [ReadOnly] public bool lockedLeft;
        [BoxGroup("Direction")] [ReadOnly] public bool lockedRight;
        [BoxGroup("Direction")] [ReadOnly] public bool lockedUp;
        [BoxGroup("Direction")] [ReadOnly] public bool lockedDown;


        MazeObject mo;

        private void Awake()
        {
            SetControls();
            rayOrigin = transform.Find("ray").GetComponent<Transform>();
            mo = GetComponentInParent<MazeObject>();

        }

        void SetControls()
        {
            m_controls = new Controls();
            m_controls.PlayerMaze.SetCallbacks(this);
        }

        private void OnEnable()
        {
            m_controls.Enable();
        }

        private void OnDisable()
        {
            m_controls.Disable();
        }

        private void Update()
        {
            if (mo.autoStart)
            {
                UseStandardInput();
            }
            CheckTargetInformation();
            Move();

        }


        void Move()
        {

            if (playerMovedFirstTime)
            {
                if (currentTarget != null)
                {
                    currentDirection = CurrentDirection.moving;
                    transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * moveSpeed);
                }
                else
                {
                    currentDirection = CurrentDirection.idle;
                }
            }
            else
            {
                currentDirection = CurrentDirection.start;

            }

        }


        void UpdateLastTarget()
        {
            lastTarget = currentTarget;
        }


        private void CheckTargetInformation()
        {
            if (currentTarget != null && transform.position == currentTarget.transform.position && currentTarget.GetComponent<Point>().index == playerIndex)
            {
                playerIndex += 1;
                Point currentPoint = currentTarget.GetComponent<Point>();

                lockedLeft = currentPoint.lockLeft;
                lockedRight = currentPoint.lockRight;
                lockedDown = currentPoint.lockDown;
                lockedUp = currentPoint.lockUp;

                UpdateLastTarget();

                //UpdateCurrentTargetWhileMove();
                DestroyPoints();

                //every point check if win or game over
                MazeComplete();
                WrongPath();
                currentTarget = null;
            }
        }


        void MazeComplete()
        {
            Point p = currentTarget.GetComponent<Point>();
            if (p.win)
            {
                mazeComplete();
            }
        }

        void WrongPath()
        {
            Point p = currentTarget.GetComponent<Point>();
            if (p.gameOver)
            {
                if(wrongPath!=null)
                wrongPath();
            }
        }

        // destroy points behind us
        void DestroyPoints()
        {
            lastTarget.GetComponent<SphereCollider>().enabled = false;
        }


        void CheckDirection()
        {

            RaycastHit hit;

            if (Physics.Raycast(rayOrigin.transform.position, rayOrigin.up, out hit, rayDistance, layerMask))

            {
                currentTarget = hit.transform;

                Point p;
                p = hit.transform.GetComponent<Point>();
                p.index = playerIndex;

                rayDistance = p.raySize;

            }

            Debug.DrawRay(transform.position, rayOrigin.up, Color.green);
        }

        public void OnOnUpAction(InputAction.CallbackContext context)
        {
            if (context.performed && !GameManager.Instance.onMainMenu)
            {
                if(!playerMovedFirstTime && playerStart != null) 
                playerStart();

                playerMovedFirstTime = true;
                transform.eulerAngles = new Vector3(0, 90, -90);
                if (!lockedUp && currentDirection != CurrentDirection.moving)
                    CheckDirection();
            }
        }

        public void OnOnDownAction(InputAction.CallbackContext context)
        {
            if (context.performed && !GameManager.Instance.onMainMenu)
            {
                if(!playerMovedFirstTime && playerStart != null)
                playerStart();

                playerMovedFirstTime = true;
                transform.eulerAngles = new Vector3(0, 90, 90);
                if (!lockedDown && currentDirection != CurrentDirection.moving)
                    CheckDirection();
            }
        }

        public void OnOnRightAction(InputAction.CallbackContext context)
        {
            if (context.performed && !GameManager.Instance.onMainMenu)
            {
                if (!playerMovedFirstTime && playerStart!=null)
                    playerStart();

                playerMovedFirstTime = true;
                transform.eulerAngles = new Vector3(0, 90, 0);
                if (!lockedRight && currentDirection != CurrentDirection.moving)
                    CheckDirection();
            }
        }

        public void OnOnLeftAction(InputAction.CallbackContext context)
        {
            if (context.performed && !GameManager.Instance.onMainMenu)
            {
                if (!playerMovedFirstTime && playerStart != null)
                    playerStart();

                playerMovedFirstTime = true;
                transform.eulerAngles = new Vector3(0, -90, 0);
                if (!lockedLeft && currentDirection != CurrentDirection.moving)
                    CheckDirection();
            }
        }

        public void OnOnQuitInteraction(InputAction.CallbackContext context)
        {
            if (context.performed && !GameManager.Instance.onMainMenu)
            {
                if(mo.isInteractive)
                {
                    print("quit");
                    mo.QuitInteraction();
                    mo.isInteractive = false;
                }
            }
        }

        void UseStandardInput()
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                if (!playerMovedFirstTime && playerStart != null)
                    playerStart();

                playerMovedFirstTime = true;
                transform.eulerAngles = new Vector3(0, 90, -90);
                if (!lockedUp && currentDirection != CurrentDirection.moving)
                    CheckDirection();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (!playerMovedFirstTime && playerStart != null)
                    playerStart();

                playerMovedFirstTime = true;
                transform.eulerAngles = new Vector3(0, 90, 90);
                if (!lockedDown && currentDirection != CurrentDirection.moving)
                    CheckDirection();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (!playerMovedFirstTime && playerStart != null)
                    playerStart();

                playerMovedFirstTime = true;
                transform.eulerAngles = new Vector3(0, -90, 0);
                if (!lockedLeft && currentDirection != CurrentDirection.moving)
                    CheckDirection();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (!playerMovedFirstTime && playerStart != null)
                    playerStart();

                playerMovedFirstTime = true;
                transform.eulerAngles = new Vector3(0, 90, 0);
                if (!lockedRight && currentDirection != CurrentDirection.moving)
                    CheckDirection();
            }

        }
    }
}
