using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class RTInputHelper : MonoBehaviour
{
    private Camera _uiCamera;
    private Canvas _canvas;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();

        GameObject go = new GameObject("UICamera_ForInput");
        go.transform.SetParent(transform);
        _uiCamera = go.AddComponent<Camera>();
        _uiCamera.clearFlags = CameraClearFlags.Nothing;
        _uiCamera.cullingMask = 0;
        _uiCamera.depth = 999;
        _uiCamera.fieldOfView = 60;
        _uiCamera.nearClipPlane = 0.1f;
        _uiCamera.farClipPlane = 1000f;
        go.AddComponent<AudioListener>().enabled = false;

        _canvas.worldCamera = _uiCamera;
    }

    private void LateUpdate()
    {
        Camera main = Camera.main;
        if (main == null || _uiCamera == null) return;

        _uiCamera.transform.position = main.transform.position;
        _uiCamera.transform.rotation = main.transform.rotation;
        _uiCamera.fieldOfView = main.fieldOfView;
        _uiCamera.aspect = (float)Screen.width / Screen.height;
        _uiCamera.nearClipPlane = main.nearClipPlane;
        _uiCamera.farClipPlane = main.farClipPlane;
    }

    private void OnDestroy()
    {
        if (_uiCamera != null)
            Destroy(_uiCamera.gameObject);
    }
}
