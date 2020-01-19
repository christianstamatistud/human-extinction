using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CS
{

    public class UI_CrossHair : MonoBehaviour
    {

        Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void ToggleCrossHair(bool activeState)
        {
            image.enabled = activeState;
        }
    }

}

