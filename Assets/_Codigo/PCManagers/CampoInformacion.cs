using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CampoInformacion : MonoBehaviour
{
    [SerializeField] InputActionReference BotonAccion;
    [SerializeField] bool oprimioBoton = false;
    [SerializeField] bool EstaViendoObjeto = false;

    [SerializeField] int campoInformacion;
    [SerializeField] TextMeshProUGUI texto;

    private HashSet<int> camposYaLlenos = new HashSet<int>();
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
            if (!camposYaLlenos.Contains(campoInformacion))
            {
                switch (campoInformacion)
                {
                    case 1:
                        texto.text = PacienteManager.instance.getNombre();
                        break;
                    case 2:
                        texto.text = PacienteManager.instance.getEdad();
                        break;
                    case 3:
                        texto.text = PacienteManager.instance.getAltura();
                        break;
                    case 4:
                        texto.text = PacienteManager.instance.getPeso();
                        break;
                    default:
                        Debug.LogWarning("Campo inválido: " + campoInformacion);
                        break;
                }

                camposYaLlenos.Add(campoInformacion);
                PantallaManager.instance.llenarNumeroCampos();
            }

            oprimioBoton = false;
        }    
       
    }
}
