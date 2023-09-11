using UnityEngine;

public class DontDestroyOnLoadManager : MonoBehaviour
{
    private static DontDestroyOnLoadManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //���� ���� ������Ʈ�� �ı����� ����
        }
        else
        {
            Destroy(gameObject); //�̹� �ٸ� �ν��Ͻ��� �ִٸ� ���� ���� ������Ʈ�� �ı�
        }
    }
}