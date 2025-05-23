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
            PantallaManager.instance.setPosturaCorrecta(true);
        else
            PantallaManager.instance.setPosturaCorrecta(false);
    }

    public void VerificarRegion(string nombreBoton)
    {
        if (nombreBoton == PacienteManager.instance.getRegionAnatomica())
            PantallaManager.instance.setRegionCorrecta(true);
        else
            PantallaManager.instance.setRegionCorrecta(false);
    }

    public void VerificarExamen(string texto)
    {
        if (texto == PacienteManager.instance.GetExamenActual())
            PantallaManager.instance.setExamen(true);
        else
            PantallaManager.instance.setExamen(false);
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
