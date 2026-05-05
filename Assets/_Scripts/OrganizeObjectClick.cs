using UnityEngine;

public class OrganizeObjectClick : MonoBehaviour
{
    [Header("Manager")]
    public OrganizeOfficeManager manager;

    [Header("Sonido al ordenar un objeto")]
    public AudioClip orderSound;

    private void OnMouseDown() 
    {
        Debug.Log("OnMouseDown() detectado en: " + gameObject.name);

        if (manager != null)
        {
            manager.AddOrderedObject();
        }
        else
        {
            Debug.LogWarning("¡ATENCIÓN! La variable 'manager' está vacía en: " + gameObject.name);
        }

        // Reproducir sonido de un objeto ordenado si lo tiene
        if (orderSound != null)
        {
            AudioSource.PlayClipAtPoint(orderSound, transform.position);
        }

        Destroy(gameObject);
    }
}