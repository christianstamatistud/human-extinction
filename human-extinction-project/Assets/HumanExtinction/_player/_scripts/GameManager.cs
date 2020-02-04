using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;


namespace CS
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [BoxGroup("Game Manager")][ReadOnly] public bool lockCursor;
        [BoxGroup("Game Manager")] [ReadOnly] public bool disableInput;
        [BoxGroup("Game Manager")] [ReadOnly] public bool onMainMenu;
        

        //Player Ui
        [BoxGroup("Game Manager")] [ReadOnly] public bool toggleInventory;
        UI_Inventory uiInventory;
        UI_CrossHair uiCrossHair;
        TextMeshProUGUI displayInfo;

        //Pause Menu
        [BoxGroup("Game Manager")] [ReadOnly] public bool pauseGame;
        UI_PauseMenu uiPauseGame;
        [HideInInspector]public InteractiveController interactiveController;

        //Audio
        AudioSource aSource;
        [BoxGroup("Audio")] public AudioClip openPause;

        

        private void Awake()
        {
            SetReferences();
        }


        void SetReferences()
        {
            aSource = GetComponent<AudioSource>();
            Instance = this;
            uiInventory = FindObjectOfType<UI_Inventory>();
            uiPauseGame = FindObjectOfType<UI_PauseMenu>();
            uiCrossHair = FindObjectOfType<UI_CrossHair>();
            displayInfo = uiCrossHair.GetComponentInChildren<TextMeshProUGUI>();
            onMainMenu = true;

        }

        public void DisplayInfo(string info)
        {
            displayInfo.text = info;
            displayInfo.enabled = true;
            StartCoroutine(Delay());
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(3);
            displayInfo.enabled = false;

        }

        public void ToggleCursorState()
        {
            lockCursor = !lockCursor;

            if (lockCursor)
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

        public void TogglePause()
        {
            if (!uiPauseGame.animationPlaying)
            {
                pauseGame = !pauseGame;

                if (pauseGame)
                {
                    if (!toggleInventory)
                    {
                        ToggleCursorState();
                    }
                    if(openPause != null)
                    aSource.PlayOneShot(openPause);
                    uiPauseGame.TogglePauseMenu();
                    uiCrossHair.ToggleCrossHair(false);
                    Time.timeScale = 0;
                }
                else
                {
                    
                    Time.timeScale = 1;
                    if (openPause != null)
                        aSource.PlayOneShot(openPause);
                    uiPauseGame.TogglePauseMenu();
                    uiCrossHair.ToggleCrossHair(true);
                    if (!toggleInventory)
                    {
                        ToggleCursorState();
                    }
                }
            }

        }

        public void ToggleInventory()
        {
            toggleInventory = !toggleInventory;
            disableInput = !disableInput;
            if (toggleInventory)
            {
                Vector3 desiredPosition = new Vector3(0, -360, 0);
                uiInventory.ToggleInventoryUi(desiredPosition);
                uiCrossHair.ToggleCrossHair(false);
            }
            else
            {
                Vector3 desiredPosition = new Vector3(0, -715, 0);
                uiInventory.ToggleInventoryUi(desiredPosition);
                uiCrossHair.ToggleCrossHair(true);

            }
        }

        public void ChrossHair(bool c)
        {
            uiCrossHair.ToggleCrossHair(c);
        }




    }

}

