using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTicket : MonoBehaviour
{
    
    public TextMeshProUGUI ticket;

    // Start is called before the first frame update
    void Start()
    {
        int ticket1 = PlayerPrefs.GetInt("Ticket1", 0);
        int ticket3 = PlayerPrefs.GetInt("Ticket3", 0);
        int ticket5 = PlayerPrefs.GetInt("Ticket5", 0);
        int ticket10 = PlayerPrefs.GetInt("Ticket10", 0);

        ticket.text = (ticket1 + ticket3 + ticket5 + ticket10).ToString();
    }
}
