using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class exchange : MonoBehaviour
{
    public TextMeshProUGUI aText;
    public TextMeshProUGUI bText;

    private int nowPoint;

    public void Start()
    {
        nowPoint = PlayerPrefs.GetInt("MyPoint", 0);
        aText.text = nowPoint.ToString();
        bText.text = "100";
    }

    public void OnButtonClick()
    {
        int result = nowPoint - int.Parse(bText.text);

        if (result < 0)
        {
            SceneManager.LoadScene("minusPoint"); //교환하고자 하는 포인트가 보유 포인트보다 작으면 minusPoint로 씬 전환
        }
        else
        {
            //현재 보유 포인트를 업데이트
            PlayerPrefs.SetInt("MyPoint", result);
            SceneManager.LoadScene("mypage");
        }
    }
}
