using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class Part : SelectableObject, IInputClickHandler {

    [SerializeField]
    private Color selectedColor;
    [SerializeField]
	private Color gazedColor;
    [SerializeField]
	private string partDescription;
    public string PartDescription { get { return partDescription;}  }

    [SerializeField]
    private GameObject uiWindow;

    [SerializeField]
    private GameObject taskUiWindow;

    [SerializeField]
    private StateUIHandler stateUIHandler;

    private Color defaultColor;

    [SerializeField]
    private Renderer rend;

    private Action<bool> toggleBlur;

    void Start()
    {
        //rend = GetComponentInChildren<Renderer>();
        defaultColor = rend.material.color;

        ToggleUIMenu(false);
    }
        

    protected override void OnStateSelected()
    {
        switch (currentState)
        {
            case SelectableStates.GazedUpon:
                Highlight();
                break;
            case SelectableStates.Selected:
                Select();
                break;
            case SelectableStates.Idle:
                StopHighlighting();
                break;
        }
    }

    private void ToggleUIMenu(bool show)
    {
        if (show == true)
        {
            uiWindow.gameObject.SetActive(show);
        }
        else
        {
            taskUiWindow.gameObject.SetActive(show);
        }
        stateUIHandler.gameObject.SetActive(!show);
    }

    private void Select()
    {
        currentSlot.ReportSelection(this);
        rend.material.color = defaultColor;
        toggleBlur(true);
        ToggleUIMenu(true);
    }

    private void Unselect()
    {
        rend.material.color = defaultColor;
        toggleBlur(false);
        ToggleUIMenu(false);
    }

    private void Highlight()
    {
        Unselect();
        rend.material.color = gazedColor;
    }

    private void StopHighlighting()
    {
        Unselect();
        rend.material.color = defaultColor;
    }

    public void SetBlurAction(Action<bool> blurAction)
    {
        toggleBlur = blurAction;
    }
}
