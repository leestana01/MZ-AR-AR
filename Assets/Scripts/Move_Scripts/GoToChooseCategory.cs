using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToChooseCategory : MonoBehaviour
{

    public void SwitchScene()
    {
        SceneManager.LoadScene("ChooseCategory");
    }
}
