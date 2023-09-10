using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStory9 : MonoBehaviour
{

    public float splashScreenDuration = 3.0f;


    public string nextSceneName = "story_9";

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
