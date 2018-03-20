using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAnimator : MonoBehaviour {

    [SerializeField] private Animator boxAnimator;

    public void MoveOut()
    {
        boxAnimator.SetTrigger("MoveOut");
    }

    public void MoveIn()
    {
        boxAnimator.SetTrigger("MoveIn");
    }

    public void StopMoving()
    {
        boxAnimator.SetTrigger("StopMoving");
    }
}
