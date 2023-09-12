using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Button 클래스를 사용하기 위한 네임스페이스
using UnityEngine.SceneManagement;
using TMPro; // TextMesh Pro 네임스페이스 추가

public class QuizBeauty : MonoBehaviour
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
            new QuizData("넓은 모공이 고민인 세은이가 되직하고 커버력이 높은 파운데이션을 사용하려 한다. 다음 중 어떤 브러쉬를 사용하는 것이 가장 적합할지 고르시오.", new List<string> { "납작브러쉬", "모공 브러쉬" }, 1),
            new QuizData("베이크드 타입의 블러셔는 라텍스 스펀지로 사용이 가능하다.", new List<string> { "o", "x" }, 0),
            new QuizData("나스에서 명성이 높은 블러셔이며, 퍼스널 컬러가 봄웜이거나 밝은 명도가 잘 어울리는 사람이 사용하기 적합한 블러셔를 고르시오,", new List<string> { "오르가즘", "섹스어필", "딥쓰롯", "마타하리" }, 1),
            new QuizData("수채화로 물들이듯이 발색이 되는 것으로 명성이 높으며, 데이지꽃의 음각이 아름답게 새겨져있는 블러셔의 제품명과 브랜드가 알맞게 연결되어 있는 것을 고르시오.", new List<string> { "나스-래디언스 크림 블러셔", "베네피트-단델리온", "디올-로지글로우", "크리니크-치크팝" }, 3),
            new QuizData("메이크업포에버에서 판매율이 높은 상품으로, 입자가 매우 고와 모공과 요철을 포토샵처럼 가려주는 효과로 유명한 제품을 고르시오.", new List<string> { "더 프로페셔널 마스카라", "아티스트 립 블러쉬", "루즈 아티스트 포에버 매트", "UHD 프레스드 파우더" }, 3),
            new QuizData("얼굴 전체에 발라 유분을 억제하여 메이크업의 지속력을 높이고, 제형이 투명한 제품을 고르시오.", new List<string> { "베네피트 매트레스큐", "베네피트 포어페셔널", "바비브라운 선베이스", "메이크업포에버 매티파잉 프라이머" }, 0),
            new QuizData("물처럼 흐르는 제형이며, 투명하게 물들여주는 효과로 장미꽃처럼 표현할 수 있는 것으로 유명한 제품을 고르시오.", new List<string> { "입생로랑 루쥬 볼립떼 샤인", "디올 루즈 디올 포에버 리퀴드", "베네피트 베네틴트", "나스 에어 매트 립 컬러" }, 2),
            new QuizData("나스에서 판매율이 높은 립 메이크업 상품으로, 직접 깎아 사용하는 타입이며, 드래곤걸 색상과 돌체비타 색상으로 유명한 재품의 이름을 고르시오.", new List<string> { "벨벳 매트 립 펜슬", "파워매트 하이 인텐시티 립 펜슬", "애프터글로우 센슈얼 샤인 립스틱", "에어 매트 립 컬러" }, 0),
            new QuizData("주름 개선과 모공 관리에 탁월한 제품으로, 에스티로더에서 스터디셀러로 판매되는 상품이며, 본명보다 제품의 외관 색상에서 비롯되어 ‘00병’이라고 더욱 많이 불리는 상품의 제품명을 고르시오.", new List<string> { "어드밴스드 나이트 리페어 세럼", "리바이탈라이징 수프림 플러스 유스 파워 소프트 크림", "수프림 단단 소프트 크림", "마이크로 에센스 트리트먼트 로션" }, 0),
            new QuizData("블랙핑크 ‘로제’를 앰버서더로 발탁하며, 기존의 3040 고객뿐만 아니라 1020 고객에게도 다가기 위해 새로운 시도를 추구한 브랜드를 고르시오.", new List<string> { "입생로랑", "맥", "설화수", "에스티로더" }, 2),
            new QuizData("나스에서 출시된 싱글 아이섀도우 제품으로, 고동색의 베이스에 다채로운 글리터가 박혀있다. 아이라인의 경계를 풀어주고 눈매의 그윽함을 더하는 것으로 유명한 이 제품의 이름을 고르시오.", new List<string> { "피렌체", "갈라파고스", "발리", "애쉬 투 애쉬스" }, 1),
            new QuizData("다음 중 퍼퓸과 가장 거리가 먼 브랜드를 고르시오.", new List<string> { "딥디크", "바이레도", "조말론", "찰스 앤 키스" }, 3),
            new QuizData("바비브라운의 싱글섀도우 상품 중, 아이라인의 경계를 풀어주며 음영을 더할 수 있는 것으로 유명한 상품을 고르시오.", new List<string> { "토스트", "앤티크 로즈", "토프", "마호가니" }, 3)
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
