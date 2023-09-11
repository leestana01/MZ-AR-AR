using UnityEngine;

public class DontDestroyOnLoadManager : MonoBehaviour
{
    private static DontDestroyOnLoadManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //현재 게임 오브젝트를 파괴하지 않음
        }
        else
        {
            Destroy(gameObject); //이미 다른 인스턴스가 있다면 현재 게임 오브젝트를 파괴
        }
    }
}