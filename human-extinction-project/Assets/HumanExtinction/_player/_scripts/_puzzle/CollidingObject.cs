using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CS
{

    public class CollidingObject : MonoBehaviour
    {

        CollisionDetection cd;
        private void Awake()
        {
            cd = GetComponentInParent<CollisionDetection>();
        }

        public bool leftObject;
        public bool rightObject;


        private void OnTriggerEnter(Collider other)
        {

            if(other.gameObject.layer == 10)
            {

                if (leftObject)
                {
                    cd.leftDetected = leftObject;
                }

                if (rightObject)
                {
                    cd.rightDetected = rightObject;
                }

            }

        }


        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == 10)
            {

                if (leftObject)
                {
                    cd.leftDetected = false;
                }

                if (rightObject)
                {
                    cd.rightDetected = false;
                }

            }

        }

    }

}


