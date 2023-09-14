using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOnTime : MonoBehaviour
{

    public float splashScreenDuration = 0.0f;


    public string nextSceneName = "";

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