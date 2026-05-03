using UnityEngine;

public class AnomalyInteract : MonoBehaviour
{
    public AnomalyManager manager;
    public AudioClip pickupSound;

    private void OnMouseDown() // Detecta el click con el ratón si el cursor está centrado y el objeto tiene Collider
    {
        Debug.Log("OnMouseDown() detectado en: " + gameObject.name);

        if (manager != null)
        {
            manager.AddAnomaly();
        }
        else
        {
            Debug.LogWarning("¡ATENCIÓN! La variable 'manager' está vacía en la anomalía: " + gameObject.name);
        }

        // Reproduce un sonido en el lugar antes de destruirse
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }

        // Destruye la anomalía en la escena
        Destroy(gameObject);
    }
}