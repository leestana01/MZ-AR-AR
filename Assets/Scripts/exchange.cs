using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class exchange : MonoBehaviour
{
    public TextMeshProUGUI aText;
    public TextMeshProUGUI bText;

    public void Start()
    {
        aText.text = "750";
        bText.text = "100";
    }

    public void OnButtonClick()
    {
        int aPoints = int.Parse(aText.text);
        int bPoints = int.Parse(bText.text);
        int result = aPoints - bPoints;

        if (result < 0)
        {
            SceneManager.LoadScene("minusPoint"); //��ȯ�ϰ��� �ϴ� ����Ʈ�� ���� ����Ʈ���� ������ minusPoint�� �� ��ȯ
        }
        else
        {
            //���� ���� ����Ʈ�� ������Ʈ
            aText.text = result.ToString();
            // SceneManager.LoadScene("mypage");
        }
    }
}
