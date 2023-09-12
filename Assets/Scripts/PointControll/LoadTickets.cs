using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTickets : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp.text = PlayerPrefs.GetInt("Tickets", 0).ToString();
    }
}
