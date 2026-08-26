using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class SingleSceneSplashScreen : MonoBehaviour
{
    [Header("UI Заставки (Інтро)")]
    [SerializeField] private CanvasGroup introCanvasGroup;
    [SerializeField] private GameObject introPanelObject;

    [Header("Час Інтро (секунди)")]
    [SerializeField] private float fadeInTime = 1.5f;
    [SerializeField] private float displayTime = 2.0f;
    [SerializeField] private float fadeOutTime = 1.5f;

    [Header("UI Тексту Старту")]
    public GameObject pressKeyText;

    [Header("Камера та Монітор")]
    [SerializeField] private Transform monitorTarget;
    [SerializeField] private GameObject monitorCanvas;
    [SerializeField] private CanvasGroup monitorCanvasGroup;
    [SerializeField] private GameObject psxCanvas;
    public float zoomSpeed = 3f;

    private bool canStart = false;
    private bool isZooming = false;
    private Transform _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main.transform;

        if (pressKeyText != null)
            pressKeyText.SetActive(false);

        if (monitorCanvasGroup != null)
            monitorCanvasGroup.alpha = 0f;

        if (monitorCanvas != null)
            monitorCanvas.SetActive(true);

        if (psxCanvas != null)
            psxCanvas.SetActive(true);

        if (introCanvasGroup != null)
            StartCoroutine(PlaySplashScreen());
    }

    private IEnumerator PlaySplashScreen()
    {
        introCanvasGroup.alpha = 0f;

        yield return StartCoroutine(Fade(0f, 1f, fadeInTime));

        yield return new WaitForSeconds(displayTime);

        yield return StartCoroutine(Fade(1f, 0f, fadeOutTime));

        if (introPanelObject != null)
            introPanelObject.SetActive(false);

        if (pressKeyText != null)
        {
            pressKeyText.SetActive(true);
            canStart = true;
        }
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            introCanvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            yield return null;
        }
        introCanvasGroup.alpha = endAlpha;
    }

    private void Update()
    {
        bool keyPressed = false;

        if (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame) keyPressed = true;
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) keyPressed = true;
        if (canStart && keyPressed)
        {
            canStart = false;
            pressKeyText.SetActive(false);
            isZooming = true;
        }

        if (isZooming)
        {
            _mainCamera.position = Vector3.Lerp(_mainCamera.position, monitorTarget.position, Time.deltaTime * zoomSpeed);
            _mainCamera.rotation = Quaternion.Lerp(_mainCamera.rotation, monitorTarget.rotation, Time.deltaTime * zoomSpeed);

            if (Vector3.Distance(_mainCamera.position, monitorTarget.position) < 0.01f)
            {
                isZooming = false;
                if (monitorCanvasGroup != null)
                    monitorCanvasGroup.alpha = 1f;
                gameObject.SetActive(false);
            }
        }
    }
}