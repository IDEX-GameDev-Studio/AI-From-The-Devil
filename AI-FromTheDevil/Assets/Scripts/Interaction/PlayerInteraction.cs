using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _rayDisctance;

    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }
    void FixedUpdate()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _rayDisctance))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable) && ))
            {))
        }

    }
}
