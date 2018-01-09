using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePlacer : MonoBehaviour {

    [SerializeField] private Transform pivot1;
    [SerializeField] private Transform pivot2;

    void Update()
    {
        this.transform.position = Vector3.Lerp(pivot1.position, pivot2.position, 0.5f);
        this.transform.rotation = Quaternion.Lerp(pivot1.rotation, pivot2.rotation, 0.5f);
    }


}
