using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//랜덤박스를 클릭한 횟수를 띄워주기 위한 스크립트

public class ButtonClickHandler : MonoBehaviour
{
    public TMP_Text textToDecrease;

    private void Start()
    {
        //시작 시 Text UI(Text)의 초기 텍스트 설정
        textToDecrease.text = "20";
    }

    public void DecreaseTextValue()
    {
        //버튼 클릭 시 TMP_Text의 텍스트 값을 1씩 감소
        int currentValue = int.Parse(textToDecrease.text);
        if (currentValue > 0)
        {
            currentValue--;
            textToDecrease.text = currentValue.ToString();
        }
        //텍스트가 0이 되면 목표 씬으로 이동
        if (currentValue == 0)
        {
            StartCoroutine(TransitionToPOPScene());
        }
    }
    
    public IEnumerator TransitionToPOPScene()
    {

        //대기 시간 (pop 화면 지속 시간)
        yield return new WaitForSeconds(0.05f);

        SceneManager.LoadScene("pop");
    }

}

