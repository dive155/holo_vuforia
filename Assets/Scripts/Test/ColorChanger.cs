using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ColorChanger : MonoBehaviour, IInputClickHandler {

    [SerializeField] List<Color> colors;
    Renderer rend;
    int curColor = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

	public void OnInputClicked(InputClickedEventData eventData)
    {
        ChangeColor();
    }

    public void ChangeColor()
    {
        rend.material.color = colors[curColor];
        curColor++;
        curColor %= colors.Count;
    }

    public void Respawn()
    {
        Transform cam = Camera.main.transform;
        gameObject.transform.position = cam.position + cam.up * 1 + cam.forward * 1;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
