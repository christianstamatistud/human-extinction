using UnityEngine;
using NaughtyAttributes;

namespace CS
{
    public class CameraController : MonoBehaviour
    {
        InputManager m_inputManager;
        Transform m_player;

        Vector2 m_smoothMouseInput;

        [BoxGroup("Mouse Look")] [SerializeField] float sensitivity = 5f;
        [BoxGroup("Mouse Look")] [SerializeField] float smooth = 5f;


        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] float m_mouseX;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] float m_mouseY;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] float xRotation;


        // Start is called before the first frame update
        private void Awake()
        {
            GetReference();

        }

        private void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            SmoothInput();
            MouseLook();

        }

        void GetReference()
        {
            m_inputManager = FindObjectOfType<InputManager>();
            m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        }

        void SmoothInput()
        {
            m_smoothMouseInput = Vector2.Lerp(m_smoothMouseInput, m_inputManager.MouseInputVector, Time.deltaTime * smooth);
        }

        void MouseLook()
        {
            m_mouseX = m_smoothMouseInput.x * sensitivity * Time.deltaTime;
            m_mouseY = m_smoothMouseInput.y * sensitivity * Time.deltaTime;

            xRotation -= m_mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            m_player.Rotate(Vector3.up * m_mouseX);
        }

        void CameraBlur()
        {


        }

    }

}

