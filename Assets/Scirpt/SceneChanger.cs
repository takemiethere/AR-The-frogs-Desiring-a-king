using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        //Reset Time
        Time.timeScale = 1;
        
        SceneManager.LoadScene(sceneName);
    }
}