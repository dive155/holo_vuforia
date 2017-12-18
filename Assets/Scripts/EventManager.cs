using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour 
{
    public static event Action onDoneRecognized;

    public static void OnDoneRecognized()
	{
		if (onDoneRecognized != null)
		{
            onDoneRecognized();
		}
	}
}
