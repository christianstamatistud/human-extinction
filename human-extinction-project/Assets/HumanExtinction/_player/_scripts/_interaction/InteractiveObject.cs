using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;
using TMPro;

namespace CS
{
    public class InteractiveObject : MonoBehaviour, IInteractable
    {
        InteractiveController m_interactiveController;

        [BoxGroup("Item Settings")] [SerializeField] public string key;
        [BoxGroup("Item Settings")] [SerializeField] public string m_name;

        [BoxGroup("Item Settings")] [SerializeField] public bool IsInteractable;
        [BoxGroup("Item Settings")] [SerializeField] public bool IsPickable;
        [BoxGroup("Item Settings")] [SerializeField] public bool IsDraggable;
        [BoxGroup("Item Settings")] [SerializeField] public float dragForce = 10;
        Tween myTween;



        [BoxGroup("Animation Settings")] [SerializeField] float m_duration = 1f;
        [BoxGroup("Animation Settings")] [SerializeField] Ease dragEase = Ease.InSine;
        [BoxGroup("Animation Settings")] [SerializeField] Ease scaleEase = Ease.InSine;
        [BoxGroup("Animation Settings")] [SerializeField] public bool isScalable;
        [BoxGroup("Animation Settings")] [SerializeField] public Vector3 scaleSize;

        public bool m_isInteractable { get => m_isInteractable; set => IsInteractable = value; }
        public bool m_isDraggable { get => m_isDraggable; set => IsDraggable = value; }


        private void Awake()
        {
            m_interactiveController = FindObjectOfType<InteractiveController>();
        }
        private void Update()
        {
            
        }

        public void OnInteraction()
        {
            Debug.Log("Interacting");
            if (IsInteractable)
            {
                if (IsPickable)
                {
                    //Do Pickup action
                }
            }
        }

        public void OnDrag()
        {
            if (!m_interactiveController.hasItem)
            {
                if (IsDraggable && m_interactiveController.selectedObjectRoot != null && IsInteractable)
                {
                    DragObject(m_interactiveController);
                }

            }
            else
            {
                ClearObject();
            }
        }

        public void DragObject(InteractiveController intCon)
        {
            intCon.currentObject = intCon.selectedObjectRoot;
            intCon.hasItem = true;
            IsInteractable = false;
            print("drag");
            intCon.selectedObjectRoot.GetComponent<Rigidbody>().isKinematic = true;
            //m_interactiveController.lastSelectedObject.transform.position = m_interactiveController.ItemHolder.transform.position;
            myTween = transform.DOMove(m_interactiveController.ItemHolder.transform.position, m_duration).SetEase(scaleEase);
            myTween.OnComplete(RefineObjectPosition);
            if(isScalable)
            transform.DOScale(scaleSize, m_duration).SetEase(dragEase);
            intCon.selectedObjectRoot.transform.SetParent(intCon.ItemHolder.transform);


            Collider[] colliders = GetComponentsInChildren<Collider>();

            foreach (Collider c in colliders)
            {
                c.gameObject.layer = 0;
                c.enabled = false;
            }
        }

        void RefineObjectPosition()
        {
            transform.position = m_interactiveController.ItemHolder.transform.position;
            Debug.Log("Refinin");
        }
        public void ClearObject()
        {
            m_interactiveController.hasItem = false;
            IsInteractable = true;
            print("off drag");
            m_interactiveController.currentObject.transform.parent = null;

            if(isScalable)
            transform.DOScale(Vector3.one, m_duration).SetEase(scaleEase);

            m_interactiveController.currentObject.GetComponent<Rigidbody>().isKinematic = false;
            m_interactiveController.currentObject.GetComponent<Rigidbody>().AddForce(m_interactiveController.ItemHolder.transform.forward*dragForce, ForceMode.Impulse);

            Collider[] colliders = GetComponentsInChildren<Collider>();

            foreach (Collider c in colliders)
            {
                c.gameObject.layer = 10;
                c.enabled = true;
            }

            m_interactiveController.currentObject = null;
        }

        public void PlaceOnGround()
        {

        }

    }


}


