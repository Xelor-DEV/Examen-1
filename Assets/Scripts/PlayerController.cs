using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Rigidbody _compRigidbody;
    [SerializeField] private float velocidad;
    [SerializeField] private float fuerza_de_salto;
    [SerializeField] private float vida;
    [SerializeField] private bool se_puede_saltar;
    [SerializeField] private Vector3 direccion_de_movimiento;
    [Header("Raycast Properties")]
    [SerializeField] private LayerMask capas_interactuables;
    [SerializeField] private float distanciaDelRayo;
    [SerializeField] private Color colorDelRayoDebug;
    
    void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }
    public void Movimiento(InputAction.CallbackContext context)
    {
        direccion_de_movimiento = new Vector3(context.ReadValue<Vector2>().x ,0, context.ReadValue<Vector2>().y);
    }
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distanciaDelRayo, capas_interactuables))
        {
            se_puede_saltar = true;
        }
        else
        {
            se_puede_saltar = false;
        }
    }
    void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector3(direccion_de_movimiento.x * velocidad, _compRigidbody.velocity.y , direccion_de_movimiento.z * velocidad);
    }
    public void Saltar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (se_puede_saltar == true)
            {
                _compRigidbody.velocity = new Vector3(_compRigidbody.velocity.x, fuerza_de_salto, _compRigidbody.velocity.z);
            }
           
        }
        
    }
}
