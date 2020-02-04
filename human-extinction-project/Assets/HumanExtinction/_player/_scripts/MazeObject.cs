using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

namespace CS
{
    public class MazeObject : MonoBehaviour
    {
        [BoxGroup("Trigger")] public Trigger onMazeComplete;
        [BoxGroup("Trigger")] public bool openDoor;
        [BoxGroup("Trigger")] public GameObject showSprite;


        public Transform mazePlayer;
        [BoxGroup("Player")] public Transform startPosition;
        [BoxGroup("Player")] public Transform endPosition;
        [BoxGroup("Player")] public float animationSpeed = 1;
        [BoxGroup("Player")] public Ease easeType;
        [BoxGroup("Player")] public bool isInteractive;
        [BoxGroup("Player")] public bool autoStart;
        Transform mazeRoot;

        private Transform pointsRoot;
        private SphereCollider[] colliders;

        [BoxGroup("Display")] public SpriteRenderer mazeSprite;
        InputHandler ih;

        //timer
        [BoxGroup("Timer")] public float startTime;
        [BoxGroup("Timer")] [ReadOnly] public float currentTime;
        [BoxGroup("Timer")] [ReadOnly] public bool isRunning;

        //player ref
        TrailRenderer playerTrail;
        public MazePlayer mp;
        Vector3 initialScale;
        Color initialColor;
        Point startP;
       

        private void Awake()
        {
            GetReferences();
        }

        private void OnEnable()
        {
            mp.wrongPath += WrongPath;
            mp.playerStart += GameStarted;
            mp.mazeComplete += MazeComplete;
        }

        private void OnDisable()
        {
            mp.wrongPath -= WrongPath;
            mp.playerStart -= GameStarted;
            mp.mazeComplete -= MazeComplete;

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartPlayer();
                isInteractive = true;
            }
            PlayerInactiveTimer();
        }

        void GetReferences()
        {
            GetColliders();
            ih = FindObjectOfType<InputHandler>();

            #region Player References
            startP = startPosition.transform.GetComponent<Point>();
            currentTime = startTime;
            initialScale = mazePlayer.transform.localScale;
            playerTrail = mazePlayer.transform.Find("trail").GetComponent<TrailRenderer>();
            initialColor = playerTrail.material.color;
            mazeRoot = transform.root;

            #endregion

        }

        void GetColliders()
        {
            pointsRoot = transform.Find("path").GetComponent<Transform>();
            colliders = pointsRoot.GetComponentsInChildren<SphereCollider>();
        }


        //initialize
        public void StartPlayer()
        {

            //set position, scale
            mazePlayer.transform.position = startPosition.transform.position;
            mazePlayer.transform.localScale = Vector3.zero;


            mp.lockedUp = startP.lockUp;
            mp.lockedDown = startP.lockDown;
            mp.lockedRight = startP.lockRight;
            mp.lockedLeft = startP.lockLeft;
            startP.transform.GetComponent<SphereCollider>().enabled = false;
            startP.LoopCircle();


            endPosition.transform.GetComponent<Point>().LoopCircle();

            mazePlayer.transform.gameObject.SetActive(true);

            //start looping circle


            //set animation
            mazePlayer.DOScale(initialScale, animationSpeed).SetEase(easeType).OnComplete(()=> playerTrail.time = 1000);


        }

        //player starterd
        void GameStarted()
        {

            Point p;
            p = startPosition.transform.GetComponent<Point>();
            p.PlayOnce();

            print("game started");
        }


        //reset player
        void PlayerReset()
        {
            //trail
            mazePlayer.DOScale(Vector3.zero, animationSpeed).SetEase(easeType).OnComplete(()=> PlayerResDelay());
            EnableColliders();

        }
        void PlayerResDelay()
        {
            mazePlayer.gameObject.SetActive(false);
            playerTrail.material.color = initialColor;
            playerTrail.time = 0;

            // reset directions
            mp.currentDirection = MazePlayer.CurrentDirection.start;
            mp.lockedLeft = false;
            mp.lockedRight = false;
            mp.lockedDown = false;
            mp.lockedUp = false;

            mp.playerMovedFirstTime = false;

            StartPlayer();
        }

        void ResetOnComplete()
        {

            mazePlayer.DOScale(Vector3.zero, animationSpeed).SetEase(easeType).OnComplete(() => ResComplete());
        }

        void ResComplete()
        {
            transform.gameObject.SetActive(false);
        }

        public void QuitInteraction()
        {
            GameManager.Instance.disableInput = false;
            mp.transform.gameObject.SetActive(false);

            playerTrail.material.color = initialColor;
            playerTrail.time = 0;

            // reset directions
            mp.currentDirection = MazePlayer.CurrentDirection.start;
            mp.lockedLeft = false;
            mp.lockedRight = false;
            mp.lockedDown = false;
            mp.lockedUp = false;

            mp.playerMovedFirstTime = false;

            foreach (Collider c in colliders)
            {
                c.enabled = true;

                if(c.GetComponentInChildren<Point>().getSprite == true)
                {
                    SpriteRenderer s;
                    s = c.GetComponentInChildren<SpriteRenderer>();
                    s.gameObject.SetActive(false);
                }
            }

        }

        public void EnableColliders()
        {
            foreach (SphereCollider cs in colliders)
            {
                cs.enabled = true;
            }
        }


        public void MazeComplete()
        {
            
            playerTrail.material.color = Color.green;
            mazeSprite.gameObject.SetActive(false);
            onMazeComplete.Run();
            ResetOnComplete();
            ih.ResetInput();
            GameManager.Instance.disableInput = false;
            if(openDoor)
            Destroy(mazeRoot.gameObject);
            mazeRoot.transform.Find("MazeDefault").GetComponent<Transform>().gameObject.SetActive(false);
            showSprite.SetActive(true);

        }

        public void WrongPath()
        {
            playerTrail.material.color = Color.red;
            PlayerReset();

            Point p;
            p = startPosition.transform.GetComponent<Point>();
            p.spriteObject.color = Color.red;

            //set color start point


        }

        void PlayerInactiveTimer()
        {

            if (mp.currentDirection == MazePlayer.CurrentDirection.idle)
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
                if (currentTime <= 0)
                {
                    currentTime = startTime;
                    PlayerReset();
                    isRunning = false;
                    print("timeExpired");
                }
            }

        }





    }

}


