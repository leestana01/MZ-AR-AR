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
        dialog = "로테와 베르테르의 비밀스러운 공간,  이곳 '로테' 백화점 분당점으로  여러분을 초대합니다.  베르테르가 숨겨둔 선물상자가 보이면,  빠르게 클릭해서 열어보세요.  과연 베르테르는 로테를 위해 어떤 선물을 준비했을까요?  오늘도 '로테' 백화점을 방문해주신 여러분들께  로테를 향한 베르테르의 사랑만큼이나  행복한 일만 가득하기를 기원합니다.  다음 화면에서 바로 선물을 찾으러 떠나실 수 있습니다!  준비는 되셨나요?  하나, 둘, 셋...";
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
