using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLevelUIDisplayer : MonoBehaviour
{
    public List<GameObject> _listOfWorlds = new List<GameObject>();

    public float speed;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(SetCurrentLevel(8));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ResetAllWorld();
        }
    }

    public IEnumerator SetCurrentLevel(int levelID)
    {
        for (int i = 0; i < _listOfWorlds.Count; i++)
        {
            if(i < levelID)
            {
                float temp = 0f;
                while (temp < 1)
                {
                    temp = temp + speed * Time.unscaledDeltaTime;
                    _listOfWorlds[i].GetComponent<SampleLevelCard>().filledImg.fillAmount = temp;
                    yield return new WaitForSeconds(0.01f);
                }
            }
            
        }
      
        _listOfWorlds[levelID - 1].GetComponent<SampleLevelCard>().displayerArrow.gameObject.SetActive(true);// = 0;
    }

    public void ResetAllWorld()
    {
        for(int i=0;i<_listOfWorlds.Count;i++)
        {
            _listOfWorlds[i].GetComponent<SampleLevelCard>().filledImg.fillAmount = 0;
            _listOfWorlds[i].GetComponent<SampleLevelCard>().displayerArrow.gameObject.SetActive(false);// = 0;
        }
    }
}
