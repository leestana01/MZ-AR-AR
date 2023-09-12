using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCategory : MonoBehaviour
{
    public void CategorySet(int category)
    {
        PlayerPrefs.SetInt("Category", category);
    }
}
