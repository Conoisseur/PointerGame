using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadPrevScene : MonoBehaviour
{

    public void LoadScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex - 1;
        if (index < 0)
        {
            index = SceneManager.sceneCountInBuildSettings - 1;
        }
        SceneManager.LoadScene(index);
    }
}
