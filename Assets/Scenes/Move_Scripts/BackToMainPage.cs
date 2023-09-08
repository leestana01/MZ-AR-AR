using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainPage : MonoBehaviour
{
    public void Move()
    {
        SceneManager.LoadScene("MainPage"); //¿Ãµø«“ æ¿
    }
}