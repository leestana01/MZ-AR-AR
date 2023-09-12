using UnityEngine;
using UnityEngine.SceneManagement;

public class bgm_clickButton : MonoBehaviour
{
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();


        if (SceneManager.GetActiveScene().name == "ARCam")
        {
            audioSource.Play();
        }
    }
}
