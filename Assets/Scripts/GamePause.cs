using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GamePause : MonoBehaviour
{
    [SerializeField] GameObject canvasUI;
    [SerializeField] bool isPaused;

    [SerializeField] StudioGlobalParameterTrigger trigger;

    private void OnEnable()
    {
        InputManager.OnGamePause += Pause;
    }


    private void OnDisable()
    {
        InputManager.OnGamePause -= Pause;
    }


    void Pause()
    {
        if(!isPaused)
        {
            canvasUI.SetActive(true);
            isPaused = true;
            trigger.Value = 1;
        }
        else
        {
            canvasUI.SetActive(false);
            trigger.Value = 0;
            isPaused = false;
        }
    }

}
