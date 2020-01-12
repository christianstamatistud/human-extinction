using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class InteractiveObject : MonoBehaviour, IInteractable
    {

        public string Info;


        public bool IsInteractable;
        public bool IsPickable;
        public bool ShowUi;
        public string m_objectName { get => m_objectName; set => Info = value; }
        public bool m_isInteractable { get => m_isInteractable; set => IsInteractable = value; }
        public bool m_isPickable { get => m_isPickable; set => IsPickable = value; }
        public bool showUi { get => showUi; set => ShowUi = value; }

        public void OnAction()
        {
            if (IsInteractable)
            {
                Debug.Log("InteractiveObject");
                Destroy(gameObject);
            }

            if (IsPickable)
            {
                Debug.Log("Pickup Object");
            }

            if (ShowUi)
            {
                Debug.Log("ShowUi");
            }

        }
    }


}

