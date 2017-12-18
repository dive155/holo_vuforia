using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;


public class ExpandableTask : MonoBehaviour, IFocusable
{
    [SerializeField]
    private Text taskTextLabel;

    [SerializeField]
    private TaskNote taskNotePrefab;

	[SerializeField]
	private Image backGroundPrefab;

	[SerializeField]
	private Image thirdLinePrefab;

	[SerializeField]
	private TaskWindowManager taskWindow;

    [SerializeField]
    private GameObject doneButtonPrefab;
    private GameObject doneButton;

	[SerializeField]
	private Image markEnterImage;
	[SerializeField]
	private Text markEnterText;

	[SerializeField]
	private Image markFinishImage;

    private List<NoteInspectorItem> notesInfo;
    private List<TaskNote> spawnedNotes;
    private bool expanded = false;
    private CheckboxInspectorItem originalInfo;

    public UnityEvent OnTaskComplete;

    public void SetTask(string _taskText, List<NoteInspectorItem> _notes, CheckboxInspectorItem _originalInfo)
    {
        taskTextLabel.text = _taskText;
        notesInfo = _notes;
        originalInfo = _originalInfo;
    }

	public void Expand(int index)
    {
        expanded = true;
        spawnedNotes = new List<TaskNote>();
		GameObject backGround = Instantiate (backGroundPrefab.gameObject);
		GameObject thirdLine = Instantiate (thirdLinePrefab.gameObject);
		backGround.transform.SetParent (this.transform, false);
		thirdLine.transform.SetParent (this.transform, false);
		thirdLine.GetComponentInChildren<Text> ().text = originalInfo.taskDescription;
		for (int i = 0; i < notesInfo.Count; i++)
        {
            
			GameObject instantiated = Instantiate(taskNotePrefab.gameObject);
			//instantiated.transform.SetParent (backGround.transform);
			TaskNote newNote = instantiated.GetComponent<TaskNote>();
            newNote.SetNote(notesInfo[i].icon, notesInfo[i].noteText, notesInfo[i].prefix);
			newNote.transform.SetParent(backGround.transform, false);
            spawnedNotes.Add(newNote);
        }
        //SpawnDoneButton();
		SpawnDoneButtonNew();
    }

    public void Shrink()
    {
        expanded = false;
        foreach (var note in spawnedNotes)
        {
            Destroy(note.gameObject);
        }
        DestroyDoneButton();
    }

	public void SpawnDoneButtonNew()
	{
		gameObject.GetComponent<Button>().onClick.AddListener(OnDonePressed);
        EventManager.onDoneRecognized += OnDonePressed;
    }

    public void SpawnDoneButton()
    {
        if (doneButton != null)
        {
            DestroyDoneButton();
        }
        doneButton = Instantiate(doneButtonPrefab);
        doneButton.transform.SetParent(this.transform, false);
		//doneButton.GetComponent<RectTransform> ().sizeDelta = new Vector3 (this.transform.GetComponent<RectTransform> ().sizeDelta.x, this.transform.GetComponent<RectTransform> ().sizeDelta.x);
        doneButton.GetComponentInChildren<Button>().onClick.AddListener(OnDonePressed);
        EventManager.onDoneRecognized += OnDonePressed;
    }

    private void DestroyDoneButton()
    {
        EventManager.onDoneRecognized -= OnDonePressed;
        Destroy(doneButton);
    }
		
    public void OnDonePressed()
    {
        EventManager.onDoneRecognized -= OnDonePressed;

        //Debug.Log("Done pressed");
        //checkBox.isOn = true;
        if (originalInfo.OnDonePressed != null)
		{
			originalInfo.OnDonePressed.Invoke();
		}
        if (OnTaskComplete != null)
        {
            OnTaskComplete.Invoke();
        }
		expanded = false;
		SetCheckVisible(false);
		MarkFinishEnabled();
    }

	public void MarkFinishEnabled()
	{
		markFinishImage.enabled = true;
	}

	public void OnFocusEnter() 
	{
		if (expanded)
		{
			SetCheckVisible(true);
		}
	}

	public void OnFocusExit()
	{
		if (expanded)
		{
			SetCheckVisible(false);
		}
	}

	void SetCheckVisible(bool val)
	{
		markEnterImage.enabled = val;
		markEnterText.enabled = val;
	}

}
