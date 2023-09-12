using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource bgmAudioSource; //BGM�� ����� ����� �ҽ�
    public AudioClip yourBGMAudioClip; //Inspector â���� �Ҵ��ϱ� ���� ����

    private static BGMManager instance; //�̱��� �ν��Ͻ� ����

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //���� ������Ʈ(������)�� �ı����� �ʵ��� ����
            bgmAudioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //�������� ����
        bgmAudioSource.clip = yourBGMAudioClip;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }

    //���ο� �������� �����ϴ� �޼���
    public void PlayNewBGM(AudioClip newBGMAudioClip)
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = newBGMAudioClip;
        bgmAudioSource.Play();
    }
}