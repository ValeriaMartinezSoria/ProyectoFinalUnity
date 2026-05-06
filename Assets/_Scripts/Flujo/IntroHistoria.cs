using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroHistoria : MonoBehaviour
{
    public TextMeshProUGUI textoUI;

    [TextArea]
    public string[] frases;

    public float velocidadTyping = 0.05f;
    public float pausaEntreFrases = 2f;

    public AudioSource audioSource;
    public AudioClip sonidoTecla;

    public string siguienteEscena = "All";

    void Start()
    {
        StartCoroutine(ReproducirHistoria());
    }

    IEnumerator ReproducirHistoria()
    {
        foreach (string frase in frases)
        {
            yield return StartCoroutine(EscribirFrase(frase));
            yield return new WaitForSeconds(pausaEntreFrases);
            textoUI.text = "";
        }

        SceneManager.LoadScene(siguienteEscena);
    }

    IEnumerator EscribirFrase(string frase)
    {
        textoUI.text = "";

        foreach (char letra in frase)
        {
            textoUI.text += letra;

            if (audioSource != null && sonidoTecla != null)
            {
                audioSource.PlayOneShot(sonidoTecla, 0.2f);
            }

            yield return new WaitForSeconds(velocidadTyping);
        }
    }
}