using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowThePath : MonoBehaviour
{

    public delegate void Reset();
    public event Reset resetColliders;

    public enum CurrentDirection{
        start,
        idle,
        moving
    }
    public CurrentDirection currentDirection = CurrentDirection.start;
    Color initialColor;
    public float moveSpeed = 2f;
    Vector3 initialPos;

    // Ray
    public Transform rayOrigin;
    public LayerMask layerMask;
    public float rayDistance = 10f;
    public Transform currentTarget;
    Transform lastTarget;
    int playerIndex;
    
    //Check Position
    [HideInInspector]public bool lockedLeft;
    [HideInInspector] public bool lockedRight;
    [HideInInspector] public bool lockedUp;
    [HideInInspector] public bool lockedDown;


    //timer
    public float startTime;
    float currentTime;
    bool isRunning;
    bool gameStarted;

    //Components
    TrailRenderer tr;
    Transform circle;


    private void OnEnable()
    {
        initialPos = transform.position;
        currentTime = startTime;
        tr = GetComponentInChildren<TrailRenderer>();
        circle = transform.Find("circle").GetComponent<Transform>();
        initialColor = tr.material.color;
        circle.DOScale(new Vector3(1, 1, 1), 0.5f);

    }

    private void OnDisable()
    {
        circle.DOScale(new Vector3(0, 0, 0), 0.5f);

    }


    private void Update()
    {
        SetInput();
        CheckTargetInformation();
        Move();
        PlayerInactiveTimer();
    }

    void Move()
    {

        if (gameStarted)
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

    void SetInput()
    {



        ////////////// Rotate andcheck directions

        if (Input.GetKeyDown(KeyCode.A) )
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            if (!lockedLeft && currentDirection != CurrentDirection.moving)
                CheckDirection();

        }

        //////////////


        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, -180);
            if(!lockedRight && currentDirection != CurrentDirection.moving)
            CheckDirection();
        }

        ///////////////


        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            if(!lockedUp && currentDirection != CurrentDirection.moving)
            CheckDirection();
        }

        //////////////////


        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            if(!lockedDown && currentDirection != CurrentDirection.moving)
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

            //every point check if win or game over
            OnCompleteMaze();
            OnWrongPath();
            currentTarget = null;
        }
    }


    void OnCompleteMaze()
    {
        Point p = currentTarget.GetComponent<Point>();
        if (p.win)
        {
            tr.material.color = Color.green;
            GetComponent<FollowThePath>().enabled = false;
            //destroy maze 
            //green color

        }

        //Go to master and complete
    }

    void OnWrongPath()
    {
        Point p = currentTarget.GetComponent<Point>();
        if (p.gameOver)
        {
            tr.material.color = Color.red;
            //reset game
            circle.DOScale(new Vector3(0, 0, 0), 0.2f).OnComplete(() => ResetGame());
        }
    }

    // destroy points behind us
    void DestroyPoints ()
    {
        lastTarget.GetComponent<CircleCollider2D>().enabled = false;
    }

    // Check if we are inactive
    void PlayerInactiveTimer()
    {

        if (currentDirection == CurrentDirection.idle)
        {
            isRunning = true;

        }
        else
        {
            currentTime = startTime;
            isRunning = false;
        }

        if (isRunning)
        {
            currentTime = currentTime - 1 * Time.deltaTime;
            if(currentTime <= 0)
            {
                currentTime = startTime;
                ResetGame();
                isRunning = false;
                print("timeExpired");
            }
        }

    }


    void ResetGame()
    {

        transform.position = initialPos;
        tr.time = 0;
        tr.material.color = initialColor;
        currentTarget = null;
        lastTarget = null;
        circle.DOScale(new Vector3(1f, 1f, 1f), 0.2f).OnComplete(() => tr.time = 1000);
        lockedDown = false;
        lockedUp = false;
        lockedRight = false;
        lockedLeft = false;
        gameStarted = false;

        if(resetColliders !=null)
        resetColliders();

        print("resetting");
        // call funcion to reset 

    }


    void CheckDirection()
    {

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, rayOrigin.up, rayDistance, layerMask);
        if (hit)
        {
            currentTarget = hit.transform;

            Point p;
            p = hit.transform.GetComponent<Point>();
            p.index = playerIndex;

            rayDistance = p.raySize;



            print("hit something");
            gameStarted = true;
        }

        Debug.DrawRay(transform.position, rayOrigin.up, Color.green);
    }


}