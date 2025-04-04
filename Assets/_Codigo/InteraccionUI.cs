using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InteraccionUI : MonoBehaviour
{
    [SerializeField] InputActionReference BotonAccion;
    [SerializeField] bool oprimioBoton=false;
    [SerializeField] GameObject medico;
    [SerializeField] bool EstaViendoObjeto = false;
    void OnEnable()
    {
        BotonAccion.action.Enable();
        BotonAccion.action.performed += OprimeBoton;

    }


    void OnDisable()
    {
        BotonAccion.action.performed -= OprimeBoton;
        BotonAccion.action.Disable();
    }
    void SetEstaViendoObjeto(bool valor)
    {
        EstaViendoObjeto = valor;
    }

    void OprimeBoton(InputAction.CallbackContext context)
    {
        oprimioBoton = !oprimioBoton;
    }
    void Update()
    {
        if (EstaViendoObjeto)
        {
            if (oprimioBoton)
            {
                ApareceMedico();
            }
        }

    }

    public void ApareceMedico()
    {
        if (medico.activeSelf)
        {
            medico.SetActive(false);
        }
        else
        {
            medico.SetActive(true);
        }
    } 
}
