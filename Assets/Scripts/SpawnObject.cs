using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class SpawnObject : MonoBehaviour
{

	[SerializeField]
    private GameObject objectPrefab;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
	{
		GameObject instantiated = Instantiate (objectPrefab);
		if (instantiated.GetComponentInChildren<TapToPlace> () != null && instantiated.GetComponentInChildren<TapToPlace>().isActiveAndEnabled) 
		{
			instantiated.GetComponentInChildren<TapToPlace> ().IsBeingPlaced = true;
		} 
		else 
		{
			RaycastHit ray;
			Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out ray, 1000.0f);
			//instantiated.transform.position = Camera.main.transform.position;
			instantiated.transform.position = Vector3.Lerp(Camera.main.transform.position, ray.point, 0.8f);
		}

        gameObject.SetActive(false);
    }
}
