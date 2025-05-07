using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PacienteManager : MonoBehaviour
{
    public static PacienteManager instance;

    [SerializeField] private List<DataPaciente> pacientes;
    [SerializeField] private DataPaciente pacienteActual;
    [SerializeField] TextMeshProUGUI textoTipoPostura;
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
    void Start()
    {
        pacienteActual = pacientes[Random.Range(0, pacientes.Count)];
    }

    void Update()
    {
        textoTipoPostura.text = pacienteActual.postura.ToString();
    }

    public string getPosturaPaciente()
    {
        return pacienteActual.postura.ToString();
    }
    public string getRegionAnatomica()
    {
        return pacienteActual.region.ToString();
    }
    public string getNombre()
    {
        return pacienteActual.Nombre;
    }
    public string getEdad()
    {
        return pacienteActual.edad;
    }
    public string getAltura()
    {
        return pacienteActual.altura;
    }
    public string getPeso()
    {
        return pacienteActual.peso;
    }
}
