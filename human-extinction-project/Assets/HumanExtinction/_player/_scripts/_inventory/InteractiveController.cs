using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class InteractiveController : MonoBehaviour
    {
        private Inventory inventory;
        private UI_Inventory uiInventory;



        //Ray
        [SerializeField] private float sphereRadius = 0.2f;
        [SerializeField] private float maxDistance = 2;
        [SerializeField] private LayerMask layerMask;
        private Vector3 rayOrigin;
        private Vector3 rayDirection;
        private float currenthitDistance;

        private void Awake()
        {
            inventory = new Inventory();
            uiInventory = FindObjectOfType<UI_Inventory>();
            //PASSING INVENTORY OBJECT TO UI SCRIPT

        }
        private void Start()
        {
            uiInventory.SetInventory(inventory);

        }


        private void Update()
        {
            RaySphereCast();
        }

        void RaySphereCast()
        {
            rayOrigin = transform.position;
            rayDirection = transform.forward;

            RaycastHit hit;
            bool hitSomething = Physics.SphereCast(rayOrigin, sphereRadius, rayDirection, out hit, maxDistance, layerMask);
            
            if (hitSomething)
            {
                currenthitDistance = hit.distance;
                //Get Reference of hit object
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ItemWorld itemWorld = hit.transform.GetComponent<ItemWorld>();
                    if(itemWorld != null)
                    {
                        inventory.AddItem(itemWorld.GetItem());
                        Debug.Log(inventory.itemList.Count);
                        itemWorld.DestroySelf();
                    }

                }

            }
            else
            {
                currenthitDistance = maxDistance;
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

