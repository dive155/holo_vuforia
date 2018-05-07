using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class MachinePlacer : MonoBehaviour {

	[SerializeField] private Transform pivot1;
	[SerializeField] private Transform pivot2;
    [SerializeField] private Transform debugPivot1;
    [SerializeField] private Transform debugPivot2;
    [SerializeField] private Transform hidePivot;
    [SerializeField] private Transform cameraTransform;
	[SerializeField] private Text debugText;
    [SerializeField] private float desiredDistance;

	private bool firstTracked = false;
	private bool secondTracked = false;

    [SerializeField] private SpawnObject spawner;
    private TapToPlace placer;
    private bool debugMode;

	void Update()
	{
        if (placer == null)
            spawner.TryGetSpawner(out placer);

        if (Input.GetKeyDown(KeyCode.V)) { debugMode = !debugMode; }

        Transform aPivot1;
        Transform aPivot2;

        if (debugMode)
        {
            firstTracked = true;
            secondTracked = true;

            aPivot1 = debugPivot1;
            aPivot2 = debugPivot2;
        }
        else
        {
            aPivot1 = pivot1;
            aPivot2 = pivot2;
        }

		if (firstTracked && secondTracked)
		{
            float actualDistance = (aPivot1.position - aPivot2.position).magnitude;
            float ratio = desiredDistance / actualDistance;

            Vector3 pos1 = cameraTransform.position + ((aPivot1.position - cameraTransform.position) * ratio);
            Vector3 pos2 = cameraTransform.position + ((aPivot2.position - cameraTransform.position) * ratio);

            Vector3 pos = Vector3.Lerp(pos1, pos2, 0.5f);
            Quaternion rot = Quaternion.Lerp(aPivot1.rotation, aPivot2.rotation, 0.5f);

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
