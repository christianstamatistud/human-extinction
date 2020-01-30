using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace CS
{
    public class MazeObject : MonoBehaviour
    {



        private SphereCollider[] colliders;
        public Transform mazeCamera;
        public Transform startPosition;
        private FollowThePath playerPrefab;
        public Renderer MeshRenderer;
        private SpriteRenderer maze;
        public Transform cameraHolder;

        public bool hasPower;
        public bool mazeComplete;

        private void Awake()
        {
            playerPrefab = GetComponentInChildren<FollowThePath>();
            playerPrefab.enabled = true;
            maze = transform.Find("maze_sprite").GetComponent<SpriteRenderer>();
            colliders = transform.Find("path").GetComponentsInChildren<SphereCollider>();
            cameraHolder = FindObjectOfType<InteractiveController>().GetComponent<Transform>();


        }

        private void OnEnable()
        {
            playerPrefab.resetColliders += EnableColliders;
            playerPrefab.puzzleComplete += PuzzleComplete;
        }


        public void StartMaze()
        {
            playerPrefab.transform.GetComponent<FollowThePath>().StartPlayer();
            

        }

        private void OnDisable()
        {
            playerPrefab.resetColliders -= EnableColliders;
            playerPrefab.puzzleComplete -= PuzzleComplete;

        }


        public void EnableColliders()
        {
            foreach (SphereCollider cs in colliders)
            {
                cs.enabled = true;
            }

            Point p;
            p = startPosition.GetComponent<Point>();
            playerPrefab.lockedDown = p.lockDown;
            playerPrefab.lockedLeft = p.lockLeft;
            playerPrefab.lockedRight = p.lockRight;
            playerPrefab.lockedUp = p.lockUp;
            startPosition.GetComponent<SphereCollider>().enabled = false;
        }


        public void PuzzleComplete()
        {

            mazeComplete = true;
            MeshRenderer.materials[2].SetColor("_BaseColor", Color.green);
            maze.enabled = false;
            Destroy(playerPrefab.gameObject);


            //rivedere
            Transform cpt;
            cpt = mazeCamera.GetComponent<Transform>();
            cpt.SetParent(null);
            cpt.DORotate(cameraHolder.transform.rotation.eulerAngles, 1);
            cpt.DOMove(cameraHolder.transform.position, 1).OnComplete(() => cpt.SetParent(cameraHolder.transform));
            GameManager.Instance.disableInput = false;

            
        }



    }

}


