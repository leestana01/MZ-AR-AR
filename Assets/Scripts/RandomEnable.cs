using UnityEngine;
using UnityEngine.UI;

public class RandomEnable : MonoBehaviour
{
    public Button[] buttons;

    public void Start()
    {
        //스크립트가 시작되면 버튼을 무작위로 활성화 또는 비활성화
        RandomizeButtonStates();
    }


    public void RandomizeButtonStates()
    {
        foreach (Button button in buttons)
        {
            //0 또는 1을 무작위로 생성 -> 버튼을 활성화 또는 비활성화
            int randomState = Random.Range(0, 2);
            button.interactable = (randomState == 0) ? false : true;
        }
    }
}