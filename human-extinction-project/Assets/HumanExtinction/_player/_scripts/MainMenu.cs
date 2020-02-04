
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.InputSystem;

namespace CS
{

    public class MainMenu : MonoBehaviour, Controls.IMainMenuActions
    {
        Controls c;
        Animator playerAnimator;

        private void Awake()
        {
            c = new Controls();
            c.MainMenu.SetCallbacks(this);
            playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            GameManager.Instance.onMainMenu = true;

        }

        private void OnEnable()
        {
            c.Enable();
        }

        private void OnDisable()
        {
            c.Disable();
        }


        public void OnStartGame(InputAction.CallbackContext context)
        {

            if (context.performed && GameManager.Instance.onMainMenu)
            {
                StandUp();
            }
        }


        void StandUp()
        {
            playerAnimator.SetBool("standUp", true);
            GameManager.Instance.ToggleCursorState();
            gameObject.SetActive(false);
            GameManager.Instance.onMainMenu = false;

        }

    }


}

