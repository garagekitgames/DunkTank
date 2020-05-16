using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMechanism : MonoBehaviour
{

    public GameObject scrollBar;
    float scrol_Pos = 0;
    float[] pos;

    public int curId=-1, prevId=-1;

    public void Update()
    {
        if(BallsInProject.instance.curMethod==MethodType.Method2)
        {
            pos = new float[transform.childCount];
            float dis = 1f / (pos.Length - 1);

            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = dis * i;
            }

            if (Input.GetMouseButton(0))
            {
                scrol_Pos = scrollBar.GetComponent<Scrollbar>().value;
            }
            else
            {
                for (int i = 0; i < pos.Length; i++)
                {
                    if (scrol_Pos < pos[i] + (dis / 2) && scrol_Pos > pos[i] - (dis / 2))
                    {
                        scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                    }
                }
            }
            for (int i = 0; i < pos.Length; i++)
            {
                if (scrol_Pos < pos[i] + (dis / 2) && scrol_Pos > pos[i] - (dis / 2))
                {
                   // curId = i;
                    if(curId!=i)
                    {
                        prevId=curId;
                        curId = i;
                        print(i);
                        BallsInProject.instance.SetPreview(i);
                    }
                    transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                    for (int a = 0; a < pos.Length; a++)
                    {
                        if (a != i)
                        {
                            transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        }
                    }

                }

            }
        }

      
    }
}
