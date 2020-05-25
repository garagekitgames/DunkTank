using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SegmentUIDisplayer : MonoBehaviour
{
    public Transform segmentParent;
    public GameObject sampleCard;

    public List<GameObject> _listOfSpawnedSegment = new List<GameObject>();

    public float speed;

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    DrawSegments(5);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    StartCoroutine(CurrentSegment(3));
        //}
    }

    public void DrawSegments(int noOfSegments)
    {
        for (int i = 0; i < noOfSegments; i++)
        {
            GameObject temp = Instantiate(sampleCard,segmentParent);
            _listOfSpawnedSegment.Add(temp);
        }
    }

    public IEnumerator CurrentSegment(int curSegmentID)
    {
        float temp = 0f;
        while (temp < 1)
        {
            temp = temp + speed * Time.unscaledDeltaTime;
            _listOfSpawnedSegment[curSegmentID - 1].GetComponent<SampleSegmentCard>().fillImg.fillAmount=temp;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
