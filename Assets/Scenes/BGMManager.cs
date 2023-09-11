using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource bgmAudioSource; //BGM을 재생할 오디오 소스
    public AudioClip yourBGMAudioClip; //Inspector 창에서 할당하기 위한 변수

    private static BGMManager instance; //싱글톤 인스턴스 생성

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //게임 오브젝트(비지엠)를 파괴하지 않도록 설정
            bgmAudioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //비지엠을 시작
        bgmAudioSource.clip = yourBGMAudioClip;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }

    //새로운 비지엠을 시작하는 메서드
    public void PlayNewBGM(AudioClip newBGMAudioClip)
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = newBGMAudioClip;
        bgmAudioSource.Play();
    }
}