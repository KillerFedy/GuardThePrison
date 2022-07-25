using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    private int _countScenes = 3;

    public void RestartScene()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
=======
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
>>>>>>> 6a899372e934c65c6e9a87b38c3ea6996688178e
=======
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
>>>>>>> 6a899372e934c65c6e9a87b38c3ea6996688178e
    }

    public void StartNextLevel()
    {
        SceneManager.LoadScene(Random.Range(0, _countScenes));
    }
}
