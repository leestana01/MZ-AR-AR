using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMap : MonoBehaviour
{
    public void Move()
    {
        SceneManager.LoadScene("Map"); //¿Ãµø«“ æ¿
    }
}