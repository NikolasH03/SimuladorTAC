using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificadorGlobal : MonoBehaviour
{
    public static VerificadorGlobal instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    public void VerificarPostura(string nombreBoton)
    {
        if (nombreBoton == PacienteManager.instance.getPosturaPaciente())
        {
            PantallaManager.instance.setPosturaCorrecta(true);
            ControladorSonido.instance.playAudio(ControladorSonido.instance.correcto);
        }

        else
        {
            PantallaManager.instance.setPosturaCorrecta(false);
            ControladorSonido.instance.playAudio(ControladorSonido.instance.incorrecto);
        }
            
    }

    public void VerificarRegion(string nombreBoton)
    {
        if (nombreBoton == PacienteManager.instance.getRegionAnatomica())
        {
            PantallaManager.instance.setRegionCorrecta(true);
            ControladorSonido.instance.playAudio(ControladorSonido.instance.correcto);
        }

        else
        {
            PantallaManager.instance.setRegionCorrecta(false);
            ControladorSonido.instance.playAudio(ControladorSonido.instance.incorrecto);
        }
           
    }

    public void VerificarExamen(string texto)
    {
        if (texto == PacienteManager.instance.GetExamenActual())
        {
            PantallaManager.instance.setExamen(true);
            ControladorSonido.instance.playAudio(ControladorSonido.instance.correcto);
        }

        else
        {
            PantallaManager.instance.setExamen(false);
            ControladorSonido.instance.playAudio(ControladorSonido.instance.incorrecto);
        }
            
    }

    public void ActualizarExamenes(string region, List<TMPro.TextMeshProUGUI> botones)
    {
        List<string> nombres = PantallaManager.instance.getListaExamenes(region);
        for (int i = 0; i < botones.Count; i++)
        {
            botones[i].text = nombres[i];
        }
    }

}
