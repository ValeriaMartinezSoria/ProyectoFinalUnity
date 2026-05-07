using UnityEngine;

public class FinalButton : MonoBehaviour
{
    private bool isPressed = false;
    public GameTimer gameTimer; // Arrastra el objeto que tiene el timer aquí en el inspector

    // Cuando el jugador hace click sobre el "botón" 3D
    void OnMouseDown()
    {
        if (isPressed) return;
        isPressed = true;

        if (FinalSequenceManager.Instance != null)
        {
            // Detener el tiempo
            if (gameTimer != null)
            {
                gameTimer.enabled = false; // Desactiva el script del timer para que deje de contar
            }

            // Inicia la secuencia de subir el estante
            FinalSequenceManager.Instance.IniciarSubidaEstante();
            Debug.Log("Botón final presionado: El estante está subiendo y el tiempo se detuvo.");
        }
        else
        {
            Debug.LogError("No hay FinalSequenceManager en la escena.");
        }
    }
}