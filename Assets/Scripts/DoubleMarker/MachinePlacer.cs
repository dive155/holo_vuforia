using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class MachinePlacer : MonoBehaviour {

	[SerializeField] private Transform pivot1;
	[SerializeField] private Transform pivot2;
	[SerializeField] private Transform hidePivot;
    [SerializeField] private Transform cameraTransform;
	[SerializeField] private Text debugText;
    [SerializeField] private float desiredDistance;

	private bool firstTracked = false;
	private bool secondTracked = false;

    [SerializeField] private SpawnObject spawner;
    private TapToPlace placer;

	void Update()
	{
        if (placer == null)
            spawner.TryGetSpawner(out placer);

		if (firstTracked && secondTracked)
		{
            float actualDistance = (pivot1.position - pivot2.position).magnitude;
            float ratio = desiredDistance / actualDistance;

            Vector3 pos1 = cameraTransform.position + ((pivot1.position - cameraTransform.position) * ratio);
            Vector3 pos2 = cameraTransform.position + ((pivot2.position - cameraTransform.position) * ratio);

            Vector3 pos = Vector3.Lerp(pos1, pos2, 0.5f);
            Quaternion rot = Quaternion.Lerp(pivot1.rotation, pivot2.rotation, 0.5f);

            if (placer != null)
            {
                placer.OverrideByMarker = true;
                placer.LastKnownPosition = pos;
                placer.LastKnownRotation = rot;
            }

            this.transform.position = pos;
            this.transform.rotation = rot;
        }
		else
		{
			this.transform.position = hidePivot.transform.position;

            if (placer != null)
            {
                placer.OverrideByMarker = false;
            }
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
