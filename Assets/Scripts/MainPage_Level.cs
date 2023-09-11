using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int level; // 레벨 정보
    public TMP_Text level_display; // 레벨을 표시할 텍스트
    public TMP_Text level_name; // 레벨 이름을 표시할 텍스트

    // Start is called before the first frame update
    void Start()
    {
        UpdateLevelText();
    }

    // 레벨 텍스트와 레벨 이름을 업데이트하는 함수
    void UpdateLevelText()
    {
        // 레벨 표시 업데이트
        level_display.text = level.ToString();

        // 레벨 이름 업데이트
        if (level < 10)
        {
            level_name.text = "예비 탐험가";
        }
        else if (level >= 10 && level < 20)
        {
            level_name.text = "탐험 견습생";
        }
        else if (level >= 20 && level < 30)
        {
            level_name.text = "탐험가";
        }
        else if (level >= 30 && level < 40)
        {
            level_name.text = "숙련 탐험가";
        }
        else if (level >= 40 && level < 50)
        {
            level_name.text = "탐험 전문가";
        }
        else if (level >= 50)
        {
            level_name.text = "탐험의 대가";
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        // 만약 레벨이 변경되는 로직이 있다면, 그 후에 UpdateLevelText()를 호출
    }
}
