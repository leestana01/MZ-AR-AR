using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetCategory : MonoBehaviour
{
    public void CategorySet(int category)
    {
        PlayerPrefs.SetInt("Category", category);
        PlayerPrefs.Save();
        SceneManager.LoadScene("ARCam");
    }
}
