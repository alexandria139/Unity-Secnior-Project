using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneScript : MonoBehaviour
{
    public int SceneToLoad = 1;

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
