using UnityEngine;

public class HighlightOnLook : MonoBehaviour
{
    public Color colorNormal = Color.white;
    public Color colorResaltado = Color.green;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = colorNormal;
    }

    public void OnLookEnter()
    {
        rend.material.color = colorResaltado;
    }

    public void OnLookExit()
    {
        rend.material.color = colorNormal;
    }
}