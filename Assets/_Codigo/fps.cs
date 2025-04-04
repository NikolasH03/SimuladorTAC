using UnityEngine;
using TMPro; // Asegúrate de tener TextMeshPro importado

public class fps : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    private float deltaTime = 0.0f;

    public void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = $"FPS: {Mathf.Ceil(fps)}";
    }
}

