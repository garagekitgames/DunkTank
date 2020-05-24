using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoxingGlove : MonoBehaviour, ITrap
{
    public GameObject lever;
    public GameObject glove;

    void Start()
    {
    }
    public void OnTriggered()
    {
        Sequence mySequence = DOTween.Sequence();
        Sequence mySequence1 = DOTween.Sequence();

        mySequence.Append( lever.transform.DOScaleZ(5f,0.1f)).
            Append(lever.transform.DOScaleZ(4f, 0.2f)).
            Append(lever.transform.DOScaleZ(4.5f, 0.25f)).
           // Append(lever.transform.DOScaleZ(5f, 0.15f)).            
            OnComplete(AfterCompletion);

        mySequence1.Append(glove.transform.DOLocalMoveZ(5f, 0.1f)).
            Append(glove.transform.DOLocalMoveZ(4f, 0.2f)).
            Append(glove.transform.DOLocalMoveZ(4.5f, 0.25f));//.
           // Append(glove.transform.DOLocalMoveZ(5f, 0.15f));
      //  glove.transform.DOLocalMoveZ(5f,0.2f);
    }

    public void AfterCompletion()
    {
        Invoke("ResetMe",3);
    }

    public void ResetMe()
    {
        lever.transform.DOScaleZ(1f, 1.5f);
        glove.transform.DOLocalMoveZ(1f, 1.5f);
    }
}
