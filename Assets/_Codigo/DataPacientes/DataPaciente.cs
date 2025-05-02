using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tipoPostura
{
    supino,
    lateral,
    prono
}
public enum regionAnatomica
{
    Cabeza,
    Torax,
    Pelvis
}
public enum ExamenesCabeza
{
    [InspectorName("TAC cerebral")]
    cerebral,
    [InspectorName("TAC de senos paranasales")]
    paranasales,
    [InspectorName("TAC de �rbitas")]
    orbitas,
    [InspectorName("TAC de macizo facial")]
    facial

}
public enum ExamenesTorax
{
    [InspectorName("TAC de t�rax simple")]
    torax,
    [InspectorName("TAC de t�rax de alta resolucion")]
    altaResolucion,
    [InspectorName("AngioTAC de t�rax")]
    angioTAC

}
public enum ExamenesPelvis
{
    [InspectorName("TAC de pelvis �sea")]
    osea,
    [InspectorName("TAC ginecol�gica")]
    ginecologica,
    [InspectorName("TAC prost�tica")]
    prostatica
}

[CreateAssetMenu(fileName = "Nuevo Paciente", menuName = "Paciente")]
public class DataPaciente : ScriptableObject
{
    public GameObject prefab;
    public string Nombre;
    public string edad;
    public string altura;
    public string peso;
    public tipoPostura postura;
    public regionAnatomica region;

    [HideInInspector] public ExamenesCabeza examenCabeza;
    [HideInInspector] public ExamenesTorax examenTorax;
    [HideInInspector] public ExamenesPelvis examenPelvis;




}
