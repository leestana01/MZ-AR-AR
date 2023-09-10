using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//스플래쉬 화면에서 text에 타이핑하는듯한 애니메이션을 추가

public class story_11_keybord : MonoBehaviour
{
    public TMP_Text text;
    string dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = "로테와 베르테르의 비밀스러운 공간,  이곳 '로테' 백화점에  여러분을 초대합니다.  베르테르가 숨겨둔 선물을 찾아  몰래 확인해보고,  로테를 향한 베르테르의 사랑만큼이나  행복한 일만 가득하세요!";
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
