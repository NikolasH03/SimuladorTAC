using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorBotonTAC : MonoBehaviour
{
    [SerializeField] Animator animator;
    private bool Reanudar = false;
    private bool isPlaying = false;

    [SerializeField] Transform CabezaJugador;
    [SerializeField] InputActionReference MoverCamilla;
    private bool EstaViendoObjeto = false;

    void OnEnable()
    {
        MoverCamilla.action.Enable();
        MoverCamilla.action.performed += OprimioBoton;
    }


    void OnDisable()
    {
        MoverCamilla.action.performed -= OprimioBoton;
        MoverCamilla.action.Disable();
    }
    void SetEstaViendoObjeto(bool valor)
    {
        EstaViendoObjeto = valor;
    }
    void OprimioBoton(InputAction.CallbackContext context)
    {

        if (EstaViendoObjeto)
        {
            isPlaying = !isPlaying;

            if (isPlaying && !Reanudar)
            {
                animator.speed = 1;
            }
            else if (isPlaying && Reanudar)
            {
                animator.speed = 1;
                Reanudar = false;
            }

            else if (!isPlaying)
            {
                animator.speed = 0;
                Reanudar = true;
            }



        }
    }
    void Start()
    {
        animator.speed = 0;
    }
    void Update()
    {
        //Debug.Log(" MiDebug : IsPlaying"+isPlaying);
        //Debug.Log(" MiDebug : Reanudar" + Reanudar);
    }
}
