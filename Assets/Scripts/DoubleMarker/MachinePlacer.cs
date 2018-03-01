using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachinePlacer : MonoBehaviour {

	[SerializeField] private Transform pivot1;
	[SerializeField] private Transform pivot2;
	[SerializeField] private Transform hidePivot;
	[SerializeField] private Text debugText;

	private bool firstTracked = false;
	private bool secondTracked = false;

	void Update()
	{
		
		if (firstTracked && secondTracked)
		{
			this.transform.position = Vector3.Lerp(pivot1.position, pivot2.position, 0.5f);
			this.transform.rotation = Quaternion.Lerp(pivot1.rotation, pivot2.rotation, 0.5f);
		}
		else
		{
			this.transform.position = hidePivot.transform.position;
		}
	}

	public void FirstLost()
	{
		Log ("FirstLost");
		firstTracked = false;
	}

	public void FirstFound()
	{
		Log ("FirstFound");
		firstTracked = true;
	}

	public void SecondLost()
	{
		Log ("SecondLost");
		secondTracked = false;
	}

	public void SecondFound()
	{
		Log ("SecondFound");
		secondTracked = true;
	}

	private void Log(string message)
	{
		debugText.text += message + "\n";
	}
}
