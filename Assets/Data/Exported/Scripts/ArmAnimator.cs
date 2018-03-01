using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimator : MonoBehaviour {

    [SerializeField] private Animator armAnimator;
    [SerializeField] private Animator boxAnimator;

    public void MoveUp()
    {
        armAnimator.SetTrigger("MoveUp");
    }

    public void MoveDown()
    {
        armAnimator.SetTrigger("MoveDown");
    }

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
