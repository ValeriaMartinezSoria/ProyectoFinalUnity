using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float velocidadCaminando = 5f;
    public float velocidadCorriendo = 6.5f;
    public float fuerzaSalto = 5f;

    private Vector2 inputMovimiento;
    private bool estaCorriendo = false;
    private Rigidbody rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    void OnMove(InputValue value)
    {
        inputMovimiento = value.Get<Vector2>();
    }

    void OnSprint(InputValue value)
    {
        estaCorriendo = value.isPressed;
    }
    
    void OnRun(InputValue value) // Añadido por si tu Input Action se llama Run en lugar de Sprint
    {
        estaCorriendo = value.isPressed;
    }

    void OnJump(InputValue value)
    {
        // Permite saltar solo si la velocidad vertical es cercana a 0 (simula estar en el suelo)
        if (value.isPressed && Mathf.Abs(rb.linearVelocity.y) < 0.1f)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        float velocidadActual = estaCorriendo ? velocidadCorriendo : velocidadCaminando;
        Vector3 direccion = transform.right * inputMovimiento.x + transform.forward * inputMovimiento.y;
        
        rb.linearVelocity = new Vector3(direccion.x * velocidadActual, rb.linearVelocity.y, direccion.z * velocidadActual);

        float velocidadHorizontal = new Vector2(rb.linearVelocity.x, rb.linearVelocity.z).magnitude;

        if (animator != null)
        {
            animator.SetFloat("Speed", velocidadHorizontal);
        }
    }
}