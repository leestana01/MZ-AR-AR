using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class exchange : MonoBehaviour
{
    public TextMeshProUGUI ticket1;
    public TextMeshProUGUI ticket3;
    public TextMeshProUGUI ticket5;
    public TextMeshProUGUI ticket10;

    private int nowPoint;
    // public TextMeshProUGUI aText;
    // public TextMeshProUGUI bText;


    public void Start()
    {
        nowPoint = PlayerPrefs.GetInt("MyPoint", 0);
        // aText.text = nowPoint.ToString();
        // bText.text = "100";
    }

    public void OnButtonClick()
    {
        int ticketPrice1 = int.Parse(ticket1.text) * 30000;
        int ticketPrice3 = int.Parse(ticket3.text) * 58000;
        int ticketPrice5 = int.Parse(ticket5.text) * 145000;
        int ticketPrice10 = int.Parse(ticket10.text) * 270000;
        // Debug.Log(int.Parse(ticket1.text));
        // Debug.Log(int.Parse(ticket3.text));
        // Debug.Log(int.Parse(ticket5.text));
        // Debug.Log(int.Parse(ticket10.text));

        int result = ticketPrice1 + ticketPrice3 + ticketPrice5 + ticketPrice10;

        if (nowPoint < result) {
            SceneManager.LoadScene("minusPoint");
            return;
        }

        PlayerPrefs.SetInt("MyPoint", nowPoint - result);
        PlayerPrefs.SetInt("Ticket1", int.Parse(ticket1.text));
        PlayerPrefs.SetInt("Ticket3", int.Parse(ticket3.text));
        PlayerPrefs.SetInt("Ticket5", int.Parse(ticket5.text));
        PlayerPrefs.SetInt("Ticket10", int.Parse(ticket10.text));
        PlayerPrefs.Save();
        SceneManager.LoadScene("TicketNow");

        // int result = nowPoint - int.Parse(bText.text);

        // if (result < 0)
        // {
        //     SceneManager.LoadScene("minusPoint"); //교환하고자 하는 포인트가 보유 포인트보다 작으면 minusPoint로 씬 전환
        // }
        // else
        // {
        //     //현재 보유 포인트를 업데이트
        //     PlayerPrefs.SetInt("MyPoint", result);
        //     SceneManager.LoadScene("mypage");
        // }
    }
}
