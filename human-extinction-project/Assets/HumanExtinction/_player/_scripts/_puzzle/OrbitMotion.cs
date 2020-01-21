using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class OrbitMotion : MonoBehaviour
    {
        public Transform orbitingObject;
        public Ellipse orbitPath;
        public CollisionDetection cd;



        [Range(0f, 1f)]
        public float orbitProgress = 0f;
        public float orbitPeriod = 3f;
        public bool orbitActive;

        public float dir = 1;

        private void Start()
        {
            if (orbitingObject == null)
            {
                orbitActive = false;
                return;
            }
            SetOrbitingObjectPosition();

            //set orbit position
            //start orbbit animation (if orbit is active)

        }

        private void OnEnable()
        {
            cd.refreshDetection += OnCollisionAction;
        }
        private void OnDisable()
        {
            cd.refreshDetection -= OnCollisionAction;

        }

        private void Update()
        {

            AnimateOrbit(dir);

            if(orbitActive && cd.rightDetected || cd.leftDetected)
            {
                orbitActive = false;
            }

        }

        void SetOrbitingObjectPosition()
        {
            Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
            orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
        }

        void AnimateOrbit(float direction)
        {
            if (orbitActive)
            {
                float orbitSpeed = direction / orbitPeriod;
                orbitProgress += Time.deltaTime * orbitSpeed;
                orbitProgress %= 1f;
                SetOrbitingObjectPosition();
            }

        }

        public void ToggleOrbitMotion()
        {
            orbitActive = !orbitActive;

        }


        void OnCollisionAction()
        {
            if (cd.rightDetected && !cd.leftDetected)
            {
                //move left
                dir = 1f;
            }

            if (!cd.rightDetected && cd.leftDetected)
            {
                //move left
                dir = -1f;
            }

        }
    }


}
