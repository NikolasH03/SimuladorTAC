using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteraccionMenu : MonoBehaviour
{
    [SerializeField] InputActionReference BotonAccion;
    [SerializeField] bool oprimioBoton = false;
    [SerializeField] bool EstaViendoObjeto = false;
    [SerializeField] int tipoBoton;
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
        ControladorSonido.instance.playAudio(ControladorSonido.instance.hover);
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
                //Debug.Log(" MiDebug : si oprimio boton");
                if (tipoBoton == 1)
                {
                    ControladorSonido.instance.playAudio(ControladorSonido.instance.correcto);
                    ComenzarSimulacion();
                }
                else if(tipoBoton == 2)
                {
                    ControladorSonido.instance.playAudio(ControladorSonido.instance.incorrecto);
                    Salir();
                }
            }
        }

    }
    public void ComenzarSimulacion()
    {
        //Debug.Log(" MiDebug : si intenta cargar la escena");
        SceneManager.LoadScene("SalaTAC");
    }
    public void Salir()
    {
        Application.Quit();
    }

}
