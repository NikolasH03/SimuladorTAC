using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using TMPro;
public class PantallaManager : MonoBehaviour
{
    public static PantallaManager instance;

    [SerializeField] int numeroPantalla = 1;
    [SerializeField] GameObject Pantalla1;
    [SerializeField] GameObject Pantalla2;
    [SerializeField] GameObject Pantalla3;
    [SerializeField] bool Continuar = false;
    [SerializeField] bool PosturaCorrecta = false;
    [SerializeField] bool TodosCamposLlenos = false;
    [SerializeField] bool RegionAnatomicaCorrecta = false;
    [SerializeField] bool TipoExamenCorrecto = false;
    [SerializeField] List<string> nombresExamenesCabeza = NombresEnum.GetAllInspectorNames<ExamenesCabeza>();
    [SerializeField] List<string> nombresExamenesTorax = NombresEnum.GetAllInspectorNames<ExamenesTorax>();
    [SerializeField] List<string> nombresExamenesPelvis = NombresEnum.GetAllInspectorNames<ExamenesPelvis>();
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

    public void Start()
    {

    }
    public void Update()
    {
        if (Continuar)
        {
            switch (numeroPantalla)
            {
                case 1:
                    if (PosturaCorrecta && TodosCamposLlenos)
                    {
                        numeroPantalla++;
                        Pantalla1.SetActive(false);
                        Pantalla2.SetActive(true);
                    }
                    else if(!TodosCamposLlenos)
                    {
                        Debug.Log(" Perra :faltan campos por llenar");
                    }
                    else if (!PosturaCorrecta)
                    {
                        Debug.Log(" Perra :La postura digitada no es la correcta");
                    }
                    break;

                case 2:
                    if (RegionAnatomicaCorrecta && TipoExamenCorrecto)
                    {
                        numeroPantalla++;
                        Pantalla2.SetActive(false);
                        Pantalla3.SetActive(true);
                    }
                    break;
            }
            Continuar = false;
        }

    }

    public void setPosturaCorrecta(bool postura)
    {
        PosturaCorrecta = postura;
    }
    public void setRegionCorrecta(bool region)
    {
        RegionAnatomicaCorrecta = region;
    }
    public void setExamen(bool region)
    {
        TipoExamenCorrecto = region;
    }
    public void setCamposLlenos(bool campos)
    {
        TodosCamposLlenos = campos;
    }
    public void setContinuar(bool continuar)
    {
        Continuar = continuar;
    }
    public List<string> getListaExamenes(string nombre)
    {
        if(nombre == "Cabeza")
        {
            return nombresExamenesCabeza;
        }
        else if (nombre == "Torax")
        {
            return nombresExamenesTorax;
        }
        else if (nombre == "Pelvis")
        {
            return nombresExamenesPelvis;
        }
        return null;
    }
}
