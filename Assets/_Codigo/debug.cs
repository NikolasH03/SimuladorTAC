using UnityEngine;
using TMPro; // Aseg�rate de tener TextMeshPro importado

public class debug : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    public GameObject rotacionCamara;

    public void Start()
    {

    }
    void Update()
    {
        fpsText.text = rotacionCamara.transform.rotation.ToString();
    }
}

