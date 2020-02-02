using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace CS
{
    public class Trigger : MonoBehaviour
    {
        [BoxGroup("Function")]public string runFunction;


        [BoxGroup("Actions")] public bool doorOpen;

        [BoxGroup("Connection")] public Transform output;
        [BoxGroup("Connection")] public Transform input;


        Door d;
        MazeObject mo;

        private void Awake()
        {
            if (doorOpen)
            {
                d = output.GetComponent<Door>();
            }

            mo = gameObject.GetComponentInChildren<MazeObject>();

        }



        public void Run()
        {
            if(doorOpen)
            d.Invoke(runFunction, 1f);
        }


    }
}

