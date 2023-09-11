using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//���÷��� ȭ�鿡�� text�� Ÿ�����ϴµ��� �ִϸ��̼��� �߰�

public class story_11_keybord : MonoBehaviour
{
    public TMP_Text text;
    string dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = "���׿� �����׸��� ��н����� ����,  �̰� '����' ��ȭ�� �д�������  �������� �ʴ��մϴ�.  �����׸��� ���ܵ� �������ڰ� ���̸�,  ������ Ŭ���ؼ� �������.  ���� �����׸��� ���׸� ���� � ������ �غ��������?  ���õ� '����' ��ȭ���� �湮���ֽ� �����е鲲  ���׸� ���� �����׸��� �����ŭ�̳�  �ູ�� �ϸ� �����ϱ⸦ ����մϴ�.  ���� ȭ�鿡�� �ٷ� ������ ã���� ������ �� �ֽ��ϴ�!  �غ�� �Ǽ̳���?  �ϳ�, ��, ��...";
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
