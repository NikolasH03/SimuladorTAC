using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInteractuables : MonoBehaviour
{
    [SerializeField] bool YaTieneObjeto = false;


    public void Update()
    {
        //Debug.Log(" MiDebug :" + YaTieneObjeto);
    }
    public bool GetYaTieneObjeto()
    {
        return YaTieneObjeto;
    }
public void SetYaTieneObjeto(bool objeto)
    {
       YaTieneObjeto = objeto;
    }

}
