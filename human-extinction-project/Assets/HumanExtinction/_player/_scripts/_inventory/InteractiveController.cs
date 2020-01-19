using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Renderer currentRenderer;
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
        }

        private void OnDisable()
        {
            inputHandler.playerInteract -= InventoryItemPickup;

        }
        private void Start()
        {
            uiInventory.SetInventory(inventory);

        }


        private void Update()
        {
            if(!GameManager.Instance.disableInput)
            CheckInteractableItems();
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
                ObjectSelection(hit);


                // Interac with doors
                if (hit.transform.GetComponent<Door>())
                {
                    Door interaction;
                    interaction = hit.transform.GetComponent<Door>();

                    if(interaction != null && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        interaction.OpenDoor();
                    }else if (interaction.isOpen)
                    {
                        interaction.ClosDoor();
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
            currentRenderer = currentRay.transform.GetComponentInChildren<Renderer>();
            currentRenderer.material.SetColor("_BaseColor", Color.red);

        }

        void ClearSelection()
        {
            if(currentRenderer != null)
            {
                currentRenderer.material.SetColor("_BaseColor", Color.white);
                currentRenderer = null;
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

