using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTickets : MonoBehaviour
{
    
    public TextMeshProUGUI ticket1;
    public TextMeshProUGUI ticket3;
    public TextMeshProUGUI ticket5;
    public TextMeshProUGUI ticket10;

    // Start is called before the first frame update
    void Start()
    {
        ticket1.text = PlayerPrefs.GetInt("Ticket1", 0).ToString();
        ticket3.text = PlayerPrefs.GetInt("Ticket3", 0).ToString();
        ticket5.text = PlayerPrefs.GetInt("Ticket5", 0).ToString();
        ticket10.text = PlayerPrefs.GetInt("Ticket10", 0).ToString();
    }
}
