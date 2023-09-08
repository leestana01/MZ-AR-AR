using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//랜덤박스가 터진 후의 화면(pop scene)을 지속하는 시간을 설정하기 위한 스크립트

public class pop_duration : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(TransitionToQuizScene());
    }

    public IEnumerator TransitionToQuizScene()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("quizpage");
    }
}
