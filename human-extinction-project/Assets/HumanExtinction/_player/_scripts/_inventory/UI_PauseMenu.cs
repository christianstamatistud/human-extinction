using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


namespace CS
{
    public class UI_PauseMenu : MonoBehaviour
    {
        Transform background;
        Transform menuPanel;
        InputHandler inputHandler;

        Image backgroundImage;

        public bool animationPlaying;

        Sequence openSequence;
        Sequence closeSequence;


        private void Awake()
        {
            background = transform.Find("background").GetComponent<Transform>();
            backgroundImage = background.GetComponent<Image>();
            menuPanel = transform.Find("menu_panel").GetComponent<Transform>();
            menuPanel.localScale = Vector3.zero;
            inputHandler = FindObjectOfType<InputHandler>();

        }



        public void TogglePauseMenu()
        {

            if (GameManager.Instance.pauseGame)
            {
                openSequence = DOTween.Sequence().SetUpdate(true);

                openSequence.Append(backgroundImage.DOFade(0.8f, 0.15f).SetEase(Ease.InSine));
                openSequence.Append(menuPanel.DOScale(Vector3.one, 0.3f).SetEase(Ease.InSine));

                openSequence.OnStart(() => StartOpenAnimation()).OnComplete(() => animationPlaying = false);

            }
            else
            {
                closeSequence = DOTween.Sequence().SetUpdate(true);

                closeSequence.Append(backgroundImage.DOFade(0f, 0.15f).SetEase(Ease.InSine));
                closeSequence.Append(menuPanel.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InSine));
                closeSequence.OnStart(() => animationPlaying = true).OnComplete(() => EndCloseAnimation());

            }
            inputHandler.ResetInput();



        }


        void StartOpenAnimation()
        {
            animationPlaying = true;
            ToggleMenuGameObjects(true);
        }

        void EndCloseAnimation()
        {
            animationPlaying = false;
            ToggleMenuGameObjects(false);

        }

        public void ToggleMenuGameObjects(bool status)
        {
            background.gameObject.SetActive(status);
            menuPanel.gameObject.SetActive(status);
            print("activate");
        }
    }
}
