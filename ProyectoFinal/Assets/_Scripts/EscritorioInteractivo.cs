using UnityEngine;

public class EscritorioInteractivo : MonoBehaviour
{
    [Header("Rotación")]
    public float velocidad = 2f;
    private bool girando = false;
    private Quaternion rotacionObjetivo;

    [Header("Sonido")]
    public AudioSource audioSource;
    private bool yaSonó = false;

    void Update()
    {
        if (girando)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rotacionObjetivo,
                velocidad * Time.deltaTime
            );

            if (Quaternion.Angle(transform.rotation, rotacionObjetivo) < 1f)
            {
                girando = false;
            }
        }
    }

    public void GirarEscritorio()
    {
        if (!girando)
        {
            rotacionObjetivo = Quaternion.Euler(0, transform.eulerAngles.y + 180f, 0);
            girando = true;
        }
    }

    void OnMouseDown()
    {
        GirarEscritorio();
    }

    // 🔊 Detectar cercanía
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}