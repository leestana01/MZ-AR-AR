using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoxClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float scaleChange = 0.9f; // �󸶳� �۾��� ������
    public float duration = 0.1f; // �󸶳� ���� ���ӵ� ������

    private Vector3 originalScale; // ���� ũ�� �����

    void Start()
    {
        originalScale = transform.localScale; // ���� ũ�� ����
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // ���� ȿ�� (�ȵ���̵�� iOS������ �۵�)
        Handheld.Vibrate();

        // ũ�� ���
        StartCoroutine(ScaleDown());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // ũ�� ����
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
