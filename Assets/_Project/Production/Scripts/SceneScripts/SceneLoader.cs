using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityUtils;

public class SceneLoader : PersistentSingleton<SceneLoader>
{
    public int endingSceneIndex = -1;    // excluded from loading

    public bool LoadScene(int sceneIndex)
    {
        if (sceneIndex >= 0 || sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            if (sceneIndex == endingSceneIndex)
            {
                return false;
            }
            else
            {
                SceneManager.LoadScene(sceneIndex);
                return true;
            }
        }

        return false;
    }

    public void LoadEndScene()
    {
        if (endingSceneIndex < 0 || endingSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("Ending Scene not found! Invalid ending scene index.");
        }
        else
        {
            SceneManager.LoadScene(endingSceneIndex);
        }
    }
}
