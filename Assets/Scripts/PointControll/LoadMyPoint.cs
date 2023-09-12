using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadMyPoint : MonoBehaviour
{
    public TextMeshProUGUI myPointText;

    // Start is called before the first frame update
    void Start()
    {
        myPointText.text = $"{PlayerPrefs.GetInt("MyPoint", 0).ToString()} P";
    }
}
