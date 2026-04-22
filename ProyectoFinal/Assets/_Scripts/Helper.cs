using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Helper : MonoBehaviour
{
    public string mensaje = "Hola estudiante, tu misión es ...";

    public GameObject textoInteraccion;  
    public GameObject panelDialogo;       
    public TMP_Text textoDialogo;         

    public AudioSource audioSource;      

    private bool jugadorCerca = false;
    private bool hablando = false;

    void Update()
    {
        if (jugadorCerca && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!hablando)
                IniciarDialogo();
            else
                TerminarDialogo();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            textoInteraccion.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            textoInteraccion.SetActive(false);

            if (hablando)
                TerminarDialogo();
        }
    }

    void IniciarDialogo()
    {
        hablando = true;
        textoInteraccion.SetActive(false);
        panelDialogo.SetActive(true);
        textoDialogo.text = mensaje;

        if (audioSource != null)
            audioSource.Play();
    }

    void TerminarDialogo()
    {
        hablando = false;
        panelDialogo.SetActive(false);

        if (jugadorCerca)
            textoInteraccion.SetActive(true);

        if (audioSource != null)
            audioSource.Stop();
    }
}
