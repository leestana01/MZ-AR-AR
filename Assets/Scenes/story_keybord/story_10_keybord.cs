using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//스플래쉬 화면에서 text에 타이핑하는듯한 애니메이션을 추가

public class story_10_keybord : MonoBehaviour
{
    public TMP_Text text;
    string dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = "로테와 베르테르가  새벽에 데이트를 하러 돌아오기 전에,  몰래 선물을 찾아 뭐가 들었는지  살짝 확인해볼까요?  '선물 찾아보기' 라고 써있는 버튼을 누르면  베르테르가 숨겨둔 선물이  어디 있는지 볼 수 있대요.";
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
