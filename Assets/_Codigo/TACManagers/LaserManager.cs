using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{

    [SerializeField] bool PacienteEnLaser = false;
    private void OnTriggerEnter(Collider other)
    {     
        if (other.tag == PacienteManager.instance.getRegionAnatomica())
        {
            PacienteEnLaser = true;
            Debug.Log(" Perra :el laser esta en la parte correcta");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PacienteEnLaser = false;
    }
}
