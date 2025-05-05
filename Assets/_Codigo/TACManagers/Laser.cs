using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[ExecuteInEditMode]
public class Laser : MonoBehaviour
{
    //bool activated = false;
    //LineRenderer lineRenderer;
    //[SerializeField] LaserRendererSettings laserRendererSettings;

    //Vector3 sourcePosition;
    //const float farDistance = 1000f;

    //LaserSensor prevStruckLaserSensor = null;

    //[SerializeField] GameObject inputGO;

    //public IInput input {  get; private set; }

    //private void Awake()
    //{
    //   li
    //}

    public Vector3 localStartPoint = new Vector3(-1f, 0f, 0f); // Punto inicial local
    public Vector3 localEndPoint = new Vector3(1f, 0f, 0f);    // Punto final local

    public Color laserColor = Color.red;
    public float width = 0.01f;

    private LineRenderer lineRenderer;

    [SerializeField] Material lineMaterial;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // Configurar propiedades visuales
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        lineRenderer.material = lineMaterial;
        lineRenderer.material.color = laserColor;

        // Asignar puntos
        Vector3 globalStart = transform.TransformPoint(localStartPoint);
        Vector3 globalEnd = transform.TransformPoint(localEndPoint);
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, globalStart);
        lineRenderer.SetPosition(1, globalEnd);
    }
}
