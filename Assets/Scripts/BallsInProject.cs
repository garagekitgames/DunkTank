using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum MethodType { Method1, Method2, Method3 }
public class BallsInProject : MonoBehaviour
{
    public static BallsInProject instance;

    public List<BallInfo> _listOfBalls = new List<BallInfo>();

    public GameObject scrollBar;
    public GameObject ballPanel;
    public SampleBallCard sampleCard;
    public GameObject previewObject;
    public GameObject curPreviewItem;
    public GameObject playButton;
    public Transform endPoint,startPoint;
    private List<SampleBallCard> _listOfSpawnedCards = new List<SampleBallCard>();

    public MethodType curMethod;

    public void Start()
    {
        instance = GetComponent<BallsInProject>();

        if (curMethod == MethodType.Method3)
        {
            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
        }

        for (int i = 0; i < _listOfBalls.Count; i++)
        {
            SampleBallCard temp = Instantiate(sampleCard, scrollBar.transform);
            temp.transform.SetParent(scrollBar.transform);
            temp.myProperties = _listOfBalls[i];
            BallData tempData = Resources.Load<BallData>("BallData/" + _listOfBalls[i].ballDataName);
            temp.thumbnailImg.sprite = tempData.thumbnail;
            temp.myBall = tempData.ballPrefab;
            _listOfSpawnedCards.Add(temp);
        }
    }

    public void SetPreview(int id)
    {
        if (curPreviewItem)
        {
            Destroy(curPreviewItem);
        }

        curPreviewItem = Instantiate(_listOfSpawnedCards[id].myBall);
        curPreviewItem.transform.SetParent(previewObject.transform);
       curPreviewItem.transform.localPosition = Vector3.zero;
       curPreviewItem.transform.localScale = Vector3.one;

    }

    public void MoveDown()
    {
        // ballPanel.transform.DOLocalMoveY(30f,.01f);
        ballPanel.transform.DOLocalMove(endPoint.localPosition, 1);//.OnComplete(() => AfterCompletion());
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(playButton.transform.DOScale(0.75f, 0.5f))
          .Append(playButton.transform.DOScale(1f, 0.5f)).OnComplete(()=>playButton.SetActive(false));


        Invoke("MoveUp",3f);
    }

    public void MoveUp()
    {
        playButton.SetActive(true);
        // ballPanel.transform.DOLocalMoveY(30f,.01f);
        ballPanel.transform.DOLocalMove(startPoint.localPosition, 1);//.OnComplete(() => AfterCompletion());
    }

   
}
