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


        private Transform mazePlayer;
        [BoxGroup("Player")] public Transform startPosition;
        [BoxGroup("Player")] public float animationSpeed = 1;
        [BoxGroup("Player")] public Ease easeType;
        public bool isInteractive;
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
        MazePlayer mp;
        Vector3 initialScale;
        Color initialColor;
       

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
            PlayerInactiveTimer();
        }

        void GetReferences()
        {
            GetColliders();
            ih = FindObjectOfType<InputHandler>();

            #region Player References
            currentTime = startTime;
            mazePlayer = transform.Find("PlayerMaze").GetComponent<Transform>();
            mp = mazePlayer.GetComponent<MazePlayer>();
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

            //get first poin info
            Point p;
            p = startPosition.transform.GetComponent<Point>();
            mp.lockedUp = p.lockUp;
            mp.lockedDown = p.lockDown;
            mp.lockedRight = p.lockRight;
            mp.lockedLeft = p.lockLeft;
            p.transform.GetComponent<SphereCollider>().enabled = false;
            p.LoopCircle();

            foreach (SphereCollider c in colliders)
            {
                Point pt;
                pt = c.GetComponent<Point>();
                if (pt.endPoint)
                {
                    pt.LoopCircle();
                }
            }

            //start looping circle

            mazePlayer.transform.gameObject.SetActive(true);

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
            p.sprite.color = Color.red;

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


