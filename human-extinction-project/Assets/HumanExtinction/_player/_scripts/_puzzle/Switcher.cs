using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class Switcher : MonoBehaviour
    {
        public string letter;
        Renderer r;
        public SwitchManager sm;

        private void Awake()
        {
            r = GetComponentInChildren<Renderer>();
            sm = FindObjectOfType<SwitchManager>();
        }

        private void OnEnable()
        {
            sm.resetTerminal += ResetSwitcher;
        }
        private void OnDisable()
        {
            sm.resetTerminal -= ResetSwitcher;

        }

        public void ResetSwitcher()
        {
            r.material.color = Color.red;
        }


        public void SetLetter()
        {
            SwitchManager.Instance.AddLetter(letter);
            r.material.color = Color.green;
        }




    }

}

