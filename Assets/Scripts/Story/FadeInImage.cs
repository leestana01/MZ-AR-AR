using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가

public class FadeInImage : MonoBehaviour
{
    public float fadeDuration = 2.0f;
    public Image fadeImage;

    void Start()
    {
        fadeImage.color = new Color(1, 1, 1, 0);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float targetAlpha = 1.0f;
        float elapsedTime = 0.0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(0, targetAlpha, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = targetAlpha;
        fadeImage.color = color;
    }
}