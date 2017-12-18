using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class CheckboxInspectorItem
{
    public string taskText;
    public List<NoteInspectorItem> notes;
	public string taskDescription;
    public UnityEvent OnDonePressed;
}

[System.Serializable]
public class NoteInspectorItem
{
    public string prefix;
    public Sprite icon;
    public string noteText;
}

public class TaskWindowManager : MonoBehaviour 
{
    [SerializeField]
    private List<CheckboxInspectorItem> tasksInfos;

    [SerializeField]
    private ExpandableTask taskPrefab;

    [SerializeField]
    private Text counterLabel;

    private List<ExpandableTask> spawnedTasks;
    private int currentTaskIndex;

    [SerializeField]
    private UnityEvent OnTasksActivated;

	private float currentSpawnedTask;

    private void OnEnable()
    {
        ResetWindow();
    }

	private void InitWindow()
    {
        spawnedTasks = new List<ExpandableTask>();
		for (int i = currentTaskIndex; i < 3 + currentTaskIndex; i++) //tasksInfos.Count
        {
            GameObject instantiated = Instantiate(taskPrefab.gameObject);
            ExpandableTask newTask = instantiated.GetComponent<ExpandableTask>();
			InitTask(newTask, tasksInfos[i]);
            spawnedTasks.Add(newTask);
        }
        UpdateCounter();
		OpenTask(currentTaskIndex);
        OnTasksActivated.Invoke();
    }

	void DestroyTasks()
	{
		if(spawnedTasks != null)
		{
			foreach (ExpandableTask task in spawnedTasks)
			{
				Destroy(task.gameObject);
			}
		}
	}

	private void ResetWindow()
    {
		currentTaskIndex = 0;
		DestroyTasks();
		InitWindow();
    }

    void InitTask(ExpandableTask task, CheckboxInspectorItem info)
    {
        task.SetTask(info.taskText, info.notes, info);
        task.transform.SetParent(this.transform, false);
        task.transform.localPosition = new Vector3(0, 0, 0);
        task.OnTaskComplete.AddListener(OnTaskCompletionDetected);
    }

	private void ActiveCheckFalse(int index)
	{
		spawnedTasks[index].GetComponent<LayoutElement>().enabled = false;
		spawnedTasks[index].GetComponent<BoxCollider>().enabled = false;
		spawnedTasks[index].GetComponent<Image>().enabled = false;
	}

    void OnTaskCompletionDetected()
    {
		if(currentTaskIndex < 1)
		{
			ActiveCheckFalse(currentTaskIndex);
			currentTaskIndex++;
			if(currentTaskIndex < tasksInfos.Count)
			{
				OpenTask(currentTaskIndex);
			}
			UpdateCounter();
			Clear(currentTaskIndex - 1);
		} 
		else if(currentTaskIndex < tasksInfos.Count - 2)
		{
			DestroyTasks();
			spawnedTasks = new List<ExpandableTask>();
			for(int i = currentTaskIndex; i < 3 + currentTaskIndex; i++) //tasksInfos.Count
			{
				GameObject instantiated = Instantiate(taskPrefab.gameObject);
				ExpandableTask newTask = instantiated.GetComponent<ExpandableTask>();
				InitTask(newTask, tasksInfos[i]);
				spawnedTasks.Add(newTask);
			}
			spawnedTasks[0].MarkFinishEnabled();
			OpenTask(1);
			currentTaskIndex++;
			UpdateCounter();
		} 
		else
		{
			ActiveCheckFalse(1);
			currentTaskIndex++;
			if(currentTaskIndex < tasksInfos.Count)
			{
				OpenTask(2);
			}
			UpdateCounter();
			Clear(1);
		}
    }

	void Clear(int index)
	{
		for(int i = 1; i < spawnedTasks[index].transform.childCount; i++ )
		{
			spawnedTasks [index].transform.GetChild (i).gameObject.SetActive (false);
		}
	}


    void OpenTask(int index)
    {
		spawnedTasks[index].Expand(index);
		spawnedTasks[index].GetComponent<LayoutElement> ().enabled = true;
		spawnedTasks[index].GetComponent<BoxCollider> ().enabled = true;
		spawnedTasks[index].GetComponent<Image> ().enabled = true;
    }

    void UpdateCounter()
    {
		int totalNumber = tasksInfos.Count;
        counterLabel.text = string.Format("{0}/{1}", currentTaskIndex, totalNumber);
    }

}
