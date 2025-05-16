using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class BotonSeleccionable : MonoBehaviour
{
    [SerializeField] InputActionReference BotonAccion;
    [SerializeField] bool oprimioBoton = false;
    [SerializeField] bool EstaViendoObjeto = false;
    [SerializeField] int tipoBoton;
    [SerializeField] List<TextMeshProUGUI> BotonesExamenes;
    [SerializeField] ControladorInteractuables controlador;
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
            controlador.SetYaTieneObjeto(false);
        }
        if (!controlador.GetYaTieneObjeto())
        {
            if (EstaViendoObjeto)
            {
                if (!oprimioBoton)
                {
                    oprimioBoton = true;
                    controlador.SetYaTieneObjeto(true);
                }
               
            }
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
            VerificarBoton();
        }
        if (!oprimioBoton)
        {
            Color nuevoColor;
            if (ColorUtility.TryParseHtmlString("#111", out nuevoColor))
            {
                imagen.color = nuevoColor;
            }
        }
        
    }
    public void VerificarBoton()
    {
        if (tipoBoton == 1)
        {
            if (gameObject.name == PacienteManager.instance.getPosturaPaciente())
            {
                PantallaManager.instance.setPosturaCorrecta(true);
            }
            else
            {
                Debug.Log(" Perra :El boton 1 tiene errores");
            }
        }
        else if (tipoBoton == 2)
        {
            if (gameObject.name == PacienteManager.instance.getRegionAnatomica())
            {
                PantallaManager.instance.setRegionCorrecta(true);
                ActualizarExamenesDisponibles();
            }
            else
            {
                Debug.Log(" Perra :El boton 2 tiene errores");
            }
        }
        else if (tipoBoton == 3)
        {
            TextMeshProUGUI textoTMP = GetComponentInChildren<TextMeshProUGUI>();
            if (textoTMP.text == PacienteManager.instance.GetExamenActual())
            {
                PantallaManager.instance.setExamen(true);
            }
            else
            {
                Debug.Log(" Perra :El boton 3 tiene errores");
            }
        }
    }
    public void ActualizarExamenesDisponibles()
    {
        if (gameObject.name == "Cabeza")
        {
            List<string> nombres = PantallaManager.instance.getListaExamenes("Cabeza");

            for (int i = 0; i < BotonesExamenes.Count; i++)
            {

                BotonesExamenes[i].text = nombres[i];

            }
        }
        if (gameObject.name == "Torax")
        {
            List<string> nombres = PantallaManager.instance.getListaExamenes("Torax");

            for (int i = 0; i < BotonesExamenes.Count; i++)
            {

                BotonesExamenes[i].text = nombres[i];

            }
        }
        if (gameObject.name == "Pelvis")
        {
            List<string> nombres = PantallaManager.instance.getListaExamenes("Pelvis");

            for (int i = 0; i < BotonesExamenes.Count; i++)
            {

                BotonesExamenes[i].text = nombres[i];

            }
        }
    }
}
