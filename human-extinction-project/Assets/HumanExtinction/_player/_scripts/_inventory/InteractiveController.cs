using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace CS
{
    public class InteractiveController : MonoBehaviour
    {
        private Inventory inventory;
        private UI_Inventory uiInventory;
        private InputHandler inputHandler;

        


        //Ray
        [SerializeField] private float sphereRadius = 0.2f;
        [SerializeField] private float maxDistance = 2;
        [SerializeField] private LayerMask layerMask;
        private Vector3 rayOrigin;
        private Vector3 rayDirection;
        private float currenthitDistance;

        //Hover
        public Renderer[] rs;
        public Material hoverMaterial;
        public Material lastMaterial;

        private void Awake()
        {
            inventory = new Inventory();
            uiInventory = FindObjectOfType<UI_Inventory>();
            inputHandler = FindObjectOfType<InputHandler>();
            //PASSING INVENTORY OBJECT TO UI SCRIPT

        }

        private void OnEnable()
        {
            inputHandler.playerInteract += InventoryItemPickup;
            inputHandler.playerInteract += CheckInteractableItems;
        }

        private void OnDisable()
        {
            inputHandler.playerInteract -= InventoryItemPickup;
            inputHandler.playerInteract -= CheckInteractableItems;

        }

        private void Start()
        {
            uiInventory.SetInventory(inventory);

        }



        void InventoryItemPickup()
        {
            rayOrigin = transform.position;
            rayDirection = transform.forward;

            RaycastHit hit;
            bool hitSomething = Physics.SphereCast(rayOrigin, sphereRadius, rayDirection, out hit, maxDistance, layerMask);
            
            if (hitSomething)
            {
                currenthitDistance = hit.distance;
                //Get Reference of hit object
                ItemWorld itemWorld = hit.transform.GetComponent<ItemWorld>();
                if (itemWorld != null)
                {
                    inventory.AddItem(itemWorld.GetItem());
                    Debug.Log(inventory.itemList.Count);
                    itemWorld.DestroySelf();
                }

            }
            else
            {
                currenthitDistance = maxDistance;
            }
        }


        void CheckInteractableItems()
        {
            rayOrigin = transform.position;
            rayDirection = transform.forward;

            RaycastHit hit;
            bool hitSomething = Physics.SphereCast(rayOrigin, sphereRadius, rayDirection, out hit, maxDistance, layerMask);

            if (hitSomething)
            {

                //ObjectSelection(hit);

                // Interac with doors
                if (hit.transform.GetComponent<Door>())
                {
                    Door interaction;
                    interaction = hit.transform.GetComponent<Door>();

                    if(interaction != null)
                    {
                        interaction.OpenDoor();
                    }
                }

                //interact switcher
                if (hit.transform.GetComponent<Switcher>())
                {
                    Switcher sw;
                    sw = hit.transform.GetComponent<Switcher>();

                    if (sw !=null)
                    {

                        sw.SetLetter();

                    }

                }

                //if interact switcher manager
                if (hit.transform.GetComponent<SwitchManager>())
                {
                    SwitchManager sm;
                    sm = hit.transform.GetComponent<SwitchManager>();

                    if (sm != null)
                    {
                        sm.GuessWord();
                    }

                }

                //interact with maze
                if (hit.transform.GetComponentInChildren<MazeObject>())
                {
                    MazeObject mo;
                    mo = hit.transform.GetComponentInChildren<MazeObject>();

                    if (mo!=null)
                    {
                        GameManager.Instance.disableInput = true;
                        inputHandler.ResetInput();
                        mo.StartPlayer();
                        mo.isInteractive = true;
                        print("start_player");
                    }

                }
            }
            else
            {
                ClearSelection();

            }

        }



        void ObjectSelection(RaycastHit currentRay)
        {
            rs = currentRay.transform.gameObject.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in rs)
            {
                r.material.SetColor("_BaseColor", Color.red);
            }

        }

        void ClearSelection()
        {
            if(rs != null)
            {
                foreach (Renderer r in rs)
                {
                    r.material.SetColor("_BaseColor", Color.white);
                }
                rs = null;
            }

        }



        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Debug.DrawLine(rayOrigin, rayOrigin + rayDirection * currenthitDistance);
            Gizmos.DrawWireSphere(rayOrigin + rayDirection * currenthitDistance, sphereRadius);

        }
    }

}

