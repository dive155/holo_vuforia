using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLineDir : MonoBehaviour 
{
	[SerializeField] 
	private Color colorRay;
	[SerializeField] 
	private float rayDistance;
	[SerializeField]
	private Color colorSphere;
	[SerializeField] 
	private float sphereRadius;

	void OnDrawGizmos() 
	{
		Gizmos.color = colorRay;
		Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
		Gizmos.color = colorSphere;
		Gizmos.DrawSphere(transform.position, sphereRadius);
	}
} 