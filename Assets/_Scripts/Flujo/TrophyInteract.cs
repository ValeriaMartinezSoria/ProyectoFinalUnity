using UnityEngine;

public class TrophyInteract : MonoBehaviour
{
    private bool interacted = false;

    // Puedes usar OnMouseDown si tienes el Input System antiguo habilitado también,
    // o puedes llamarlo desde el jugador si estás usando un Raycast general.
    void OnMouseDown()
    {
        if (interacted) return;
        interacted = true;

        if (FinalSequenceManager.Instance != null)
        {
            FinalSequenceManager.Instance.ActivarProyector();
        }
        else
        {
            Debug.LogError("No hay FinalSequenceManager en la escena.");
        }
    }
}