using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnApplicationQuit : MonoBehaviour
{

    public Button ButtonQuit;

    public void OnClick()
    {
        if(ButtonQuit.interactable)
        {
            Application.Quit();
        }
        
    }
}
