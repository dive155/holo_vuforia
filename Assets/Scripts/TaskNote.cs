using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskNote : MonoBehaviour 
{
	[SerializeField]
    private Text header;

    [SerializeField]
    private Image icon;

    [SerializeField]
    private Text description;

    public void SetNote(Sprite iconSprite, string _description, string _header = "")
    {
		description.text = _description;
		if(_description == "")
		{
			description.gameObject.GetComponentInParent<HorizontalLayoutGroup>().padding.left = 33;
			description.gameObject.SetActive(false);
		}
        icon.sprite = iconSprite;
        //header.text = _header;
		header.text = "";
    }

}
