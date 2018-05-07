using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class SpawnObject : MonoBehaviour
{

	[SerializeField]
    private GameObject objectPrefab;
    private TapToPlace taper;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
	{
        GameObject instantiated = Instantiate (objectPrefab);
        taper = instantiated.GetComponentInChildren<TapToPlace>();

        if (taper != null && taper.isActiveAndEnabled) 
		{
            taper.IsBeingPlaced = true;
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

    public bool TryGetSpawner(out TapToPlace tap)
    {
        if (taper != null)
        {
            tap = taper;
            return true;
        }
        else
        {
            tap = null;
            return false;
        }
    }

}
