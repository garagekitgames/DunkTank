using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroundTrampoline : MonoBehaviour, ITrap
{
    public GameObject lever;
    public GameObject Ground;

    void Start()
    {
    }

    public void OnTriggered()
    {
        Sequence mySequence = DOTween.Sequence();
        Sequence mySequence1 = DOTween.Sequence();

        mySequence.Append( lever.transform.DOScaleY(5f,0.1f)).
            Append(lever.transform.DOScaleY(4f, 0.2f)).
            Append(lever.transform.DOScaleY(4.5f, 0.25f)).
           // Append(lever.transform.DOScaleZ(5f, 0.15f)).            
            OnComplete(AfterCompletion);

        Ground.transform.DOLocalJump(new Vector3(4f, -5f, 0f),1,1,1f);
       
           // mySequence1.Append(Ground.transform.DOJump(new Vector3(4f, -5f, 0f)));//.
           // Append(Ground.transform.DOLocalMoveZ(4f, 0.2f)).
          //  Append(Ground.transform.DOLocalMoveZ(4.5f, 0.25f));//.
           // Append(glove.transform.DOLocalMoveZ(5f, 0.15f));
      //  glove.transform.DOLocalMoveZ(5f,0.2f);
    }

    public void AfterCompletion()
    {
       // Invoke("ResetMe",3);
    }

    public void ResetMe()
    {
        lever.transform.DOScaleZ(1f, 1.5f);
        Ground.transform.DOLocalMoveZ(1f, 1.5f);
    }
}
