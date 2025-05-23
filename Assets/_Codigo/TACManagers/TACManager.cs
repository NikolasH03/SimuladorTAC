using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TACManager : MonoBehaviour
{
    public static TACManager instance;

    [SerializeField] Animator animator;
    private bool Reanudar = false;
    private bool isPlaying = false;
    [SerializeField] GameObject laseres;

    [SerializeField] Transform CabezaJugador;
    [SerializeField] InputActionReference MoverCamilla;
    private bool EstaViendoObjeto = false;

    [SerializeField] bool pacienteEnCamilla = false;
    [SerializeField] bool posturaCorrecta = false;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
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
        if (EstaViendoObjeto)
        {
            ControladorSonido.instance.playAudio(ControladorSonido.instance.hover);
        }
    }
    void OprimioBoton(InputAction.CallbackContext context)
    {

        if (EstaViendoObjeto)
        {
            if (pacienteEnCamilla)
            {
                if (posturaCorrecta)
                {
                    isPlaying = !isPlaying;
                    laseres.SetActive(true);
                    if (isPlaying && !Reanudar)
                    {
                        ControladorSonido.instance.playAudio(ControladorSonido.instance.tac);
                        animator.speed = 1;
                    }
                    else if (isPlaying && Reanudar)
                    {
                        ControladorSonido.instance.playAudio(ControladorSonido.instance.tac);
                        animator.speed = 1;
                        Reanudar = false;
                    }

                    else if (!isPlaying)
                    {
                        animator.speed = 0;
                        Reanudar = true;
                    }
                }
                else
                {
                    Debug.Log(" Perra :el paciente no esta en la posicion correcta");
                    Debug.Log(" Perra :La posicion correcta es: " + PacienteManager.instance.getPosturaPaciente());
                }
            }
            else
            {
                Debug.Log(" Perra :el paciente no esta en la camilla");
            }

                
           
           



        }
    }
    void Start()
    {
        animator.speed = 0;
        laseres.SetActive(false);
    }

    public void setPacienteEnCamilla(bool paciente)
    {
        pacienteEnCamilla = paciente;
    }
    public void setPostura(bool postura)
    {
        posturaCorrecta = postura;
    }
    
}
