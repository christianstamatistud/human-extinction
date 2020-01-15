using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CS
{
    public class PlayerInput : MonoBehaviour
    {
        InputManager m_inputManager;

        Vector2 m_smoothInputVector;

        public Vector2 input
        {
            get
            {
                Vector2 i = Vector2.zero;
                i.x = m_smoothInputVector.x;
                i.y = m_smoothInputVector.y;
                i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
                return i;
            }
        }

        public Vector2 down
        {
            get { return _down; }
        }

        public Vector2 raw
        {
            get
            {
                Vector2 i = Vector2.zero;
                i.x = m_inputManager.InputVector.x;
                i.y = m_inputManager.InputVector.y;
                i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
                return i;
            }
        }

        public bool run
        {
            get { return m_inputManager.isRunning; }
        }


        public bool crouch
        {
            get { return Input.GetKeyDown(KeyCode.C); }
        }

        public bool crouching
        {
            get { return m_inputManager.isCrouching; }
        }

      

        private Vector2 previous;
        private Vector2 _down;

        private int jumpTimer;
        private bool jump;

        void Start()
        {
            m_inputManager = FindObjectOfType<InputManager>();
            jumpTimer = -1;
        }

        void Update()
        {

            _down = Vector2.zero;
            if (raw.x != previous.x)
            {
                previous.x = raw.x;
                if (previous.x != 0)
                    _down.x = previous.x;
            }
            if (raw.y != previous.y)
            {
                previous.y = raw.y;
                if (previous.y != 0)
                    _down.y = previous.y;
            }

            m_smoothInputVector = Vector2.Lerp(m_smoothInputVector, m_inputManager.InputVector, 0.1f);
        }

        public void FixedUpdate()
        {
            if (!m_inputManager.isJumping)
            {
                jump = false;
                jumpTimer++;
            }
            else if (jumpTimer > 0)
                jump = true;
        }

        public bool Jump()
        {
            return jump;
        }

        public void ResetJump()
        {
            jumpTimer = -1;
        }
    }

}

