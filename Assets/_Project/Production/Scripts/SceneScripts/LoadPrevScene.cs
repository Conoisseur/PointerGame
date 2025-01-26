using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadPrevScene : MonoBehaviour
{

    public void LoadScene()
    {
        bool loaded = false;
        int index = SceneManager.GetActiveScene().buildIndex;
        do
        {
            index -= 1;
            if (index < 0)
            {
                index = SceneManager.sceneCountInBuildSettings - 1;
            }
            Debug.Log(index);
            loaded = SceneLoader.Instance.LoadScene(index);
        } while (!loaded);
    }
}
