using UnityEngine;
using UnityEngine.UI;

public class RandomEnable : MonoBehaviour
{
    public Button[] buttons;

    public void Start()
    {
        //��ũ��Ʈ�� ���۵Ǹ� ��ư�� �������� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ
        RandomizeButtonStates();
    }


    public void RandomizeButtonStates()
    {
        foreach (Button button in buttons)
        {
            //0 �Ǵ� 1�� �������� ���� -> ��ư�� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ
            int randomState = Random.Range(0, 2);
            button.interactable = (randomState == 0) ? false : true;
        }
    }
}