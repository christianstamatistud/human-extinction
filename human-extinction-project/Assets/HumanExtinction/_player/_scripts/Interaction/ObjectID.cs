using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CS
{
    public class ObjectID : MonoBehaviour
    {
        Camera m_Camera;
        InteractiveObject m_interactive;

        public TextMeshProUGUI info;
        public Image textBackground;
        public Image border;
        public Color uiColor;

        private void Awake()
        {
            SetReferences();
        }

        private void Start()
        {
            info.text = m_interactive.Info;

        }

        void Update()
        {
            transform.LookAt(m_Camera.transform.position);

        }


        void SetReferences()
        {
            m_Camera = FindObjectOfType<Camera>();
            m_interactive = GetComponentInParent<InteractiveObject>();
        }

        void HandleUiColor(Color col)
        {
            textBackground.color = col;
            border.color = col;
        }
    }

}

