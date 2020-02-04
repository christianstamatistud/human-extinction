using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Hud : MonoBehaviour
{
    TextMeshPro tmpro;

    private void Awake()
    {
        tmpro = GetComponentInChildren<TextMeshPro>();
    }
}
