using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//랜덤박스 클릭이 가능한 남은 시간(초)을 보여주기 위한 스크립트

public class TimeAttack : MonoBehaviour
{
    public TMP_Text countdownText;
    // private int countdownValue = 30;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        int countdownValue = int.Parse(countdownText.text);
        while (countdownValue > 0)
        {
            yield return new WaitForSeconds(1f);
            countdownValue--;
            countdownText.text = countdownValue.ToString();
        }

        SceneManager.LoadScene("TimeOver");
    }
}

