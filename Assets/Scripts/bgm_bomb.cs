using UnityEngine;
using UnityEngine.SceneManagement;

public class bgm_bomb : MonoBehaviour
{
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "pop")
        {
            audioSource.Play();
        }
    }
}
