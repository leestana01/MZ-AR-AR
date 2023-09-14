using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Button 클래스를 사용하기 위한 네임스페이스
using UnityEngine.SceneManagement;
using TMPro; // TextMesh Pro 네임스페이스 추가

public class QuizMath : MonoBehaviour
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
        if (PlayerPrefs.GetInt("Category", 0) != 1) {
            return;
        }
        // 문제와 선택지, 정답을 리스트에 추가한다.
        quizDataList = new List<QuizData>
        {
            new QuizData("345 + 219는?", new List<string> { "561", "562", "563", "564" }, 3),
            new QuizData("764 – 328은?", new List<string> { "435", "436", "437", "438" }, 1),
            new QuizData("2/5 + 3/5은?", new List<string> { "1", "2", "3", "4" }, 0),
            new QuizData("3/4 – 1/4은?", new List<string> { "1/2", "1/3", "1/4", "1/5" }, 0),
            new QuizData("0.25 x 8은?", new List<string> { "1", "2", "3", "4" }, 1),
            new QuizData("3.6 ÷ 2은?", new List<string> { "1.7", "1.8", "1.9", "1.3" }, 1),
            new QuizData("240의 15%는?", new List<string> { "32", "34", "36", "38" }, 2),
            new QuizData("80의 75%는?", new List<string> { "50", "60", "70", "80" }, 1),
            new QuizData("정사각형의 한 변의 길이가 6cm일 때, 넓이는?", new List<string> { "33cm^2", "36cm^2", "38cm^2", "40cm^2" }, 1),
            new QuizData("반지름이 5cm인 원의 둘레는? 가장 가까운 값을 고르시오.", new List<string> { "31.12", "31.22", "31.32", "31.42" }, 3),
            new QuizData("x + 8 = 15에서 x는?", new List<string> { "5", "6", "7", "8" }, 2),
            new QuizData("2x = 18에서 x는?", new List<string> { "9", "10", "11", "12" }, 0),
            new QuizData("12 + 15 + 18 + 20 + 22의 평균은?", new List<string> { "17.1", "17.2", "17.3", "17.4" }, 3),
            new QuizData("12 + 15 + 18 + 20 + 22의 중앙값은?", new List<string> { "10", "11", "12", "13" }, 3),
            new QuizData("주사위를 던져서 3이 나올 확률은?", new List<string> { "1/5", "1/6", "1/7", "1/8" }, 1),
            new QuizData("직각 삼각형에서 빗변의 길이가 10cm이고 한 높이의 길이가 6cm일 때, 다른 높이의 길이는?", new List<string> { "5cm", "6cm", "7cm", "8cm" }, 3),
            new QuizData("이등변 삼각형의 두 각도가 45도일 때, 나머지 각도는?", new List<string> { "70도", "80도", "90도", "100도" }, 2),
            new QuizData("직각 삼각형에서 빗변의 길이가 10cm이고 한 다른 변의 길이가 6cm일 때, 다른 직각 변의 길이는?", new List<string> { "8cm", "9cm", "10cm", "11cm" }, 0),
            new QuizData("정사각형의 한 변의 길이가 9cm일 때, 넓이는 얼마인가?", new List<string> { "54", "63", "72", "81" }, 3),
            new QuizData("직사각형의 가로 길이가 12cm이고 세로 길이가 8cm일 때, 이 직사각형의 둘레는?", new List<string> { "30cm", "40cm", "50cm", "60cm" }, 1),
            new QuizData("반지름이 6cm인 원의 넓이는 얼마인가?", new List<string> { "12파이", "24파이", "30파이", "36파이" }, 3)
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
