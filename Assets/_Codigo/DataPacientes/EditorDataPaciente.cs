using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DataPaciente))]
public class EditorDataPaciente : Editor
{

    private SerializedProperty nombreProp;
    private SerializedProperty edadProp;
    private SerializedProperty alturaProp;
    private SerializedProperty pesoProp;
    private SerializedProperty posturaProp;
    private SerializedProperty regionProp;


    private string[] opcionesCabeza;
    private string[] opcionesTorax;
    private string[] opcionesPelvis;

    private void OnEnable()
    {
        nombreProp = serializedObject.FindProperty("Nombre");
        edadProp = serializedObject.FindProperty("edad");
        alturaProp = serializedObject.FindProperty("altura");
        pesoProp = serializedObject.FindProperty("peso");
        posturaProp = serializedObject.FindProperty("postura");
        regionProp = serializedObject.FindProperty("region");

        opcionesCabeza = System.Enum.GetNames(typeof(ExamenesCabeza));
        opcionesTorax = System.Enum.GetNames(typeof(ExamenesTorax));
        opcionesPelvis = System.Enum.GetNames(typeof(ExamenesPelvis));
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(nombreProp);
        EditorGUILayout.PropertyField(edadProp);
        EditorGUILayout.PropertyField(alturaProp);
        EditorGUILayout.PropertyField(pesoProp);
        EditorGUILayout.PropertyField(posturaProp);

        EditorGUILayout.PropertyField(regionProp, new GUIContent("Región Anatómica"));
        switch ((regionAnatomica)regionProp.enumValueIndex)
        {
            case regionAnatomica.Cabeza:
                EditorGUILayout.PropertyField(
                    serializedObject.FindProperty("examenCabeza"),
                    new GUIContent("Tipo de Examen")
                );
                break;
            case regionAnatomica.Torax:
                EditorGUILayout.PropertyField(
                    serializedObject.FindProperty("examenTorax"),
                    new GUIContent("Tipo de Examen")
                );
                break;
            case regionAnatomica.Pelvis:
                EditorGUILayout.PropertyField(
                    serializedObject.FindProperty("examenPelvis"),
                    new GUIContent("Tipo de Examen")
                );
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}

