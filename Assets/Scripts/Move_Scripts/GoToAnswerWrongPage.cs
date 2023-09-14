using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToAnswerWrongPage : MonoBehaviour
{
    public void Move()
    {
        SceneManager.LoadScene("answer_wrong_page"); //¿Ãµø«“ æ¿
    }
}