using UnityEngine;
using NaughtyAttributes;
using System.Collections;


namespace CS
{
    public class GameManager : MonoBehaviour
    {
        InputManager m_inputManager;

        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] bool m_lockCursor;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] bool m_gamePaused;


        #region BuiltIn Methods
        private void Awake()
        {
            GetReferences();
            ToggleCursorState();
        }

        private void OnEnable()
        {
            m_inputManager.escape += TogglePause;
        }

        private void OnDisable()
        {
            m_inputManager.escape -= TogglePause;
        }
        #endregion

        #region Custom Methods
        void GetReferences()
        {
            m_inputManager = GetComponent<InputManager>();
        }

        public void TogglePause()
        {
            m_gamePaused = !m_gamePaused;

            if (m_gamePaused)
            {
                m_inputManager.DisableInput = true;
                Time.timeScale = 0;
                m_inputManager.ResetInput();
                ToggleCursorState();
                print("Pause Enabled");
            }
            else
            {
                ToggleCursorState();
                m_inputManager.DisableInput = false;
                Time.timeScale = 1;

            }
        }


        public void ToggleCursorState()
        {
            m_lockCursor = !m_lockCursor;

            if (m_lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        #endregion


    }

}

