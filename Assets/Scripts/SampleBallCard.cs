using SO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SampleBallCard : MonoBehaviour
{
    public Image thumbnailImg;
    public Text coinTxt;
    public GameObject myBall;
    public CannonInfo myProperties;
    public CannonInfo currentCannon;
    public IntVariable currentCoin;
    //OnBuySuccess
    //OnBuyFail

    public UnityEvent OnBuySuccess;
    public UnityEvent OnBuyFail;

    public GameObject buyCoinsbtn;

    public void OnClickMyBall()
    {
        if(BallsInProject.instance.curMethod==MethodType.Method1)
        {
            if (BallsInProject.instance.curPreviewItem)
            {
                Destroy(BallsInProject.instance.curPreviewItem);
            }
            BallsInProject.instance.previewThumbnailImg.sprite = thumbnailImg.sprite;
            // BallsInProject.instance.curPreviewItem = Instantiate(myBall);
            //  BallsInProject.instance.curPreviewItem.transform.SetParent(BallsInProject.instance.previewObject.transform);
            //   BallsInProject.instance.curPreviewItem.transform.localPosition = Vector3.zero;
            //   BallsInProject.instance.curPreviewItem.transform.localScale = Vector3.one;
        }        
    }

    public void OnClickUpdate()
    {
        //if current coins >= current selected ball . price && !selectball.isUnlocked
        // current coins = current coins - ball price;
        //ball.isunlocked = true;
        //current ball = selected ball

        if (currentCoin.value >= myProperties.coinsToBuyBall && !myProperties.isUnlocked)
        {
            if (myProperties.ballLevel < myProperties.ballMaxLevel)
            {
                currentCoin.value -= myProperties.coinsToBuyBall;
                myProperties.isUnlocked = true;
                currentCannon = myProperties;
                OnBuySuccess.Invoke();
            }
        }
        else
        {
            OnBuyFail.Invoke();
        }   
       
    }

    public void CheckCardStatus()
    {
        if (!myProperties.isUnlocked)
        {
            buyCoinsbtn.SetActive(true);
        }
        else
        {
            buyCoinsbtn.SetActive(false);
        }
    }
}
