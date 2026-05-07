using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement; // <- Agregado para usar escenas

public class FinalSequenceManager : MonoBehaviour
{
    public static FinalSequenceManager Instance;

    [Header("Animación Estante")]
    public Transform estante;
    public Transform posicionFinalEstante; // Crea un objeto vacío donde quieres que termine
    public float velocidadSubida = 1.5f;

    [Header("Proyector y Video")]
    public GameObject luzProyector; // Un foco o cono de luz
    public VideoPlayer reproductorVideo; 
    public GameObject pantallaVideo; // El Quad o pantalla donde se verá el video

    [Header("Escena Final")]
    public string winSceneName = "WinScene"; // El nombre de la escena de victoria

    private bool secuenciaIniciada = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Aseguramos que el proyector y pantalla estén apagados al inicio
        if (luzProyector != null) luzProyector.SetActive(false);
        if (pantallaVideo != null) pantallaVideo.SetActive(false);
    }

    // Se llama al ganar el juego de letras
    public void IniciarSubidaEstante()
    {
        if (secuenciaIniciada) return;
        secuenciaIniciada = true;

        StartCoroutine(MoverEstante());
    }

    private IEnumerator MoverEstante()
    {
        // Mueve el estante poco a poco hasta su posición destino
        while (Vector3.Distance(estante.position, posicionFinalEstante.position) > 0.01f)
        {
            estante.position = Vector3.MoveTowards(estante.position, posicionFinalEstante.position, velocidadSubida * Time.deltaTime);
            yield return null;
        }
    }

    // Se llama al hacer click en el trofeo
    public void ActivarProyector()
    {
        // Pausamos a los jugadores NPCs u otras cosas si lo necesitas
        // Por ahora, activamos la visual del proyecto

        if (luzProyector != null) luzProyector.SetActive(true);
        if (pantallaVideo != null) pantallaVideo.SetActive(true);

        if (reproductorVideo != null)
        {
            // Nos suscribimos al evento que avisa cuando el video llega a su fin
            reproductorVideo.loopPointReached += OnVideoFinished;
            reproductorVideo.Play();
        }

        Debug.Log("¡Secuencia Final: Video Reproduciéndose!");
    }

    // Este método se llamará automáticamente cuando el video termine
    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video terminado, cargando escena...");
        SceneManager.LoadScene(winSceneName);
    }
}