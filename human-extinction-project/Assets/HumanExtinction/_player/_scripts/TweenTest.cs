using UnityEngine;
using DG.Tweening;


public class TweenTest : MonoBehaviour
{
    float duration = 2;
    Ease myEaseType = Ease.InSine;
    public bool Play;

    Transform myCube;

    Tween myTween;

    private void Awake()
    {
        myCube = transform.GetChild(0).gameObject.transform;
    }


    private void Update()
    {
        //myTween.OnComplete(HideObject);

        if (Play)
        {
            myCube.gameObject.SetActive(true);
            myTween = myCube.DOScale(Vector3.zero, duration).OnKill(HideObject);
        }
        else
        {
            if(transform.GetChild(0).gameObject.transform.localScale == Vector3.zero)
            {
                myCube.DOScale(Vector3.zero, duration);
                print("scale up");
            }

        }

    }

    void HideObject()
    {

        print("Hide");
        myCube.gameObject.SetActive(false);

    }

}
