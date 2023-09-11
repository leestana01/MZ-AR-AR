using System.Collections;
using UnityEngine;
using TMPro;

public class FadeOut : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float fadeTime = 3f;

    // Start 함수에서 Fade-out 코루틴을 시작
    void Start()
    {
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
