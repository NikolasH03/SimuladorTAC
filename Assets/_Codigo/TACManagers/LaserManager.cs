using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public static LaserManager instance;

    [SerializeField] bool PacienteEnLaser = false;

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
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(" Perra :el laser esta en la parte " + other.tag);
        if (other.tag == PacienteManager.instance.getRegionAnatomica())
        {
            PacienteEnLaser = true;
            
            //Debug.Log(" Perra :el laser esta en la parte correcta");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag == PacienteManager.instance.getRegionAnatomica())
        {
            PacienteEnLaser = false;

        }
    }

    public bool getPacienteEnLaser()
    {
        
        return PacienteEnLaser;
    }
}
