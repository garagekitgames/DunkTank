using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public GameObject sampleBallImg;
    public GameObject ballImgParent;
    private int i;

    public List<GameObject> _listOfBallInstantiated = new List<GameObject>();

    public Sprite ballActive;
    public Sprite ballUnActive;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DrawNoOfBalls(5);
        }
    }

    public void DrawNoOfBalls(int noOfTry)
    {
        for (i = 0; i < noOfTry; i++)
        {
            GameObject temp = Instantiate(sampleBallImg, ballImgParent.transform);
            temp.transform.SetParent(ballImgParent.transform);
            _listOfBallInstantiated.Add(temp);
        }
    }

    public void ActiveBalls()
    {
        
        _listOfBallInstantiated[GameManager_Muthu.instance.noOfBallsReleased-1].GetComponent<Image>().sprite = ballActive;
    }
}
