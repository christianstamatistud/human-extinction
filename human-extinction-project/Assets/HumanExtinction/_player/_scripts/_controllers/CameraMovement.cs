using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class CameraMovement : MonoBehaviour
    {
        // Do HeadBob
        public Transform m_camera;
        private Vector3 m_cameraStartPos;
        private PlayerController m_playerController;

        private Vector3 targetBobPosition;
        private float movementCounter;
        private float idleCounter;


        InputManager m_inputManager;
        Vector2 _mouseAbsolute;
        Vector2 _smoothMouse;

        public GameObject characterBody;

        [SerializeField]
        private Vector2 clampInDegrees = new Vector2(360, 180);
        [SerializeField]
        private Vector2 sensitivity = new Vector2(2, 2);
        [SerializeField]
        private Vector2 smoothing = new Vector2(3, 3);
        [SerializeField]
        private Vector2 targetDirection;
        [SerializeField]
        private Vector2 targetCharacterDirection;

        void Start()
        {
            m_cameraStartPos = m_camera.localPosition;
            m_inputManager = FindObjectOfType<InputManager>();
            m_playerController = FindObjectOfType<PlayerController>();

            // Set target direction to the camera's initial orientation.
            targetDirection = transform.localRotation.eulerAngles;

            // Set target direction for the character body to its inital state.
            if (characterBody)
                targetCharacterDirection = characterBody.transform.localRotation.eulerAngles;
        }

        void Update()
        {
            
            if(m_playerController.status == Status.moving)
            {
                HeadBob(movementCounter, 0.05f, 0.05f);
                movementCounter += Time.deltaTime*8;
                m_camera.localPosition = Vector3.Lerp(m_camera.localPosition, targetBobPosition, Time.deltaTime * 8f);

            }
            else
            {
                HeadBob(idleCounter, 0.015f, 0.015f);
                idleCounter += Time.deltaTime;
                m_camera.localPosition = Vector3.Lerp(m_camera.localPosition, targetBobPosition, Time.deltaTime * 2f);

            }

            // Allow the script to clamp based on a desired target value.
            var targetOrientation = Quaternion.Euler(targetDirection);
            var targetCharacterOrientation = Quaternion.Euler(targetCharacterDirection);

            // Get raw mouse input for a cleaner reading on more sensitive mice.
            var mouseDelta = new Vector2(m_inputManager.MouseInputVector.x, m_inputManager.MouseInputVector.y);
            // Scale input against the sensitivity setting and multiply that against the smoothing value.
            mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

            // Interpolate mouse movement over time to apply smoothing delta.
            _smoothMouse.x = Mathf.Lerp(_smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
            _smoothMouse.y = Mathf.Lerp(_smoothMouse.y, mouseDelta.y, 1f / smoothing.y);

            // Find the absolute mouse movement value from point zero.
            _mouseAbsolute += _smoothMouse;

            // Clamp and apply the local x value first, so as not to be affected by world transforms.
            if (clampInDegrees.x < 360)
                _mouseAbsolute.x = Mathf.Clamp(_mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);

            // Then clamp and apply the global y value.
            if (clampInDegrees.y < 360)
                _mouseAbsolute.y = Mathf.Clamp(_mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);

            transform.localRotation = Quaternion.AngleAxis(-_mouseAbsolute.y, targetOrientation * Vector3.right) * targetOrientation;

            // If there's a character body that acts as a parent to the camera
            if (characterBody)
            {
                var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, Vector3.up);
                characterBody.transform.localRotation = yRotation * targetCharacterOrientation;
            }
            else
            {
                var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
                transform.localRotation *= yRotation;
            }
        }


        void HeadBob(float p_z, float p_x_intensity, float p_y_intensity)
        {
            targetBobPosition = m_cameraStartPos + new Vector3(Mathf.Cos(p_z) * p_x_intensity, Mathf.Sin(p_z*2) * p_y_intensity, m_cameraStartPos.z);
        }

    }

}

