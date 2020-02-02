
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;



namespace CS
{

    public class MainMenu : MonoBehaviour
    {
        public TMP_InputField inputField;
        Animator playerAnimator;

        private void Awake()
        {
            playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
        }
        private void OnGUI()
        {
            if (inputField != null)
            {
                if (Input.GetKeyDown(KeyCode.Return) && inputField.isFocused)
                {
                    print("submit");
                    if (inputField.text == "y")
                    {
                        StandUp();
                    }


                    
                }

            }
        }


        void StandUp()
        {
            playerAnimator.SetBool("standUp", true);
            GameManager.Instance.ToggleCursorState();
            gameObject.SetActive(false);

        }


    }


}

