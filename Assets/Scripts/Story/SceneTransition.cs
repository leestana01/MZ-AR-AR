using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Canvas canvas;
    public Sprite oldPaperSprite;  // Editor에서 할당할 Sprite
    public float fadeDuration = 1.5f;
    private Image fadeImage;

    void Start()
    {
        GameObject imageObject = new GameObject("FadeImage");
        fadeImage = imageObject.AddComponent<Image>();
        imageObject.transform.SetParent(canvas.transform, false);

        fadeImage.rectTransform.anchorMin = new Vector2(0, 0);
        fadeImage.rectTransform.anchorMax = new Vector2(1, 1);
        fadeImage.rectTransform.offsetMin = new Vector2(0, 0);
        fadeImage.rectTransform.offsetMax = new Vector2(0, 0);

        fadeImage.sprite = oldPaperSprite;
        fadeImage.color = new Color(1, 1, 1, 0);

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {

        yield return new WaitForSeconds(2.5f);

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
