using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateUIHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject attentionIcon;
    [SerializeField]
    private GameObject readyIcon;

    public void SetState(bool isReady)
    {
        attentionIcon.SetActive(!isReady);
        readyIcon.SetActive(isReady);
    }
}
