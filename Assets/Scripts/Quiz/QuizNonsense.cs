using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Button 클래스를 사용하기 위한 네임스페이스
using UnityEngine.SceneManagement;
using TMPro; // TextMesh Pro 네임스페이스 추가

public class QuizNonsense : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public GameObject optionButtonPrefab;
    public Transform optionButtonParent;

    public class QuizData
    {
        public string question;
        public List<string> options;
        public int correctAnswer;

        public QuizData(string question, List<string> options, int correctAnswer)
        {
            this.question = question;
            this.options = options;
            this.correctAnswer = correctAnswer;
        }
    }

    List<QuizData> quizDataList;
    QuizData currentQuizData;

    void Start()
    {
        if (PlayerPrefs.GetInt("Category", 0) != 2) {
            return;
        }
        // 문제와 선택지, 정답을 리스트에 추가한다.
        quizDataList = new List<QuizData>
        {
            new QuizData("가장 급하게 만들어먹은 떡은?", new List<string> { "찹쌀떡", "무지개떡", "헐레벌떡", "송편" }, 2),
            new QuizData("1 더하기 1은?", new List<string> { "11", "2", "+", "중노동" }, 3),
            new QuizData("겨울에만 나타나는 사람은?", new List<string> { "붕어빵 가게 사장님", "어묵 가게 사장님", "손이 꽁꽁 얼어도 아이스아메리카노를 마셔야 하는 사람", "눈사람" }, 3),
            new QuizData("놀부가 가장 좋아하는 술은?", new List<string> { "심술", "참이슬", "처음처럼", "막걸리" }, 0),
            new QuizData("맞으면 맞을수록 좋은 것은?", new List<string> { "손바닥", "뺨", "시험문제", "종아리" }, 2),
            new QuizData("닭은 닭인데 먹지 못하는 닭은?", new List<string> { "이겼닭", "치킨이닭", "무정란", "까닭" }, 3),
            new QuizData("근심이 많은 사람이 즐겨 먹는 고기 부위는?", new List<string> { "꽃등심", "알등심", "안창살", "안심" }, 3),
            new QuizData("63빌딩에서 떨어져도 살 수 있는 방법은?", new List<string> { "매트리스 위로 떨어진다", "구급차를 미리 불러둔다", "vr 게임 속에서 떨어진다", "1층에서 떨어진다" }, 3),
            new QuizData("마른 옷은 벗고 젖은 옷만 입는 것은?", new List<string> { "예비 감기환자", "예비 독감환자", "빨랫줄", "옷걸이" }, 2),
            new QuizData("죽지 않는 산맥은?", new List<string> { "니노 막시무스", "카이저", "쏘제", "안데스" }, 3),
            new QuizData("어부들이 가장 싫어하는 연예인은?", new List<string> { "김태희", "염혜란", "황정민", "배철수" }, 3),
            new QuizData("너무 뜨거워서 먹지 못하는 과일은?", new List<string> { "백도", "딱딱한 복숭아", "물렁한 복숭아", "천도복숭아" }, 3),
            new QuizData("고등학생이 가장 싫어하는 나무는?", new List<string> { "공부나무", "모고나무", "수행나무", "야자나무" }, 0),
            new QuizData("거지가 가장 싫어하는 색은?", new List<string> { "흰색", "인색", "청색", "적색" }, 1),
            new QuizData("여름을 가장 시원하게 보내는 사람은?", new List<string> { "공포영화 보는 사람", "바람난 사람", "은행에 있는 사람", "바다로 피서간 사람" }, 1),
            new QuizData("피도 눈물도 없는 아버지는?", new List<string> { "로봇아빠", "허수아비", "ai아빠", "아바타아빠" }, 1),
            new QuizData("겉으로는 눈물을 흘리지만 속으로는 타들어가는 것은?", new List<string> { "시험치는 학생", "출근하는 직장인", "양초", "오류를 해결하는 개발자" }, 2),
            new QuizData("하늘의 별 따기보다 어려운 것은?", new List<string> { "하늘로 올라가기", "별을 담을 바구니 마련하기", "별의 무게 감당하기", "하늘에 별 달기" }, 3),
            new QuizData("아이스크림이 갑자기 죽은 이유는?", new List<string> { "냉장고 고장", "소화", "차가와서", "폭염" }, 2)
        };

        DisplayRandomQuestion();
    }

    void DisplayRandomQuestion()
    {
        // 랜덤한 문제를 선택한다.
        int randomIndex = Random.Range(0, quizDataList.Count);
        currentQuizData = quizDataList[randomIndex];

        // 문제를 화면에 표시한다.
        questionText.text = currentQuizData.question;

        // 기존의 선택지 버튼들을 삭제한다.
        foreach (Transform child in optionButtonParent)
        {
            Destroy(child.gameObject);
        }

        // 선택지 버튼을 생성한다.
        float buttonOffsetY = 0; // Y축 기준 버튼의 위치를 조절할 변수
        for (int i = 0; i < currentQuizData.options.Count; i++)
        {
            GameObject optionButton = Instantiate(optionButtonPrefab, optionButtonParent);
            
            // 버튼 위치 조절을 위해 RectTransform을 가져온다.
            RectTransform rectTransform = optionButton.GetComponent<RectTransform>();
            // 버튼의 위치를 Y축으로 -30씩 내린다. (버튼 높이와 여백을 고려해서 조절 가능)
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, buttonOffsetY);
            buttonOffsetY -= 200;

            // Image와 Button 컴포넌트를 활성화합니다.
            Image imgComponent = optionButton.GetComponent<Image>();
            if (imgComponent != null) imgComponent.enabled = true;

            Button btnComponent = optionButton.GetComponent<Button>();
            if (btnComponent != null) btnComponent.enabled = true;

            // TextMeshProUGUI 컴포넌트를 찾아 활성화합니다.
            TextMeshProUGUI tmpComponent = optionButton.GetComponentInChildren<TextMeshProUGUI>(true); // true를 넣어서 비활성화된 컴포넌트도 찾을 수 있습니다.
            if (tmpComponent != null)
            {
                tmpComponent.enabled = true; // 컴포넌트를 활성화합니다.
                tmpComponent.text = currentQuizData.options[i]; // 선택지의 텍스트를 설정합니다.
            }
            

            int optionIndex = i;
            optionButton.GetComponent<Button>().onClick.AddListener(() => OnOptionClicked(optionIndex));
        }
    }

    void OnOptionClicked(int optionIndex)
    {
        if (optionIndex == currentQuizData.correctAnswer)
        {
            PlayerPrefs.SetInt("MyPoint", PlayerPrefs.GetInt("MyPoint",0) + 200);
            SceneManager.LoadScene("answerpage");
        }
        else
        {
            PlayerPrefs.SetInt("MyPoint", PlayerPrefs.GetInt("MyPoint",0) + 50);
            SceneManager.LoadScene("answer_wrong_page");
        }
    }
}
