using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//���÷��� ȭ�鿡�� text�� Ÿ�����ϴµ��� �ִϸ��̼��� �߰�

public class story_6_keybord : MonoBehaviour
{
    public TMP_Text text;
    string dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = "������ �귯,  �Ѹ��� ���� ����  ���������� �ȸ���, �������� ���...  �׷��� ���ó��� �Ե���ȭ�� �д����� �Ǿ��µ���.";
        StartCoroutine(Typing(dialog));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Typing(string talk)
    {
        text.text = null;

        if (talk.Contains("  ")) talk = talk.Replace("  ", "\n");

        for (int i = 0; i < talk.Length; i++)
        {
            text.text += talk[i];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
