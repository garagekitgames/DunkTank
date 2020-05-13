using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public GameObject parent;
    public GameObject dotsPrefab;
    private Transform[] dotsList;
    public int dotsCount;

    [SerializeField] [Range(0.01f, 0.1f)] private float dotMinScale;
    [SerializeField] [Range(0.1f, 1f)] private float dotMaxScale;
    [SerializeField] private float dotSpacing;
    private float timeStamp;
    private Vector3 pos;

    private void Start()
    {
        Hide();
        PrepareDots();
    }

    private void Update()
    {

    }

    public void PrepareDots()
    {
        dotsList = new Transform[dotsCount];
        dotsPrefab.transform.localScale = Vector3.one * dotMaxScale;

        float scale = dotMaxScale;
        float scaleFactor = scale / dotsCount;

        for (int i = 0; i < dotsCount; i++)
        {

            dotsList[i] = Instantiate(dotsPrefab, null).transform;
            dotsList[i].parent = parent.transform;

            dotsList[i].localScale = Vector3.one * scale;
            if (scale > dotMinScale)
            {
                scale -= scaleFactor;
            }
        }

    }

    public void UpdateDots(Vector3 ballPos, Vector3 forceApplied)
    {
        timeStamp = dotSpacing;
        for (int i = 0; i < dotsCount; i++)
        {
            pos.x = (ballPos.x + forceApplied.x * timeStamp);
            pos.y = (ballPos.y + forceApplied.y * timeStamp) - (Physics.gravity.magnitude * timeStamp * timeStamp) / 2f;

            //print(pos.x);
            
            pos.z = (ballPos.z + forceApplied.z * timeStamp);

            //you can simlify this 2 lines at the top by:
            //pos = (ballPos+force*time)-((-Physics2D.gravity*time*time)/2f);
            //
            //but make sure to turn "pos" in Ball.cs to Vector2 instead of Vector3	

            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }

    public void Show()
    {
        parent.SetActive(true);
    }

    public void Hide()
    {
        parent.SetActive(false);
    }
}