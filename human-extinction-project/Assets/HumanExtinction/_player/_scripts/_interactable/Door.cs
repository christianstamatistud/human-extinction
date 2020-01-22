using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace CS
{
    public class Door : MonoBehaviour
    {
        public Transform doorOne;
        public Transform doorTwo;
        BoxCollider bc;

        Vector3 doorOneInitialPosition;
        Vector3 doorTwoInitialPosition;

        Sequence openSequence;

        
        public bool isOpen;
        public bool isUnlocked;

        private void Awake()
        {
            bc = GetComponent<BoxCollider>();
            doorOneInitialPosition = doorOne.transform.localPosition;
            doorTwoInitialPosition = doorTwo.transform.localPosition;
        }
        public void OpenDoor()
        {
            if (!isUnlocked)
            {
                for (int i = 0; i < Inventory.instance.itemList.Count; i++)
                {

                    if (Inventory.instance.itemList[i].itemType == Item.ItemType.Key)
                    {
                        Item myItem;
                        myItem = Inventory.instance.itemList[i];

                        openSequence.Append(doorOne.DOLocalMove(new Vector3(-2.6f, 0, 0), 0.3f));
                        openSequence.Append(doorTwo.DOLocalMove(new Vector3(8, 0, -1), 0.3f));
                        openSequence.OnComplete(() => isOpen = true);
                        bc.isTrigger = true;
                        isUnlocked = true;
                        Inventory.instance.RemoveItem(myItem);
                        print("open door");
                    }

                }
                print("no Key");

            }
            else
            {
                openSequence.Append(doorOne.DOLocalMove(new Vector3(-2.6f, 0, 0), 0.3f));
                openSequence.Append(doorTwo.DOLocalMove(new Vector3(8, 0, -1), 0.3f));
                bc.isTrigger = true;
                openSequence.OnComplete(() => isOpen = true);
            }






        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                StartCoroutine(CloseAnimation());
            }
            
        }

        IEnumerator CloseAnimation()
        {
            yield return new WaitForSeconds(2f);

            openSequence.Append(doorOne.DOLocalMove(doorOneInitialPosition, 0.3f));
            openSequence.Append(doorTwo.DOLocalMove(doorTwoInitialPosition, 0.3f));
            openSequence.OnComplete(() => isOpen = false);
            bc.isTrigger = false;
        }

    }

}

