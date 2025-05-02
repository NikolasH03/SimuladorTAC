using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Cuestionario : MonoBehaviour
{
    [SerializeField] InputActionReference buttonAction;
    [SerializeField] bool oprimioBoton = false;
    void OnEnable()
    {
        buttonAction.action.Enable();
        buttonAction.action.performed += ShowText;

    }


    void OnDisable()
    {
        buttonAction.action.performed -= ShowText;
        buttonAction.action.Disable();
    }


    void ShowText(InputAction.CallbackContext context)
    {
        oprimioBoton = !oprimioBoton;
    }
    void Update()
    {
        if (oprimioBoton)
        {
            SceneManager.LoadScene("Cuestionario");
        }
    }
}
