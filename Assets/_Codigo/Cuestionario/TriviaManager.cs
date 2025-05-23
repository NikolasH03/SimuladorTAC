using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PreguntaTrivia
{
    public string respuestaCorrecta;
    public GameObject canvasPregunta;
    public BotonRespuesta boton1;
    public BotonRespuesta boton2;
}

public class TriviaManager : MonoBehaviour
{
    [SerializeField] List<PreguntaTrivia> preguntas;
    [SerializeField] GameObject correcto;
    [SerializeField] GameObject incorrecto;

    private int preguntaActual = 0;
    public int respuestasCorrectas = 0;

    private void Start()
    {
        correcto.SetActive(false);
        incorrecto.SetActive(false);
        ActivarPregunta(preguntaActual);
    }

    public void SeleccionarOpcion(string opcionElegida)
    {
        PreguntaTrivia pregunta = preguntas[preguntaActual];

        if (opcionElegida == pregunta.respuestaCorrecta)
        {
            respuestasCorrectas++;
            correcto.SetActive(true);
            Debug.Log(" MiDebug ¡Correcto!");
        }
        else
        {
            incorrecto.SetActive(true);
            Debug.Log(" MiDebug Incorrecto.");
        }

        Debug.Log(" MiDebug Respuestas correctas: " + respuestasCorrectas);

        // Desactiva pregunta actual y botones
        pregunta.boton1.setOprimioBoton(false);
        pregunta.boton2.setOprimioBoton(false);
        pregunta.canvasPregunta.SetActive(false);

        // Pasa a la siguiente después de un momento
        //StartCoroutine(SiguientePreguntaConRetraso(1.5f));
    }

    //IEnumerator SiguientePreguntaConRetraso(float delay)
    //{
    //    yield return new WaitForSeconds(delay);

    //    correcto.SetActive(false);
    //    incorrecto.SetActive(false);

    //    preguntaActual++;
    //    if (preguntaActual < preguntas.Count)
    //    {
    //        ActivarPregunta(preguntaActual);
    //    }
    //    else
    //    {
    //        Debug.Log(" MiDebug Trivia terminada.");
    //        // Aquí podrías mostrar un resumen o terminar la escena
    //    }
    //}

    private void ActivarPregunta(int indice)
    {
        preguntas[indice].canvasPregunta.SetActive(true);
    }
    private void Update()
    {
        //if ()
        //{

        //}
    }
}

