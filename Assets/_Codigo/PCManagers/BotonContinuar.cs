using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BotonContinuar : MonoBehaviour
{
    [SerializeField] InputActionReference BotonAccion;
    [SerializeField] bool oprimioBoton = false;
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

        if (EstaViendoObjeto)
        {
            ControladorSonido.instance.playAudio(ControladorSonido.instance.hover);
        }
    }

    void OprimeBoton(InputAction.CallbackContext context)
    {
        if (EstaViendoObjeto)
        {
            oprimioBoton = true;
        }
        else
        {
            oprimioBoton = false;
        }

    }
    void Update()
    {
        if (oprimioBoton) 
        {

            PantallaManager.instance.setContinuar(true);
            oprimioBoton = false;
        }
    }
}
