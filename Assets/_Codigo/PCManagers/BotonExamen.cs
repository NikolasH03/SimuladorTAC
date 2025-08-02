using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class BotonExamen : BotonSeleccionableBase
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
        if (oprimioBoton)
        {
            oprimioBoton = false;
            //controlador.SetYaTieneObjeto(false);

        }
        //if (!controlador.GetYaTieneObjeto())
        //{
        if (EstaViendoObjeto)
        {
            if (!oprimioBoton)
            {
                oprimioBoton = true;
                //controlador.SetYaTieneObjeto(true);
                EjecutarAccion();


            }

            //}
        }

    }
    void Update()
    {
        if (oprimioBoton)
        {
            Color nuevoColor;
            if (ColorUtility.TryParseHtmlString("#FFFFFF", out nuevoColor))
            {
                imagen.color = nuevoColor;
            }

        }
        if (!oprimioBoton)
        {
            Color nuevoColor;
            if (ColorUtility.TryParseHtmlString("#001D3D", out nuevoColor))
            {
                imagen.color = nuevoColor;
            }

        }

    }
    public override void EjecutarAccion()
    {
        string texto = GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
        VerificadorGlobal.instance.VerificarExamen(texto);
    }
    
}
