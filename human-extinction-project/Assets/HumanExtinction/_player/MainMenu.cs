
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;



namespace CS
{

    public class MainMenu : MonoBehaviour
    {
        public Camera playerCamera;
        public Camera menuCamera;
        public TMP_InputField inputField;
        public VolumeProfile vp;

        DepthOfField dp;

        private void Start()
        {
            GameManager.Instance.disableInput = true;

        }

        private void OnGUI()
        {
            if (inputField != null)
            {
                if (Input.GetKeyDown(KeyCode.Return) && inputField.isFocused)
                {
                    print("submit");
                    if (inputField.text == "y")
                        WakeUpAnimation();

                    //check if string is correct
                    //disable menu 
                    //enable black screen at end of anim
                    //disable camera - instantiate player
                    //set volume depth of field
                }

            }
        }


        private void Update()
        {


        }

        void WakeUpAnimation()
        {
            gameObject.SetActive(false);
            GameManager.Instance.ToggleCursorState();
            menuCamera.transform.DORotate(playerCamera.transform.rotation.eulerAngles, 5f).SetEase(Ease.OutBack);
            menuCamera.transform.DOMove(playerCamera.transform.position, 5f).SetEase(Ease.OutBack).OnComplete(() => OnInitializeGame());
        }


        void OnInitializeGame()
        {

            menuCamera.gameObject.SetActive(false);
            playerCamera.gameObject.SetActive(true);
            GameManager.Instance.disableInput = false;
            GameManager.Instance.onMainMenu = false;

        }
    }


}

