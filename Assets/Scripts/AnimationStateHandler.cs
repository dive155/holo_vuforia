using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateHandler : MonoBehaviour
{
    [SerializeField]
    private Animator stateAnimator;
    [SerializeField]
    private string[] animStateNames;

    private int currentStateIndex = -1;
	
    public void SetAnimState(string stateName)
    {
        stateAnimator.SetTrigger(stateName);
    }

    public void NextAnimState()
    {
        currentStateIndex++;
        if (currentStateIndex >= animStateNames.Length)
        {
            currentStateIndex = 0;
        }

        SetAnimState(animStateNames[currentStateIndex]);
    }
}
