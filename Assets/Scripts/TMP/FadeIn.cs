using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeIn : MonoBehaviour
{
    public TMP_Text textObject;  // Fade-in 효과를 적용할 Text 오브젝트
    public float fadeTime;  // fade-in에 걸릴 시간 (초)

    // Start 함수에서 코루틴을 시작
    void Start()
    {
        StartCoroutine(FadeTextToFullAlpha());
    }

    // Fade-in 코루틴
    public IEnumerator FadeTextToFullAlpha()
    {
        // 초기 알파값을 0으로 설정
        textObject.color = new Color(textObject.color.r, textObject.color.g, textObject.color.b, 0);

        // 알파값이 1이 될 때까지 점점 증가
        while (textObject.color.a < 1.0f)
        {
            textObject.color = new Color(textObject.color.r, textObject.color.g, textObject.color.b, textObject.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }
    }
}
