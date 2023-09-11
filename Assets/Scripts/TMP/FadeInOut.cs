using System.Collections;
using UnityEngine;
using TMPro;

public class FadeInOut : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float fadeTime = 3f;
    public float waitTime = 3f;  // Fade-in과 Fade-out 사이에 대기할 시간 (초)

    // Start 함수에서 코루틴을 시작
    void Start()
    {
        StartCoroutine(FadeTextToFullAlpha());
    }

    // Fade-in 코루틴
    public IEnumerator FadeTextToFullAlpha()
    {
        Color currentColor = textMeshPro.color;
        textMeshPro.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0f);

        while (textMeshPro.color.a < 1.0f)
        {
            currentColor.a = textMeshPro.color.a + (Time.deltaTime / fadeTime);
            textMeshPro.color = currentColor;
            yield return null;
        }

        // Fade-in이 끝난 후 지정된 시간만큼 대기
        yield return new WaitForSeconds(waitTime);

        // Fade-out 시작
        StartCoroutine(FadeTextToZeroAlpha());
    }

    // Fade-out 코루틴
    public IEnumerator FadeTextToZeroAlpha()
    {
        Color currentColor = textMeshPro.color;
        while (textMeshPro.color.a > 0.0f)
        {
            currentColor.a = textMeshPro.color.a - (Time.deltaTime / fadeTime);
            textMeshPro.color = currentColor;
            yield return null;
        }
    }
}
