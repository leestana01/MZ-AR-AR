using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNoticePage : MonoBehaviour
{

    public float splashScreenDuration = 3.0f;


    public string nextSceneName = "noticepage";

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