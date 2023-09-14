using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOnClick : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
