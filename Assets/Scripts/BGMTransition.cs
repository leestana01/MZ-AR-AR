using UnityEngine;

public class BGMTransition : MonoBehaviour
{
    public AudioClip newBGMAudioClip; //Inspector 창에서 할당하기 위한 변수

    private void Start()
    {
        //BGMManager를 찾아서 비지엠 전환 요청
        BGMManager bgmManager = FindObjectOfType<BGMManager>();
        if (bgmManager != null)
        {
            bgmManager.PlayNewBGM(newBGMAudioClip);
        }

    }
}