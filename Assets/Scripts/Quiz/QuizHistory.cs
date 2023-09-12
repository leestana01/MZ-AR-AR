using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Button 클래스를 사용하기 위한 네임스페이스
using UnityEngine.SceneManagement;
using TMPro; // TextMesh Pro 네임스페이스 추가

public class QuizHistory : MonoBehaviour
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
        // 문제와 선택지, 정답을 리스트에 추가한다.
        quizDataList = new List<QuizData>
        {
            new QuizData("롯데의 생일을 고르시오.", new List<string> { "1948년 4월 28일", "1948년 6월 28일", "1958년 1월 18일", "1958년 1월 10일" }, 1),
            new QuizData("롯데백화점 분당점이 개점한 날짜를 고르시오.", new List<string> { "1999년 3월 1일", "1999년 4월 1일", "2002년 3월 1일", "2004년 4월 1일" }, 1),
            new QuizData("OX문제: 롯데백화점 분당점은 경기도 내 첫 번째 롯데백화점이다.", new List<string> { "O", "X" }, 0),
            new QuizData("OX문제: 롯데백화점 분당점의 지하2층에는 북스리브로가 위치해있다.", new List<string> { "O", "X" }, 0),
            new QuizData("다음 중 롯데의 본사가 있는 곳을 고르시오.", new List<string> { "서울특별시 송파구 올림픽로 300", "서울특별시 송파구 올림픽로 360", "서울특별시 송파구 올림픽로 400", "서울특별시 송파구 올림픽로 460" }, 0),
            new QuizData("롯데의 탄생에 대해 틀린 정보를 고르시오.", new List<string> { "롯데의 창업주는 신격호이다.", "신격호가 개발한 껌의 인기가 너무 좋아서 1948년 롯데가 설립되었다.", "‘롯데’라는 이름은 소설 <젊은 베르테르의 슬픔>에서 여주인공의 이름인 샤를로테의 발음을 빌려온 것이다.", "일본 롯데제과의 캐치프레이즈는 ‘손 안의 연인’이다." }, 3),
            new QuizData("아래에 열거된 롯데의 역사 중 가장 먼저 일어난 일을 고르시오.", new List<string> { "한국 롯데가 경영권 다툼으로 와해되었다.", "신격호의 동생 신철호가 농심을 설립했다.", "신철호가 공문서 위조 혐의로 구속되었다.", "1968년 동방아루미를 ‘동방물산’으로 개칭하였다." }, 0),
            new QuizData("‘롯데리아’의 1호점이 세워진 연도를 고르시오.", new List<string> { "1972", "1976", "1978", "1979" }, 3),
            new QuizData("‘롯데 자이언츠’가 창립된 연도를 고르시오.", new List<string> { "1980", "1981", "1982", "1983" }, 2),
            new QuizData("‘롯데 마트’가 런칭된 연도를 고르시오.", new List<string> { "1990", "1991", "1992", "1993" }, 3),
            new QuizData("‘롯데시네마’가 런칭된 연도를 고르시오.", new List<string> { "1995", "1997", "1999", "2001" }, 2)
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
            SceneManager.LoadScene("answerpage");
        }
        else
        {
            SceneManager.LoadScene("answer_wrong_page");
        }
    }
}
