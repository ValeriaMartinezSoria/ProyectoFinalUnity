using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAJugar : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("PrincipalScene");
    }
}