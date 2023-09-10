using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//스플래쉬 화면에서 text에 타이핑하는듯한 애니메이션을 추가

public class story_7_keybord : MonoBehaviour
{
    public TMP_Text text;
    string dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = "로테와 베르테르는 아직도  둘만의 추억이 가득했던 작은 집을 그리워하며  이곳 롯데백화점 분당점에서  비밀스러운 데이트를 한다는  소문이 있는데요...";
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
