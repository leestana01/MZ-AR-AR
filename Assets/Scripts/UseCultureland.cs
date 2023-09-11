using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCultureland : MonoBehaviour
{
    public GameObject popupPanel; // �˾��� ��Ÿ���� Panel�� ������ ����

    public void Start()
    {
        //�⺻ ȭ��(������) ���� �� �˾� ����
        HidePopup();
    }

    public void ShowPopup()
    {
        //�˾��� ���̰� ����
        popupPanel.SetActive(true);
    }

    public void HidePopup()
    {
        //�˾��� ����
        popupPanel.SetActive(false);
    }
}
