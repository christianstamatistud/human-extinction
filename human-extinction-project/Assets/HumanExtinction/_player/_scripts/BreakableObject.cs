using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CS
{
    public class BreakableObject : MonoBehaviour
    {

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision");
            Rigidbody rb = collision.transform.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddExplosionForce(100f, transform.position, 1f, 3.0F);

        }



    }

}

