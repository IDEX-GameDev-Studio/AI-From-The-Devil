using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    [SerializeField] private float _rayDistance;

    private Camera _camera;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        _playerInputActions.Enable();
    }
    private void OnDisable()
    {
        _playerInputActions.Disable();
    }
    void Start()
    {
        _camera = Camera.main;
    }
    void FixedUpdate()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _rayDistance))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable) )
            {
                return;
            }

        }
    }
    
}
