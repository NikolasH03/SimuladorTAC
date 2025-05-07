using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CampoInformacion : MonoBehaviour
{
    [SerializeField] InputActionReference BotonAccion;
    [SerializeField] bool oprimioBoton = false;
    [SerializeField] bool EstaViendoObjeto = false;

    [SerializeField] int campoInformacion;
    [SerializeField] TextMeshProUGUI texto;
    [SerializeField] int numeroCamposLlenos = 0;

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

                switch (campoInformacion)
                {
                    case 1:
                        texto.text = PacienteManager.instance.getNombre();
                        numeroCamposLlenos++;   
                        break;
                    case 2:
                        texto.text = PacienteManager.instance.getEdad();
                        numeroCamposLlenos++; 
                        break;
                    case 3:
                        texto.text = PacienteManager.instance.getAltura();
                        numeroCamposLlenos++; 
                        break;
                    case 4:
                        texto.text = PacienteManager.instance.getPeso();
                        numeroCamposLlenos++; 
                        break;
                } 
        }

        if (numeroCamposLlenos == 4)
        {
            PantallaManager.instance.setCamposLlenos(true);
        }
    }
}
