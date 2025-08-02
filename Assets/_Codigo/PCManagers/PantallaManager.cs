using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
public class PantallaManager : MonoBehaviour
{
    public static PantallaManager instance;

    [SerializeField] int numeroPantalla = 0;
    [SerializeField] GameObject Pantalla0;
    [SerializeField] GameObject Pantalla1;
    [SerializeField] GameObject Pantalla2;
    [SerializeField] GameObject Pantalla3;
    [SerializeField] bool Continuar = false;
    [SerializeField] bool PosturaCorrecta = false;
    [SerializeField] bool RegionAnatomicaCorrecta = false;
    [SerializeField] bool TipoExamenCorrecto = false;
    [SerializeField] int numeroCamposLlenos = 0;
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
    public void Update()
    {
        if (Continuar)
        {
            switch (numeroPantalla)
            {
                case 0:
                    if (LaserManager.instance.getPacienteEnLaser())
                    {
                        numeroPantalla++;
                        Pantalla0.SetActive(false);
                        Pantalla1.SetActive(true);
                        Continuar = false;
                    }
                    break;
                case 1:
                    if (PosturaCorrecta && numeroCamposLlenos == 4)
                    {
                        numeroPantalla++;
                        Pantalla1.SetActive(false);
                        Pantalla2.SetActive(true);
                        Continuar = false;
                    }
                    else if(numeroCamposLlenos < 4)
                    {
                        Debug.Log(" Perra :faltan campos por llenar");
                        Continuar = false;
                    }
                    else if (!PosturaCorrecta)
                    {
                        Debug.Log(" Perra :La postura digitada no es la correcta");
                        Continuar = false;
                    }
                    break;

                case 2:
                    if (RegionAnatomicaCorrecta && TipoExamenCorrecto)
                    {
                        numeroPantalla++;
                        Pantalla2.SetActive(false);
                        Pantalla3.SetActive(true);
                        Continuar = false;
                    }
                    else if(!RegionAnatomicaCorrecta)
                    {
                        Debug.Log(" Perra :region anatomica incorrecta");
                        Continuar = false;
                    }
                    else if (!TipoExamenCorrecto)
                    {
                        Debug.Log(" Perra :tipo de examen incorrecto");
                        Continuar = false;
                    }
                    break;
                case 3:
                    Continuar = false;
                    numeroPantalla++;
                    SceneManager.LoadScene("Cuestionario");
                    
                    break;
            }
           
            
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
    public void llenarNumeroCampos()
    {
        numeroCamposLlenos++;
    }
}
