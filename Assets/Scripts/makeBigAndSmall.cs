using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoxClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float scaleChange = 0.9f; // 얼마나 작아질 것인지
    public float duration = 0.1f; // 얼마나 오래 지속될 것인지

    private Vector3 originalScale; // 원래 크기 저장용

    void Start()
    {
        originalScale = transform.localScale; // 원래 크기 저장
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 진동 효과 (안드로이드와 iOS에서만 작동)
        Handheld.Vibrate();

        // 크기 축소
        StartCoroutine(ScaleDown());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 크기 복구
        StartCoroutine(ScaleUp());
    }

    IEnumerator ScaleDown()
    {
        Vector3 targetScale = originalScale * scaleChange;
        Vector3 diffScale = originalScale - targetScale;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            float t = counter / duration;
            transform.localScale = originalScale - diffScale * t;
            yield return null;
        }

        transform.localScale = targetScale;
    }

    IEnumerator ScaleUp()
    {
        Vector3 targetScale = originalScale;
        Vector3 currentScale = transform.localScale;
        Vector3 diffScale = targetScale - currentScale;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            float t = counter / duration;
            transform.localScale = currentScale + diffScale * t;
            yield return null;
        }

        transform.localScale = originalScale;
    }
}
