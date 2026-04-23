using TMPro;
using Unity.VisualScripting;
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

    private bool playerNear = false;
    private bool talking = false;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            textInteraction.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
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
