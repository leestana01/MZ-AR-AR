using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class story_keybord : MonoBehaviour
{
    public TMP_Text text;
    public GameObject nextArrow; // 다음 페이지로 넘어갈 수 있다는 단서로 사용할 GameObject
    public string nextSceneName; // Inspector 창에서 설정할 다음 Scene의 이름
    string dialog;
    bool isSkip = false; // 대화를 스킵할지 결정하는 플래그

    // Start is called before the first frame update
    void Start()
    {
        nextArrow.SetActive(false); // 초기에는 화살표를 숨깁니다.
        dialog = text.text; // TMP에서 미리 설정한 대화 내용을 가져옵니다.
        StartCoroutine(Typing(dialog));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isSkip)
            {
                isSkip = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(nextSceneName)) // 다음 Scene 이름이 설정되어 있을 때만 이동
                {
                    SceneManager.LoadScene(nextSceneName);
                }
                else
                {
                    Debug.LogWarning("다음 Scene의 이름이 설정되지 않았습니다.");
                }
            }
        }
    }

    IEnumerator Typing(string talk)
    {
        text.text = null;

        if (talk.Contains("  ")) talk = talk.Replace("  ", "\n");

        for (int i = 0; i < talk.Length; i++)
        {
            if (isSkip)
            {
                // 만약 스킵이 true면, 전체 대사를 한 번에 출력
                text.text = talk;
                break;
            }
            text.text += talk[i];
            yield return new WaitForSeconds(0.07f);
        }

        // 대화가 끝나면 화살표를 표시
        isSkip = true;
        nextArrow.SetActive(true);
        StartCoroutine(AnimateArrow());
    }
    
    // 화살표에 반짝이는 애니메이션을 적용하는 코루틴
    IEnumerator AnimateArrow()
    {
        TMP_Text arrowText = nextArrow.GetComponent<TMP_Text>();
        Color originalColor = arrowText.color;

        for(int i=0; i<3; i++)
        {
            // 투명도를 낮춤
            arrowText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
            yield return new WaitForSeconds(0.3f);

            // 원래 투명도로 복구
            arrowText.color = originalColor;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
