using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonClickHandler : MonoBehaviour
{
    public TMP_Text textToDecrease;

    private void Start()
    {
        //���� �� Text UI(Text)�� �ʱ� �ؽ�Ʈ ����
        textToDecrease.text = "20";
    }

    public void DecreaseTextValue()
    {
        //��ư Ŭ�� �� TMP_Text�� �ؽ�Ʈ ���� 1�� ����
        int currentValue = int.Parse(textToDecrease.text);
        if (currentValue > 0)
        {
            currentValue--;
            textToDecrease.text = currentValue.ToString();
        }
        //�ؽ�Ʈ�� 0�� �Ǹ� ��ǥ ������ �̵�
        if (currentValue == 0)
        {
            SceneManager.LoadScene("quizpage");
        }
    }
}

