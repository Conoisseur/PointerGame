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
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
