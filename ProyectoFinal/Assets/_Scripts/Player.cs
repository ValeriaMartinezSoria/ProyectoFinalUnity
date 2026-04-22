using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float velocidad = 5f;

    private Vector2 inputMovimiento;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    void OnMove(InputValue value)
    {
        inputMovimiento = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        MoverJugador();
    }

    public void MoverJugador()
    {
        Vector3 direccion = transform.right * inputMovimiento.x + transform.forward * inputMovimiento.y;

        rb.linearVelocity = new Vector3(direccion.x * velocidad, rb.linearVelocity.y, direccion.z * velocidad);
    }
}