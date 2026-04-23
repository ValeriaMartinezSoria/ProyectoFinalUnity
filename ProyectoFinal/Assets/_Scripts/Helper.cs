using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Helper : MonoBehaviour
{
    public string mensaje = "Hola estudiante, tu misión es ...";
    public GameObject textInteraction;
    public GameObject panelDialog;
    public TMP_Text textDialog;
    public AudioSource audioSource;
    public Animator animator;
    public InputActionReference interactAction;

    [Header("Mirar al jugador")]
    public float velocidadRotacion = 5f;

    private bool playerNear = false;
    private bool talking = false;
    private Transform player;

    void Update()
    {
        if (playerNear && interactAction.action.WasPressedThisFrame())
        {
            if (!talking)
            {
                StartTalking();
                animator.SetBool("IsTalking", true);
            }
            else
            {
                FinishTalking();
                animator.SetBool("IsTalking", false);
            }
        }

        if (talking && player != null)
        {
            MirarAlJugador();
        }
    }

    void MirarAlJugador()
    {
        Vector3 direccion = player.position - transform.position;
        direccion.y = 0f; 

        if (direccion.sqrMagnitude > 0.001f)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            player = other.transform;  
            textInteraction.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            player = null;  
            textInteraction.SetActive(false);
            if (talking)
            {
                FinishTalking();
                animator.SetBool("IsTalking", false);
            }
        }
    }

    void StartTalking()
    {
        talking = true;
        textInteraction.SetActive(false);
        panelDialog.SetActive(true);
        textDialog.text = mensaje;
        if (audioSource != null)
            audioSource.Play();
    }

    void FinishTalking()
    {
        talking = false;
        panelDialog.SetActive(false);
        if (playerNear)
            textInteraction.SetActive(true);
        if (audioSource != null)
            audioSource.Stop();
    }
}