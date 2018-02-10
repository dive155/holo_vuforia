using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigController : MonoBehaviour {


    [SerializeField] private ArmAnimator armAnimator;
    [SerializeField] private BeltSpinner beltSpinner;
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            armAnimator.MoveUp();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            armAnimator.MoveDown();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            beltSpinner.SwitchBeltMoving();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            armAnimator.MoveOut();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            armAnimator.MoveIn();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            armAnimator.StopMoving();
        }
	}
}
