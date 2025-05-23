using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class BotonRespuesta : MonoBehaviour
{
    [SerializeField] string opcion;
    //[SerializeField] TextMeshProUGUI textoPregunta;
    //[SerializeField] string pregunta;
    [SerializeField] InputActionReference BotonAccion;
    [SerializeField] bool oprimioBoton = false;
    [SerializeField] bool EstaViendoObjeto = false;

    [SerializeField] TriviaManager trivia;
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
        oprimioBoton = !oprimioBoton;
    }

    private void Start()
    {
        //textoPregunta.text = pregunta;
    }
    void Update()
    {
        if (EstaViendoObjeto)
        {
            //Debug.Log(" MiDebug : EstaViendoObjeto "+EstaViendoObjeto);
            if (oprimioBoton)
            {               
                trivia.SeleccionarOpcion(opcion);
            }
        }

    }
    public void setOprimioBoton(bool boton)
    {
        oprimioBoton = boton;
    }
}
