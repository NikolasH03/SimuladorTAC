using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaManager : MonoBehaviour
{
    [SerializeField] string respuestaCorrecta; 
    public int respuestasCorrectas = 0;
    [SerializeField] BotonRespuesta boton1;
    [SerializeField] BotonRespuesta boton2;
    [SerializeField] GameObject canvasActual;
    [SerializeField] GameObject correcto;
    [SerializeField] GameObject incorrecto;

    private void Start()
    {
        correcto.SetActive(false);
        incorrecto.SetActive(false);
    }

    public void SeleccionarOpcion(string opcionElegida)
    {
        if (opcionElegida == respuestaCorrecta)
        {
            respuestasCorrectas++;
            boton1.setOprimioBoton(false);
            boton2.setOprimioBoton(false);
       
            correcto.SetActive(true);
            canvasActual.SetActive(false);

            Debug.Log(" MiDebug ¡Correcto!");
            Debug.Log(" MiDebug "+respuestasCorrectas);
            
        }
        else 
        {
            boton1.setOprimioBoton(false);
            boton2.setOprimioBoton(false);

            incorrecto.SetActive(true);
            canvasActual.SetActive(false);

            Debug.Log(" MiDebug Incorrecto.");
            Debug.Log(" MiDebug " + respuestasCorrectas);
        }

    }

}
