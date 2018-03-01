using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltSpinner : MonoBehaviour {

    [SerializeField] private Transform upperWheel;
    [SerializeField] private Transform lowerWheel;

    [SerializeField] private float upSpeed = 1;
    [SerializeField] private float downSpeed = 1.5f;

    [SerializeField] private Renderer beltRend;
    [SerializeField] private float beltSpeed = 1;

    [SerializeField] private bool active;

    public void SetBeltMoving(bool val)
    {
        active = val;
    }

    public void SwitchBeltMoving()
    {
        active = !active;
    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (active)
        {
            upperWheel.Rotate(0, 0, upSpeed);
            lowerWheel.Rotate(0, 0, downSpeed);
            beltRend.material.mainTextureOffset = new Vector2((beltRend.material.mainTextureOffset.x + beltSpeed)%1, beltRend.material.mainTextureOffset.y);
        }
	}
}
