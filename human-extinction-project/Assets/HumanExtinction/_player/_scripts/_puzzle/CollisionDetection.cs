using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class CollisionDetection : MonoBehaviour
    {
        public delegate void RefreshDetection();
        public event RefreshDetection refreshDetection;

        public bool leftDetected;
        public bool rightDetected;

        public Transform leftObject;
        public Transform rightObject;


        private void Update()
        {
            if(leftDetected || rightDetected)
            {
                StartCoroutine(ResetCheckers());

            }
        }

        IEnumerator ResetCheckers()
        {
            refreshDetection();
            yield return new WaitForSeconds(0.5f);
            print("corutine");
            leftDetected = false;
            rightDetected = false;
        }

    }


}
