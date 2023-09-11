using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainPage : MonoBehaviour
{
    
    public float splashScreenDuration = 3.0f;

    
    public string nextSceneName = "MainPage";

    void Start()
    {
       
        StartCoroutine(ShowSplashScreen());
    }

    IEnumerator ShowSplashScreen()
    {
       
        yield return new WaitForSeconds(splashScreenDuration);

        
        SceneManager.LoadScene(nextSceneName);
    }
}
