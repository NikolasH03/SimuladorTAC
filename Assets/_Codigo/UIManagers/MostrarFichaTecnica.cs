using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 

public class MostrarFichaTecnica : MonoBehaviour
{
    [SerializeField] InputActionReference buttonAction;
    [SerializeField] GameObject textObject; 
    AgarrarObjeto objeto;



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
        textObject.SetActive(!textObject.activeSelf); 
    }
}

