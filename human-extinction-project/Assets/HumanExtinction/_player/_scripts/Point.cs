using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

namespace CS
{
    public class Point : MonoBehaviour
    {
        [HideInInspector]public int index = 0;

        //ray
        [BoxGroup("Update Ray Size")] public float raySize = 0.3f;

        //direction
        [BoxGroup("Allowed Directions")] public bool lockUp;
        [BoxGroup("Allowed Directions")] public bool lockDown;
        [BoxGroup("Allowed Directions")] public bool lockLeft;
        [BoxGroup("Allowed Directions")] public bool lockRight;

        //win or lose
        [BoxGroup("Game Conditions")] public bool win;
        [BoxGroup("Game Conditions")] public bool gameOver;

        //sprite
        [BoxGroup("Point Sprite")] public bool getSprite;
        [BoxGroup("Point Sprite")] public bool endPoint;
        [BoxGroup("Point Sprite")] public float animSpeed = 2;
        [BoxGroup("Point Sprite")] public int setLoop = -1;
        [BoxGroup("Point Sprite")] public float fade = 0;
        [BoxGroup("Point Sprite")] public Vector3 size;

        public SpriteRenderer spriteObject;
        public Color startColor;


        public Sequence loopSequence;
        private void Awake()
        {
            if (getSprite)
            {
                spriteObject = transform.Find("sprite").GetComponent<SpriteRenderer>();
                spriteObject.transform.localScale = Vector3.zero;
            }
        }



        public void LoopCircle()
        {
            spriteObject.color = startColor;
            spriteObject.transform.localScale = Vector3.zero;
            spriteObject.gameObject.SetActive(true);

            if (!endPoint)
            {
                loopSequence.Kill(true);
                loopSequence = DOTween.Sequence();
                loopSequence.Append(spriteObject.transform.DOScale(size, animSpeed));
                loopSequence.Append(spriteObject.DOFade(fade, animSpeed));
                loopSequence.SetLoops(-1);
            }
            else
            {
                loopSequence.Kill(true);
                loopSequence = DOTween.Sequence();
                loopSequence.Append(spriteObject.transform.DOScale(size, animSpeed));
                loopSequence.Append(spriteObject.DOFade(fade, animSpeed));
                loopSequence.SetLoops(-1);
            }

        }


        public void PlayOnce()
        {
            loopSequence.Kill(true);
            loopSequence = DOTween.Sequence();
            loopSequence.Append(spriteObject.transform.DOScale(size, 0.2f));
            loopSequence.Append(spriteObject.DOFade(1f, 0.2f));
            loopSequence.Play();
        }


    }



}

