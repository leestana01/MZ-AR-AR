using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GrowingBox : MonoBehaviour
{
    public Image image;
    public Sprite newImage;
    public float transitionDuration = 1.0f;
    public string targetSceneName;

    void Start()
    {
        image.sprite = newImage;
        image.color = new Color(1, 1, 1, 0); //�����ϴٰ� ���̵��� ������ ����
        StartCoroutine(TransitionImage());
    }

    IEnumerator TransitionImage()
    {
        //�̹����� 1�� ���� ǥ��
        float startTime = Time.time;
        while (Time.time - startTime < 1.0f)
        {
            float alpha = (Time.time - startTime) / 1.0f;
            image.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        image.sprite = newImage;
        float targetScale = 2.0f;
        float startScale = 1.0f;
        startTime = Time.time;

        while (Time.time - startTime < transitionDuration)
        {
            float t = (Time.time - startTime) / transitionDuration;
            image.transform.localScale = Vector3.one * Mathf.Lerp(startScale, targetScale, t);
            yield return null;
        }

        image.transform.localScale = Vector3.one * targetScale;
        image.color = Color.white;

        SceneManager.LoadScene(targetSceneName);
    }

    void Update()
    {

    }
}
