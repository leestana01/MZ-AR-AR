using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("TreasureFound", PlayerPrefs.GetInt("TreasureFound", 0)+1 );
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
