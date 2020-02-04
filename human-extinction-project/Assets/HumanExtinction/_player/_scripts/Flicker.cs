using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class Flicker : MonoBehaviour
    {
        MeshRenderer mr;
        Light l;

        public float minWaitTime;
        public float maxWaitTime;

        AudioSource aSource;
        public AudioClip[] LightFlicker;

        private void OnEnable()
        {
            mr = GetComponentInChildren<MeshRenderer>();
            l = GetComponentInChildren<Light>();
            aSource = GetComponent<AudioSource>();
            StartCoroutine(Flashing());
        }
        


        IEnumerator Flashing()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
                print("sound");
                aSource.clip = LightFlicker[Random.Range(0, LightFlicker.Length)];
                aSource.Play();
                l.enabled = !l.enabled;
                mr.enabled = !mr.enabled;

            }
        }

    }
}

