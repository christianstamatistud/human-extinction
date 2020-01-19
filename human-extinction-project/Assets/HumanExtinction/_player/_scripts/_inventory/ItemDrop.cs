using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class ItemDrop : MonoBehaviour
    {
        private UI_Inventory uiInventory;

        private void Awake()
        {
            uiInventory = FindObjectOfType<UI_Inventory>();
            uiInventory.SetPlayer(this);
        }

        public Transform GetPosition()
        {
            return this.transform;
        }
    }

}

