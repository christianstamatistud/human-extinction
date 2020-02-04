using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

namespace CS
{
    public class PlayerAnimator : MonoBehaviour
    {
        CameraController cameraController;
        FirstPersonController fps;
        Animator anim;
        InputHandler input;
        bool isRunning;


        [BoxGroup("Stand Up")]public Transform cameraTransform;
        [BoxGroup("Stand Up")] public Transform playerHead;
        private Vector2 smoothInput;
        [BoxGroup("Audio")] public AudioSource source;
        [BoxGroup("Audio")] public AudioClip[] walking;
        [BoxGroup("Audio")] public AudioClip[] running;



        private void Awake()
        {
            
            input = FindObjectOfType<InputHandler>();
            anim = GetComponent<Animator>();
            fps = GetComponentInParent<FirstPersonController>();
            cameraController = FindObjectOfType<CameraController>();
            cameraTransform.SetParent(playerHead);
            cameraTransform.localScale = Vector3.one;
            cameraTransform.localRotation = new Quaternion(0, 0, 0, 0);
            cameraTransform.localPosition = new Vector3(-0.008f, 0.142f, 0.23f);

        }

        private void Update()
        {
            SmoothInput();
            SetAnimation();
        }

        void SmoothInput()
        {
            smoothInput = Vector2.Lerp(smoothInput, input.m_movementVector, Time.deltaTime * 5);
        }

        void SetAnimation()
        {
            if (input.isRunning)
            {
                anim.SetFloat("YAxis", smoothInput.y);

            }
            anim.SetFloat("YAxis", smoothInput.y / 2);
            anim.SetFloat("XAxis", smoothInput.x);
            
        }

        public void ActivatePlayer()
        {
            cameraTransform.SetParent(cameraController.transform.Find("Camera_Pivot"));

            cameraTransform.DOLocalMove(new Vector3(0,0,0.1f), 1);
            cameraTransform.DOLocalRotate(Vector3.zero, 1).OnComplete(() => EnablePlayerScripts());
            cameraTransform.localScale = Vector3.one;

            anim.SetBool("allowToMove", true);


        }

        void EnablePlayerScripts()
        {
            anim.SetBool("standUp", true);
            fps.enabled = true;
            cameraController.enabled = true;
        }
    }


}
