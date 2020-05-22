using DG.Tweening;
using UnityEngine;

public class PushDownTrigger : MonoBehaviour, ITrigger
{
    public void OnAnimationPlay()
    {
        transform.DOLocalMove(new Vector3(0, -1, 0), 0.5f);
    }
}
