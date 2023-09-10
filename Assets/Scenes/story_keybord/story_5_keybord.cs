using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//스플래쉬 화면에서 text에 타이핑하는듯한 애니메이션을 추가

public class story_5_keybord : MonoBehaviour
{
    public TMP_Text text;
    string dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = "그리고 먼 훗날 둘의 사랑을 인정하게 된 알베르토가,  로테와 베르테르를 위해서  분당에 작은 집을 지어주었습니다.";
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
