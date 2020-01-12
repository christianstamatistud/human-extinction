using UnityEngine;
using NaughtyAttributes;


namespace CS
{
    public class SelectionController : MonoBehaviour
    {
        [BoxGroup("Settings")] [SerializeField] public float padding = 1.2f;

        InteractiveController m_interactiveController;
        Camera m_camera;

        private void Awake()
        {
            m_interactiveController = FindObjectOfType<InteractiveController>();
            m_camera = Camera.main;
        }

        private void Update()
        {
            ToggleSelectionUi();
        }

        static Vector3[] screenSpaceCorners;
        void ToggleSelectionUi()
        {
            if(m_interactiveController.selectedObjectRoot != null)
            {
                //transform.DOScale(Vector3.one, m_duration).SetEase(Ease.InSine);
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    //SHOW INDICATOR
                    this.transform.GetChild(i).gameObject.SetActive(true);
                }

                //Object visuals in world space
                Bounds m_bounds = m_interactiveController.selectedObjectRoot.GetComponentInChildren<Renderer>().bounds;
               
                if(screenSpaceCorners == null)
                    screenSpaceCorners = new Vector3[8];

                //Convert 8 corners of our renderer's world space bounding box,
                screenSpaceCorners[0] = m_camera.WorldToScreenPoint(new Vector3(m_bounds.center.x + m_bounds.extents.x * padding, m_bounds.center.y + m_bounds.extents.y* padding, m_bounds.center.z + m_bounds.extents.z* padding));
                screenSpaceCorners[1] = m_camera.WorldToScreenPoint(new Vector3(m_bounds.center.x + m_bounds.extents.x* padding, m_bounds.center.y + m_bounds.extents.y* padding, m_bounds.center.z - m_bounds.extents.z* padding));
                screenSpaceCorners[2] = m_camera.WorldToScreenPoint(new Vector3(m_bounds.center.x + m_bounds.extents.x* padding, m_bounds.center.y - m_bounds.extents.y* padding, m_bounds.center.z + m_bounds.extents.z* padding));
                screenSpaceCorners[3] = m_camera.WorldToScreenPoint(new Vector3(m_bounds.center.x + m_bounds.extents.x* padding, m_bounds.center.y - m_bounds.extents.y* padding, m_bounds.center.z - m_bounds.extents.z * padding));
                screenSpaceCorners[4] = m_camera.WorldToScreenPoint(new Vector3(m_bounds.center.x - m_bounds.extents.x* padding, m_bounds.center.y + m_bounds.extents.y* padding, m_bounds.center.z + m_bounds.extents.z * padding));
                screenSpaceCorners[5] = m_camera.WorldToScreenPoint(new Vector3(m_bounds.center.x - m_bounds.extents.x* padding, m_bounds.center.y + m_bounds.extents.y* padding, m_bounds.center.z - m_bounds.extents.z * padding));
                screenSpaceCorners[6] = m_camera.WorldToScreenPoint(new Vector3(m_bounds.center.x - m_bounds.extents.x* padding, m_bounds.center.y - m_bounds.extents.y* padding, m_bounds.center.z + m_bounds.extents.z * padding));
                screenSpaceCorners[7] = m_camera.WorldToScreenPoint(new Vector3(m_bounds.center.x - m_bounds.extents.x* padding, m_bounds.center.y - m_bounds.extents.y* padding, m_bounds.center.z - m_bounds.extents.z * padding));

                // Now find the min/max X&Y of these screen space corners
                float min_x = screenSpaceCorners[0].x;
                float min_y = screenSpaceCorners[0].y;
                float max_x = screenSpaceCorners[0].x;
                float max_y = screenSpaceCorners[0].y;

                for (int i = 1; i < 8; i++)
                {
                    if(screenSpaceCorners[i].x < min_x)
                    {
                        min_x = screenSpaceCorners[i].x;
                    }
                    if (screenSpaceCorners[i].y < min_y)
                    {
                        min_y = screenSpaceCorners[i].y;
                    }
                    if (screenSpaceCorners[i].x > max_x)
                    {
                        max_x = screenSpaceCorners[i].x;
                    }
                    if (screenSpaceCorners[i].y > max_y)
                    {
                        max_y = screenSpaceCorners[i].y;
                    }
                }

                RectTransform rt = GetComponent<RectTransform>();

                rt.position = new Vector2(min_x, min_y);

                rt.sizeDelta = new Vector2(max_x - min_x, max_y - min_y);
            }
            else
            {
                // Out Animation
                //transform.DOScale(Vector3.zero, m_duration).SetEase(Ease.InOutSine);

                for (int i = 0; i < this.transform.childCount; i++)
                {
                    //HIDE INDICATOR
                    this.transform.GetChild(i).gameObject.SetActive(false);
                }
            }

        }

    }

}

