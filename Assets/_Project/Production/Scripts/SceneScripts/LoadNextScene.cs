using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextScene : MonoBehaviour
{
    public void LoadScene()
    {
        bool loaded = false;
        int index = SceneManager.GetActiveScene().buildIndex;
        
        do
        {
            index += 1;
            if (index >= SceneManager.sceneCountInBuildSettings)
            {
                index = 0;
            }
            // Debug.Log(index);
            loaded = SceneLoader.Instance.LoadScene(index);
        } while (!loaded);
    }
}
