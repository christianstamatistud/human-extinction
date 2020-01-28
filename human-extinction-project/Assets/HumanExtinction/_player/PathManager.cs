using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{


    CircleCollider2D[] colliders;
    public Transform startPosition;
    public GameObject playerPrefab;
    public Transform root;


    private void Awake()
    {
        colliders = GetComponentsInParent<CircleCollider2D>();
        root = GetComponentInParent<Transform>().root;
    }

    private void Start()
    {
        BeginPuzzle();
    }

    public void BeginPuzzle()
    {
        Instantiate();
    }

    public void DisableColliders()
    {
        foreach (CircleCollider2D cs in colliders)
        {
            cs.enabled = false;
        }
    }

    public void EnableColliders()
    {
        foreach (CircleCollider2D cs in colliders)
        {
            cs.enabled = true;
        }

    }


    void Instantiate()
    {
        Instantiate(playerPrefab, startPosition.position, Quaternion.identity);

        GameObject.Find("PlayerMaze(Clone)").transform.parent = root.transform;
        
    }

    public void Win()
    {

    }

    public void ResetPuzzle()
    {
        //instanciate
        //enable
    }
}
