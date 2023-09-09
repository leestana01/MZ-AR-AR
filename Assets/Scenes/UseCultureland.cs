using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCultureland : MonoBehaviour
{
    public GameObject popupPanel; // 팝업을 나타내는 Panel을 연결할 변수

    public void Start()
    {
        //기본 화면(보관함) 시작 시 팝업 숨김
        HidePopup();
    }

    public void ShowPopup()
    {
        //팝업을 보이게 설정
        popupPanel.SetActive(true);
    }

    public void HidePopup()
    {
        //팝업을 숨김
        popupPanel.SetActive(false);
    }
}
