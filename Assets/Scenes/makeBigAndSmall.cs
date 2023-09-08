using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�ڽ��� Ŭ���� ������ Ŀ���ٰ� �۾����� ����� ���� ��ũ��Ʈ

public class makeBigAndSmall : MonoBehaviour
{
    private Button button;
    private RectTransform rectTransform;
    private Vector2 originalSize;
    private Vector2 targetSize;
    private float animationDuration = 0.2f;
    private float currentTime = 0f;
    private bool isAnimating = false;
    //private bool isButtonClicked = false; //��ư�� Ŭ���ƴ°� �ƴѰ�?

    public void Start()
    {
        //��ư �� RectTransform ������Ʈ�� �����´�
        button = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();

        //�ʱ� �����ڽ� ��ư�� ũ�⸦ �����Ѵ�
        originalSize = rectTransform.sizeDelta;
        targetSize = originalSize;

        //��ư Ŭ�� �̺�Ʈ�� �Լ��� ������
        button.onClick.AddListener(ChangeSize);
    }

    public void Update()
    {
        //���� �ִϸ��̼� ���̸� ũ�� ũ�� ����
        if (isAnimating)
        {
            currentTime += Time.deltaTime;
            float t = Mathf.Clamp01(currentTime / animationDuration);
            rectTransform.sizeDelta = Vector2.Lerp(originalSize, targetSize, t);

            if (t >= 1f)
            {
                isAnimating = false;
                currentTime = 0f;
            }
        }
    }

    public void ChangeSize()
    {

        if (isAnimating)
        {
            return;
        }

        //��ư ũ�� ����
        if (rectTransform.sizeDelta == originalSize)
        {
            //��ư�� Ŭ���Ǿ��� �� ũ�⸦ Ű���
            targetSize = originalSize * 1.5f;
        }
        else
        {
            //��ư�� Ŭ������ ���� ���¶�� �ʱ� ������ ũ�Ⱑ �ȴ�
            targetSize = originalSize;
        }

        isAnimating = true;
    }
}
