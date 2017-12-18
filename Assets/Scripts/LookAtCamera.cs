using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

	[SerializeField] bool x = true;
	[SerializeField] bool y = true;
	[SerializeField] bool z = true;

	// Update is called once per frame
	void Update () {
        Quaternion rot = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
		Vector3 angles = rot.eulerAngles;
		if (!x)
			angles.x = 0;
		if (!y)
			angles.y = 0;
		if (!z)
			angles.z = 0;
		transform.rotation = Quaternion.Euler (angles);
    }
		
}
