using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractable
{

    public string Info;
    public bool IsInteractable;
    public bool IsPickable;
    public bool CanLink;
    public string m_objectName { get => m_objectName ; set => Info = value; }
    public bool m_isInteractable { get => m_isInteractable; set => IsInteractable = value; }
    public bool m_isPickable { get => m_isPickable; set => IsPickable = value; }
    public bool m_CanLink { get => m_CanLink; set => CanLink = value; }

    public void OnAction()
    {
        if (IsInteractable)
        {
            Destroy(gameObject);
            Debug.Log("InteractiveObject");
        }

        if (IsPickable)
        {
            Debug.Log("Pickup Object");
        }

        if (CanLink)
        {
            Debug.Log("Link Function");
        }

    }
}
