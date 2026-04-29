using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CodeLock3D : MonoBehaviour
{
    public TextMeshPro displayText;
    public string correctCode = "2580";
    public bool isLocked = false;

    private string input = "";

    public GameObject door;
    public AudioSource audioSource;

    public AudioClip buttonSound;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    [Header("Escena de victoria")]
    public string winScene = "WinScene";
    public float delayBeforeWin = 2f; 

    public void PressButton(string value)
    {
        if (isLocked) return;

        audioSource.PlayOneShot(buttonSound);

        if (value == "C")
        {
            input = "";
        }
        else if (value == "E")
        {
            CheckCode();
            return;
        }
        else
        {
            if (input.Length < 4)
                input += value;
        }

        displayText.text = input;
    }

    void CheckCode()
    {
        if (input == correctCode)
        {
            audioSource.PlayOneShot(correctSound);
            isLocked = true;
            OpenDoor();

       
            Invoke("LoadWinScene", delayBeforeWin);
        }
        else
        {
            audioSource.PlayOneShot(wrongSound);
            input = "";
            displayText.text = "";
        }
    }

    void OpenDoor()
    {
        door.SetActive(false);
    }

    void LoadWinScene()
    {
        SceneManager.LoadScene(winScene);
    }
}