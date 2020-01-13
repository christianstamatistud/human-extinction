using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    private Vector3 m_offset;
    private float m_mouseZCoord;
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        m_mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        m_offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        // 2d coordinates of mouse
        Vector3 mousePoint = Input.mousePosition;

        // z coordinates
        mousePoint.z = m_mouseZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + m_offset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
    }

}
