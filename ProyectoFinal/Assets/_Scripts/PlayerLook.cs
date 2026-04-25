using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 30f;
    public Transform playerCamera;
    public InputActionReference lockCursorAction;

    private float xRotation = 0f;
    private Vector2 mouseInput;
    private bool cursorLocked = true;

    void OnEnable()
    {
        if (lockCursorAction != null)
        {
            lockCursorAction.action.Enable();
        }
    }

    void OnDisable()
    {
        if (lockCursorAction != null)
        { 
            lockCursorAction.action.Disable();
        }
    }

    void Start()
    {
        LockCursor();
    }

    void Update()
    {
        if (lockCursorAction != null && lockCursorAction.action.WasPressedThisFrame())
        {
            if (cursorLocked)
                UnlockCursor();
            else
                LockCursor();
        }

        if (cursorLocked)
            LookAround();
    }

    public void OnLook(InputValue data)
    {
        mouseInput = data.Get<Vector2>();
    }

    public void LookAround()
    {
        xRotation -= mouseInput.y * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -40f, 60f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseInput.x * mouseSensitivity * Time.deltaTime);

        mouseInput = Vector2.zero;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursorLocked = false;
        mouseInput = Vector2.zero;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorLocked = true;
        mouseInput = Vector2.zero;
        
    }


}