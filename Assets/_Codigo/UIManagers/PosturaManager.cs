using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PosturaManager : MonoBehaviour
{
    [SerializeField] InputActionReference BotonAccion;
    [SerializeField] bool oprimioBoton=false;
    [SerializeField] bool EstaViendoObjeto = false;

    [SerializeField] GameObject original;
    [SerializeField] GameObject lateral;
    [SerializeField] GameObject supino;
    [SerializeField] GameObject prono;

    [SerializeField] GameObject camilla;

    [SerializeField] string tipoPosicion;
    

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
            oprimioBoton = !oprimioBoton;
        }
        else
        {
            oprimioBoton = false;
        }
        
    }
    void Update()
    {

        if (EstaViendoObjeto)
        {
            if (oprimioBoton)
            {
                UbicarPaciente();
            }
        }
        

    }

    public void UbicarPaciente()
    {
        if (tipoPosicion == "Supino")
        {
            original.SetActive(false);
            prono.SetActive(false);
            lateral.SetActive(false);
            supino.SetActive(true);
            TACManager.instance.setPacienteEnCamilla(true);
            if (tipoPosicion == PacienteManager.instance.getPosturaPaciente())
            {
                TACManager.instance.setPostura(true);
                supino.transform.SetParent(camilla.transform, true);
                Debug.Log(" Perra :el padre del modelo es: " +supino.transform.parent);
            }
        }
        else if (tipoPosicion == "Prono")
        {
            original.SetActive(false);
            supino.SetActive(false);
            lateral.SetActive(false);
            prono.SetActive(true);
            TACManager.instance.setPacienteEnCamilla(true);

            if (tipoPosicion == PacienteManager.instance.getPosturaPaciente())
            {
                TACManager.instance.setPostura(true);
                prono.transform.SetParent(camilla.transform, true);
                Debug.Log(" Perra :el padre del modelo es: " + prono.transform.parent);
            }
        }
        else if (tipoPosicion == "Lateral")
        {
            original.SetActive(false);
            supino.SetActive(false);
            prono.SetActive(false);
            lateral.SetActive(true);
            TACManager.instance.setPacienteEnCamilla(true);

            if (tipoPosicion == PacienteManager.instance.getPosturaPaciente())
            {
                TACManager.instance.setPostura(true);
                lateral.transform.SetParent(camilla.transform, true);
                
            }

        }
        oprimioBoton = false;
    }
    

}
