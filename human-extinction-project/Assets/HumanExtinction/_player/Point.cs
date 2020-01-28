using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int index = 0;

    //ray
    public float raySize = 0.3f;

    //direction
    public bool lockUp;
    public bool lockDown;
    public bool lockLeft;
    public bool lockRight;

    //win or lose
    public bool win;
    public bool gameOver;
}
