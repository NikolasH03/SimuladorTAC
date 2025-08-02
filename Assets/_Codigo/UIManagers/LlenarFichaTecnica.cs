using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LlenarFichaTecnica : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> texto;
    [SerializeField] GameObject contenido;
    private void Start()
    {
        contenido.SetActive(true);
        for(int i=0; i<texto.Count; i++)
        {
            switch (i)
            {
                case 0: texto[i].text = PacienteManager.instance.getNombre(); break;
                case 1: texto[i].text = PacienteManager.instance.getEdad(); break;
                case 2: texto[i].text = PacienteManager.instance.getAltura(); break;
                case 3: texto[i].text = PacienteManager.instance.getPeso(); break;
                case 4: texto[i].text = PacienteManager.instance.getRegionAnatomica(); break;
                case 5: texto[i].text = PacienteManager.instance.getPosturaPaciente(); break;
                case 6: texto[i].text = PacienteManager.instance.GetExamenActual(); break;
            }
        }
        contenido.SetActive(false);
    }
}
