using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class BotonSeleccionable : MonoBehaviour
{
    [SerializeField] InputActionReference BotonAccion;
    [SerializeField] bool oprimioBoton = false;
    [SerializeField] bool EstaViendoObjeto = false;

    [SerializeField] Image imagen;
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
                Color nuevoColor;
                if (ColorUtility.TryParseHtmlString("#FF8800", out nuevoColor))
                {
                    imagen.color = nuevoColor;
                }
        }

        
        if(gameObject.name == PacienteManager.instance.getPosturaPaciente())
        {
            PantallaManager.instance.setPosturaCorrecta(true);
        }
    }
}
