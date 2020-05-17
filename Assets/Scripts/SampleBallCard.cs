using UnityEngine;
using UnityEngine.UI;

public class SampleBallCard : MonoBehaviour
{
    public Image thumbnailImg;
    public Text coinTxt;
    public GameObject myBall;
    public Balls myProperties;

    public void OnClickMyBall()
    {
        if(BallsInProject.instance.curMethod==MethodType.Method1)
        {
            if (BallsInProject.instance.curPreviewItem)
            {
                Destroy(BallsInProject.instance.curPreviewItem);
            }

            BallsInProject.instance.curPreviewItem = Instantiate(myBall);
            BallsInProject.instance.curPreviewItem.transform.SetParent(BallsInProject.instance.previewObject.transform);
            BallsInProject.instance.curPreviewItem.transform.localPosition = Vector3.zero;
            BallsInProject.instance.curPreviewItem.transform.localScale = Vector3.one;
        }        
    }

    public void OnClickUpdate()
    {
        if (myProperties.ballLevel<myProperties.ballMaxLevel)
        {
            myProperties.damage += 10;
            myProperties.coinsToBuyBall += 100;
            myProperties.ballLevel++;//= 100;
            coinTxt.text = myProperties.coinsToBuyBall.ToString();
        }
    }
}
