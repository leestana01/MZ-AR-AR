using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//박스를 클릭할 때마다 커졌다가 작아지는 기능을 위한 스크립트

public class makeBigAndSmall : MonoBehaviour
{
    private Button button;
    private RectTransform rectTransform;
    private Vector2 originalSize;
    private Vector2 targetSize;
    private float animationDuration = 0.2f;
    private float currentTime = 0f;
    private bool isAnimating = false;
    //private bool isButtonClicked = false; //버튼이 클릭됐는가 아닌가?

    public void Start()
    {
        //버튼 및 RectTransform 컴포넌트를 가져온다
        button = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();

        //초기 랜덤박스 버튼의 크기를 저장한다
        originalSize = rectTransform.sizeDelta;
        targetSize = originalSize;

        //버튼 클릭 이벤트에 함수를 연결함
        button.onClick.AddListener(ChangeSize);
    }

    public void Update()
    {
        //만약 애니메이션 중이면 크게 크기 변경
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

        //버튼 크기 변경
        if (rectTransform.sizeDelta == originalSize)
        {
            //버튼이 클릭되었을 때 크기를 키운다
            targetSize = originalSize * 1.5f;
        }
        else
        {
            //버튼이 클릭되지 않은 상태라면 초기 설정한 크기가 된다
            targetSize = originalSize;
        }

        isAnimating = true;
    }
}
