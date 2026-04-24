using UnityEngine;
using TMPro;


public class CodeLock3D : MonoBehaviour
{
    public TextMeshPro displayText;
    public string correctCode = "2580";

    private string input = "";
    private string winScene = "WinScene";

    public GameObject door;
    public AudioSource audioSource;

    public AudioClip buttonSound;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    public void PressButton(string value)
    {
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
            if (input.Length < 6)
                input += value;
        }

        displayText.text = input;
    }

    void CheckCode()
    {
        Debug.Log("Ingresado: " + input);
        Debug.Log("Correcto: " + correctCode);

        if (input == correctCode)
        {
            audioSource.PlayOneShot(correctSound);
            Debug.Log("Código correcto");
            OpenDoor();
        }
        else
        {
            audioSource.PlayOneShot(wrongSound);
            Debug.Log("Código incorrecto");
            input = "";
            displayText.text = "";
        }
    }

    void OpenDoor()
    {
        door.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(winScene);
    }
}