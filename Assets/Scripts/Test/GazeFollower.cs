using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeFollower : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1000.0f))
        {
            transform.position = hit.point;
        }
	}
}
