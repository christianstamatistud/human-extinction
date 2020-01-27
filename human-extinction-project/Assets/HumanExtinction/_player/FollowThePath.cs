using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowThePath : MonoBehaviour
{

    public enum CurrentDirection{
        up,
        down,
        left,
        right,
        idle,
        initialPosition
    }

    public CurrentDirection currentDirection = CurrentDirection.initialPosition;
    public float moveSpeed = 2f;

    // Ray
    public Transform rayOrigin;
    public LayerMask layerMask;
    public float rayDistance = 10f;
    Transform currentTarget;
    Transform lastTarget;
    public int playerIndex;
    
    //Check Position
    bool lockedLeft;
    bool lockedRight;
    bool lockedUp;
    bool lockedDown;
    bool gameStarted;

    //timer
    public float startTime;
    float currentTime;
    bool isRunning;

    //Components
    TrailRenderer tr;
    Transform circle;


    private void Start()
    {
        currentTime = startTime;
        tr = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        circle = transform.Find("circle").GetComponent<Transform>();
        CircleIn();
    }

    void CircleIn()
    {
        circle.DOScale(new Vector3(1, 1, 1), 0.5f);
    }

    void CircleOut()
    {
        circle.DOScale(new Vector3(0, 0, 0), 0.5f);
    }


    private void Update()
    {
        SetInput();
        CheckTargetInformation();
        Move();
        ResetGame();
        //Timer();
    }

    void Move()
    {
        //if (currentDirection == CurrentDirection.up || currentDirection == CurrentDirection.down || currentDirection == CurrentDirection.left || currentDirection == CurrentDirection.right)
        //{

        //}

        if (currentTarget != null)
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * moveSpeed);
    }


    void UpdateLastTarget()
    {
        lastTarget = currentTarget;
    }

    void SetInput()
    {

        if (gameStarted)
        {
            currentDirection = CurrentDirection.idle;
        }
        else
        {
            currentDirection = CurrentDirection.initialPosition;
        }

        //move
        if (Input.GetKey(KeyCode.A))
        {
            currentDirection = CurrentDirection.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentDirection = CurrentDirection.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentDirection = CurrentDirection.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentDirection = CurrentDirection.down;
        }


        ////////////// Rotate andcheck directions

        if (Input.GetKeyDown(KeyCode.A) )
        {
            gameStarted = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
            if (!lockedLeft)
                CheckDirection();

        }

        //////////////


        if (Input.GetKeyDown(KeyCode.D))
        {
            gameStarted = true;
            transform.eulerAngles = new Vector3(0, 0, -180);
            if(!lockedRight)
            CheckDirection();
        }

        ///////////////


        if (Input.GetKeyDown(KeyCode.W))
        {
            gameStarted = true;
            transform.eulerAngles = new Vector3(0, 0, -90);
            if(!lockedUp)
            CheckDirection();
        }

        //////////////////


        if (Input.GetKeyDown(KeyCode.S))
        {
            gameStarted = true;
            transform.eulerAngles = new Vector3(0, 0, 90);
            if(!lockedDown)
            CheckDirection();
        }

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

            OnCompleteMaze();
            print("hit a point");

        }
    }


    void OnCompleteMaze()
    {
        Point p = currentTarget.GetComponent<Point>();
        if (p.win)
        {
            tr.material.color = Color.green;
            CircleOut();
        }
    }


    void UpdateCurrentTargetWhileMove()
    {
        print("update");
        if (currentDirection == CurrentDirection.left)
        {
            if (!lockedLeft)
            {
                CheckDirection();
            }
        }

        if (currentDirection == CurrentDirection.right)
        {
            if (!lockedRight)
            {
                CheckDirection();
            }
        }

        if (currentDirection == CurrentDirection.up)
        {
            if (!lockedUp)
            {
                CheckDirection();
            }
        }

        if (currentDirection == CurrentDirection.down)
        {
            if (!lockedDown)
            {
                CheckDirection();
            }
        }
    }

    void DestroyPoints ()
    {
        lastTarget.GetComponent<CircleCollider2D>().enabled = false;
    }


    void Timer()
    {
        if (isRunning)
        {
            currentTime = currentTime - 1 * Time.deltaTime;
            if(currentTime <= 0)
            {
                currentTime = startTime;
                DestroyPlayer();
                isRunning = false;
                
                print("timeExpired");
            }
        }

    }

    void DestroyPlayer()
    {
        Destroy(gameObject);
    }
    void ResetGame()
    {
        if (currentDirection == CurrentDirection.idle)
        {
            isRunning = true;
            //if timer == 2
            // destroy
        }
        else
        {
            currentTime = startTime;
            isRunning = false;
            //reset timer
        }
    }


    void CheckDirection()
    {

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, rayOrigin.up, rayDistance, layerMask);
        if (hit)
        {
            currentTarget = hit.transform;
            hit.transform.GetComponent<Point>().index = playerIndex;
            print("hit something");
        }

        Debug.DrawRay(transform.position, rayOrigin.up, Color.green);
    }


}