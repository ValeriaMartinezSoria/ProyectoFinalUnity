using UnityEngine;
using System.Collections;
using TMPro;

public class MensajeInicial : MonoBehaviour
{
    [Header("Referencia UI")]
    public TextMeshProUGUI texto;

    [Header("Contenido")]
    [TextArea]
    public string mensaje =
    "> EL TIEMPO CORRE...\n> ENCUENTRA EL CÓDIGO DE 4 DÍGITOS";

    [Header("Configuración")]
    public float typingSpeed = 0.10f;
    public float duracionEnPantalla = 5f;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip typingSound;

    void Start()
    {
        if (texto != null) texto.text = "";
        StartCoroutine(MostrarMensaje());
    }

    IEnumerator MostrarMensaje()
    {
        yield return StartCoroutine(TypeText(texto, mensaje));

        yield return new WaitForSeconds(duracionEnPantalla);

        texto.text = "";
    }

    IEnumerator TypeText(TextMeshProUGUI textoUI, string contenido)
    {
        textoUI.text = "";

        foreach (char letra in contenido)
        {
            textoUI.text += letra;

            if (typingSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(typingSound, 0.2f);
            }

            yield return new WaitForSeconds(typingSpeed);
        }
    }
}