using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class VolverMenu : MonoBehaviour
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
                SceneManager.LoadScene("Menu");
            }
        }


    }
}
