using UnityEngine;
using TMPro;

public class AnomalyManager : MonoBehaviour
{
    public static AnomalyManager Instance; 

    public TMP_Text textAnomalies;
    public int totalAnomalies = 10;
    
    [Header("Recompensa al terminar (Wall)")]
    public GameObject wallToDisappear; 
    public GameObject objectToPassThrough;

    [Header("Sonido de Puerta / Recompensa")]
    public AudioSource audioSource;
    public AudioClip doorOpenSound;

    private int currentAnomalies = 0;

    void Awake()
    {
        
        Instance = this;
    }

    void Start()
    {
        Debug.Log("AnomalyManager iniciado.");
        
        
        if (textAnomalies != null)
        {
            textAnomalies.gameObject.SetActive(false); 
        }

        UpdateUI();
    }

    
    public void MostrarTextoAnomalias()
    {
        if (textAnomalies != null)
        {
            textAnomalies.gameObject.SetActive(true);
            textAnomalies.transform.SetAsLastSibling(); 
            Debug.Log("¡El AnomalyManager encendió el texto con éxito!");
        }
    }

    public void AddAnomaly()
    {
        currentAnomalies++;
        Debug.Log("Anomalía recolectada. Total actual: " + currentAnomalies);
        UpdateUI();

        if (currentAnomalies >= totalAnomalies)
        {
            Debug.Log("¡Todas las anomalías recolectadas!");

            // 🔹 1. Desaparece la pared
            if (wallToDisappear != null)
            {
                wallToDisappear.SetActive(false);
            }

            // 🔹 2. Se vuelve atravesable otro objeto
            if (objectToPassThrough != null)
            {
                Collider col = objectToPassThrough.GetComponent<Collider>();
                if (col != null)
                {
                    col.enabled = false;
                }
            }

            // Ocultar texto
            if (textAnomalies != null)
            {
                textAnomalies.gameObject.SetActive(false);
            }

            // Sonido
            if (audioSource != null && doorOpenSound != null)
            {
                audioSource.PlayOneShot(doorOpenSound);
            }
        }
    }

    void UpdateUI()
    {
        if (textAnomalies != null)
        {
            textAnomalies.text = "Anomalías: " + currentAnomalies + " / " + totalAnomalies;
            Debug.Log("UI Actualizada a: " + textAnomalies.text);
        }
        else
        {
            Debug.LogWarning("¡ATENCIÓN! textAnomalies está vacío en AnomalyManager. ¡Arrastra el texto desde la Jerarquía!");
        }
    }
}