using UnityEngine;
using UnityEngine.InputSystem;

public class AgarrarObjeto : MonoBehaviour
{
    [SerializeField] Transform CabezaJugador;
    [SerializeField] InputActionReference AccionAgarrar;
    [SerializeField] bool objetoAgarrado = false; 

    private Transform padreOriginal;

    [SerializeField] bool EstaViendoObjeto = false;

    [SerializeField] ControladorInteractuables controlador;
    void OnEnable()
    {
        AccionAgarrar.action.Enable();
        AccionAgarrar.action.performed += ObjetoAgarrado;
    }


    void OnDisable()
    {
        AccionAgarrar.action.performed -= ObjetoAgarrado;
        AccionAgarrar.action.Disable();
    }
    void SetEstaViendoObjeto(bool valor)
    {
        EstaViendoObjeto = valor;
    }

    void ObjetoAgarrado(InputAction.CallbackContext context)
    {
        if (objetoAgarrado)
        {
            objetoAgarrado = false;
            controlador.SetYaTieneObjeto(false);
        }
        if (!controlador.GetYaTieneObjeto())
        {
            if (EstaViendoObjeto)
            {
        
                if (!objetoAgarrado)
                {
                    objetoAgarrado = true;
                    controlador.SetYaTieneObjeto(true);
                }
            }
         
        }
    }

    void Update()
    {
      //Debug.Log("MiDebug :"+objetoAgarrado);

            if (objetoAgarrado)
            {

                transform.position = CabezaJugador.position + CabezaJugador.forward * 1.0f;

            }
       
        
    }
}

