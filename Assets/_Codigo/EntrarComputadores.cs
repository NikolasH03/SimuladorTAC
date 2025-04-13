using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EntrarComputadores : MonoBehaviour
{
    [SerializeField] InputActionReference BotonAccion;
    [SerializeField] bool oprimioBoton = false;


    [SerializeField] GameObject texto;
    [SerializeField] bool jugadorEnZona = false;
    void Start()
    {
        texto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (jugadorEnZona)
        {
            if (oprimioBoton)
            {
                SceneManager.LoadScene("Computadores");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            texto.SetActive(true);
            jugadorEnZona=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        texto.SetActive(false);
        jugadorEnZona=false;
    }



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

    void OprimeBoton(InputAction.CallbackContext context)
    {
        oprimioBoton = !oprimioBoton;
    }
}
