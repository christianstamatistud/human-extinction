using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using System.Collections;

namespace CS
{
    public class TweenController : MonoBehaviour
    {
        InputManager m_inputManager;

        [BoxGroup("Settings")] [SerializeField] private bool m_ToggleAnimation;
        [BoxGroup("Settings")] [SerializeField] private float m_duration = 1;
        [BoxGroup("Settings")] [SerializeField] private Ease easeTyepe = Ease.InOutSine;
       


        [BoxGroup("Transform")] public DesiredTransform m_DsiredTransform = DesiredTransform.Move;

        [BoxGroup("Transform")] [SerializeField] private Vector3 m_move; //desired move
        [BoxGroup("Transform")] [SerializeField] private Vector3 m_rotate; //desired move
        [BoxGroup("Transform")] [SerializeField] private Vector3 m_scale; //desired move

        private Vector3 m_lastMove; //desired move
        private Vector3 m_lastRotate; //desired move
        private Vector3 m_lastScale; //desired move

        private bool doOnce = true;

        private void Awake()
        {
            m_inputManager = FindObjectOfType<InputManager>();

        }
        private void OnEnable()
        {
            m_inputManager.escape += ToggleAnimation;
        }

        private void OnDisable()
        {
            m_inputManager.escape -= ToggleAnimation;

        }

        public enum DesiredTransform
        {
            Move,
            Rotate,
            Scale

        }

        private void Start()
        {
            m_lastMove = transform.position;
            m_lastRotate = transform.rotation.eulerAngles;
            m_lastScale = transform.localScale;

        }


        private void Update()
        {
            if (m_ToggleAnimation)
            {
                StartAnimation();
            }
            else
            {
                QuitAnimation();
            }


        }


        public void ToggleAnimation()
        {
            m_ToggleAnimation = !m_ToggleAnimation;
        }

        void StartAnimation()
        {
            easeTyepe = Ease.InOutSine;

            if (m_DsiredTransform == DesiredTransform.Move)
            {
                transform.DOMove(m_move, m_duration).SetEase(easeTyepe).SetUpdate(UpdateType.Late, true);
            }


            if (m_DsiredTransform == DesiredTransform.Rotate)
            {
                transform.DORotate(m_rotate, m_duration).SetEase(easeTyepe).SetUpdate(UpdateType.Late, true);
            }


            if (m_DsiredTransform == DesiredTransform.Scale)
            {
                transform.DOScale(m_scale, m_duration).SetEase(easeTyepe).SetUpdate(UpdateType.Late, true);
            }

        }

        private void QuitAnimation()
        {
            easeTyepe = Ease.OutSine;

            if (m_DsiredTransform == DesiredTransform.Move)
            {
                transform.DOMove(m_lastMove, m_duration).SetEase(easeTyepe).SetUpdate(UpdateType.Late, true);
            }


            if (m_DsiredTransform == DesiredTransform.Rotate)
            {
                transform.DORotate(m_rotate, m_duration).SetEase(easeTyepe).SetUpdate(UpdateType.Late, true);
            }

            if (m_DsiredTransform == DesiredTransform.Scale)
            {
                transform.DOScale(m_lastScale, m_duration).SetEase(easeTyepe).SetUpdate(UpdateType.Late, true);
            }


        }

        /*
         
                  IEnumerator Wait(int waitsec)
        {
            yield return new WaitForSeconds(waitsec);
            m_canvas.enabled = false;
            StartCoroutine(Wait(0));
            print("Helloooo");
        }   
             
             
             
             
             
             */



    }


}