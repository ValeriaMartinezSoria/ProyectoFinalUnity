using UnityEngine;
using TMPro;

public class CodeLock3D : MonoBehaviour
{
    public TextMeshPro displayText;
    public string correctCode = "2580";

    private string input = "";

    public GameObject door;

    public void PressButton(string value)
    {
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
            Debug.Log("Código correcto");
            OpenDoor();
        }
        else
        {
            Debug.Log("Código incorrecto");
            input = "";
            displayText.text = "";
        }
    }

    void OpenDoor()
    {
        door.SetActive(false);
    }
}