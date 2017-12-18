using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public enum SelectableStates
{
    Idle, GazedUpon, Selected, Locked
}

public class SelectableObject : MonoBehaviour, IFocusable, IInputClickHandler
{
    [SerializeField]
    private bool isDummy;

    protected SelectableStates currentState = SelectableStates.Idle;

	protected PartSlot currentSlot;

    public void SetState(SelectableStates newState)
    {
        currentState = newState;
        OnStateSelected();
    }

	public SelectableStates CurrentState
	{
		get
		{
			return currentState;
		}	
	}

    public void SetDefaultState()
    {
        SetState(SelectableStates.Idle);
        currentSlot.ReportUnselection(this);
    }

    protected virtual void OnStateSelected()
    {

    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (isDummy)
        {
            return;
        }

        if (currentState == SelectableStates.GazedUpon)
        {
            SetState(SelectableStates.Selected);
        }
    }

    public void OnFocusEnter() 
    {
        if (currentState == SelectableStates.Idle)
        {
            SetState(SelectableStates.GazedUpon);
            //Debug.Log("setstate gaze upon");
        }
    }

    public void OnFocusExit()
    {
        if (currentState == SelectableStates.GazedUpon)
        {
            SetState(SelectableStates.Idle);
            //Debug.Log("setstate idle");
        }
    }

	public void SetSlot(PartSlot slot)
	{
		currentSlot = slot;
	}

	public void ForceSetState(SelectableStates newState)
	{
		currentState = newState;
	}
}
