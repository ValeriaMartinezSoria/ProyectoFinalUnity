using UnityEngine;

public class MensajeInicial : MonoBehaviour
{
    public GameObject textoMensaje;

    void Start()
    {
        Invoke("OcultarMensaje", 5f);
    }

    void OcultarMensaje()
    {
        textoMensaje.SetActive(false);
    }
}