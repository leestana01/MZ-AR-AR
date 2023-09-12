using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ButtonSound : MonoBehaviour
{
    public Button button; //��ư�� ����
    public AudioClip soundClip; //�Ҹ�
    public AudioMixerGroup audioMixerGroup;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.outputAudioMixerGroup = audioMixerGroup;

        button.onClick.AddListener(PlaySound);
    }

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}