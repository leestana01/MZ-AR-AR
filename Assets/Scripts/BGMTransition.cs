using UnityEngine;

public class BGMTransition : MonoBehaviour
{
    public AudioClip newBGMAudioClip; //Inspector â���� �Ҵ��ϱ� ���� ����

    private void Start()
    {
        //BGMManager�� ã�Ƽ� ������ ��ȯ ��û
        BGMManager bgmManager = FindObjectOfType<BGMManager>();
        if (bgmManager != null)
        {
            bgmManager.PlayNewBGM(newBGMAudioClip);
        }

    }
}