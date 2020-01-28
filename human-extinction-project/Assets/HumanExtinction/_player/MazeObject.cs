using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeObject : MonoBehaviour
{



    public CircleCollider2D[] colliders;
    public Transform startPosition;
    public GameObject playerPrefab;

    public Transform input;
    public Transform output;

    public bool hasPower;
    FollowThePath player;

    private void OnEnable()
    {
        colliders = transform.Find("path").GetComponentsInChildren<CircleCollider2D>();
        player = GetComponentInChildren<FollowThePath>();
        player.enabled = true;
        player.resetColliders += EnableColliders;

    }

    private void OnDisable()
    {
        player.resetColliders -= EnableColliders;
        player.enabled = false;

    }


    public void EnableColliders()
    {
        foreach (CircleCollider2D cs in colliders)
        {
            cs.enabled = true;
        }

        Point p;
        p = startPosition.GetComponent<Point>();
        player.lockedDown = p.lockDown;
        player.lockedLeft = p.lockLeft;
        player.lockedRight= p.lockRight;
        player.lockedUp = p.lockUp;
        startPosition.GetComponent<CircleCollider2D>().enabled = false;
    }


    public void PuzzleComplete()
    {
        //activate output
    }

    public void ResetPuzzle()
    {
        //instanciate
        //enable
    }

}
