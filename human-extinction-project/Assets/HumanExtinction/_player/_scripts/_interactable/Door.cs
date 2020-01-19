using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace CS
{
    public class Door : MonoBehaviour
    {
        public Transform doorTransform;

        Sequence openSequence;
        Sequence closeSequence;
        
        public bool isOpen;


        private void Awake()
        {
            doorTransform = transform.Find("door").GetComponent<Transform>();
        }

        public void OpenDoor()
        {

            for (int i = 0; i < Inventory.instance.itemList.Count; i++)
            {
                if (Inventory.instance.itemList[i].itemType == Item.ItemType.Key)
                {
                    openSequence.Append(doorTransform.DOLocalMove(new Vector3(4, 3, 11), 0.3f));
                    openSequence.OnComplete(() => isOpen = true);
                    Debug.Log("Open");
                }
            }

            Debug.Log("No key");


        }

        public void ClosDoor()
        {
            if (isOpen)
            {
                print("close door");
                isOpen = false;
            }
        }
    }

}

