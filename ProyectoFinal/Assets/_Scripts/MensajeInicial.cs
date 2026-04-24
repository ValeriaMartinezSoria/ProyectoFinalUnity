using UnityEngine;
using System.Collections;

public class MensajeInicial : MonoBehaviour
{
    [Header("Mensajes")]
    public GameObject mensaje1;
    public GameObject mensaje2;

    [Header("Tiempos")]
    public float duracionMensaje1 = 5f;
    public float tiempoParaMensaje2 = 60f;
    public float duracionMensaje2 = 5f;

    void Start()
    {
        // Asegurar estado inicial correcto
        if (mensaje1 != null) mensaje1.SetActive(false);
        if (mensaje2 != null) mensaje2.SetActive(false);

        StartCoroutine(SecuenciaMensajes());
    }

    IEnumerator SecuenciaMensajes()
    {
        // ---- MENSAJE 1 ----
        if (mensaje1 != null)
        {
            mensaje1.SetActive(true);
            yield return new WaitForSeconds(duracionMensaje1);
            mensaje1.SetActive(false);
        }

        // Espera antes del segundo mensaje
        yield return new WaitForSeconds(tiempoParaMensaje2);

        // ---- MENSAJE 2 ----
        if (mensaje2 != null)
        {
            mensaje2.SetActive(true);
            yield return new WaitForSeconds(duracionMensaje2);
            mensaje2.SetActive(false);
        }
    }
}