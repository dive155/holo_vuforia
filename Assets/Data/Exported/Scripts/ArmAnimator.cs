using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimator : MonoBehaviour {

    [SerializeField] private Animator armAnimator;

    public void MoveUp()
    {
        armAnimator.SetTrigger("MoveUp");
    }

    public void MoveDown()
    {
        armAnimator.SetTrigger("MoveDown");
    }


}
