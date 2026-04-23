using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float velocidad = 5f;

    private Vector2 inputMovimiento;
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

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        Vector3 direccion = transform.right * inputMovimiento.x + transform.forward * inputMovimiento.y;
        rb.linearVelocity = new Vector3(direccion.x * velocidad, rb.linearVelocity.y, direccion.z * velocidad);

        float velocidadHorizontal = new Vector2(rb.linearVelocity.x, rb.linearVelocity.z).magnitude;

        animator.SetFloat("Speed", velocidadHorizontal);
    }
}