using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�����ڽ��� ���� ���� ȭ��(pop scene)�� �����ϴ� �ð��� �����ϱ� ���� ��ũ��Ʈ

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
