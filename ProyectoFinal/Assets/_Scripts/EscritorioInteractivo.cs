using UnityEngine;

public class EscritorioInteractivo : MonoBehaviour
{
    public float velocidad = 2f;
    private bool girando = false;
    private Quaternion rotacionObjetivo;

    void Update()
    {
        if (girando)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rotacionObjetivo,
                velocidad * Time.deltaTime
            );

            // Cuando ya casi terminó de girar
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
            // Gira 180 grados
            rotacionObjetivo = Quaternion.Euler(0, transform.eulerAngles.y + 180f, 0);
            girando = true;
        }
    }

    void OnMouseDown()
    {
        GirarEscritorio();
    }
}