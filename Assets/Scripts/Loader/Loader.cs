using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    private int _countScenes = 3;

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCount);
    }

    public void StartNextLevel()
    {
        SceneManager.LoadScene(Random.Range(0, _countScenes));
    }
}
