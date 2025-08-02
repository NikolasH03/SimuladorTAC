using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class BotonRegion : BotonSeleccionableBase
{
    [SerializeField] InputActionReference BotonAccion;
    [SerializeField] bool oprimioBoton = false;
    [SerializeField] bool EstaViendoObjeto = false;
    //[SerializeField] ControladorInteractuables controlador;
    [SerializeField] Image imagen;
    [SerializeField] List<TMPro.TextMeshProUGUI> botonesExamenes;
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
    public override void EjecutarAccion()
    {
        VerificadorGlobal.instance.VerificarRegion(gameObject.name);
        VerificadorGlobal.instance.ActualizarExamenes(gameObject.name, botonesExamenes);
    }
    void Update()
    {
        if (oprimioBoton)
        {
    
            Color colorActual = imagen.color;
            colorActual.a = 0.5f; 
            imagen.color = colorActual;

        }
        if (!oprimioBoton)
        {
            Color colorActual = imagen.color;
            colorActual.a = 0f;
            imagen.color = colorActual;

        }

    }

}
