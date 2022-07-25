using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinySauceEvents : MonoBehaviour
{
    private void Start()
    {
        TinySauce.OnGameStarted();
    }
    private void OnDestroy()
    {
        TinySauce.OnGameFinished(Time.timeSinceLevelLoad);
    }
}
