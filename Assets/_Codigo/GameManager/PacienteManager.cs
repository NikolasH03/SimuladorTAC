using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PacienteManager : MonoBehaviour
{
    [SerializeField] private List<DataPaciente> pacientes;
    [SerializeField] private DataPaciente pacienteActual;
    [SerializeField] TextMeshProUGUI textoTipoPostura;
    void Start()
    {
        pacienteActual = pacientes[Random.Range(0, pacientes.Count)];
    }

    void Update()
    {
        textoTipoPostura.text = pacienteActual.postura.ToString();
    }
}
