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
            SceneManager.LoadScene("minusPoint"); //교환하고자 하는 포인트가 보유 포인트보다 작으면 minusPoint로 씬 전환
        }
        else
        {
            //현재 보유 포인트를 업데이트
            aText.text = result.ToString();
            // SceneManager.LoadScene("mypage");
        }
    }
}
