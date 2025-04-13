using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorMovimiento : MonoBehaviour
{
    [SerializeField] InputActionReference AccionMoverse;
    [SerializeField] Transform cameraTransform;
    private Rigidbody rb;

    [SerializeField] float speed = 5f;

    private Vector2 InputMovimiento;

    void OnEnable()
    {
        AccionMoverse.action.Enable();
        AccionMoverse.action.performed += Moverse;
        AccionMoverse.action.canceled += ParaMovimiento;
    }

    void OnDisable()
    {
        AccionMoverse.action.performed -= Moverse;
        AccionMoverse.action.canceled -= ParaMovimiento;
        AccionMoverse.action.Disable();
    }

    void Moverse(InputAction.CallbackContext context)
    {
        InputMovimiento = context.ReadValue<Vector2>();
    }

    void ParaMovimiento(InputAction.CallbackContext context)
    {
        InputMovimiento = Vector2.zero; 
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (cameraTransform == null) return;

        Vector3 forward = cameraTransform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0;
        right.Normalize();

        if (InputMovimiento == Vector2.zero)
        {
            ControladorSonido.instance.stopFootstep();
        }
        else
        {
            ControladorSonido.instance.playFootstep();
        }

        Vector3 direction = forward * InputMovimiento.y + right * InputMovimiento.x;
        Vector3 move = direction.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + move);
    }
}

