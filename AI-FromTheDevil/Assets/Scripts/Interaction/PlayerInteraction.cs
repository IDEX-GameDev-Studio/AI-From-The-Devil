using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    [SerializeField] private float _rayDistance;

    private GameObject _lastObject;
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
    void Update()
    {
        Vector2 currentMousePossition = _playerInputActions.Player.PointerPossition.ReadValue<Vector2>();
        Ray ray = _camera.ScreenPointToRay(currentMousePossition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _rayDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction * _rayDistance, Color.red);
            if (hit.collider.TryGetComponent(out IInteractable interactable) && _playerInputActions.Player.Interact.WasPressedThisFrame())
            {

                if (_lastObject == null && hit.collider is IInteractable)
                {

                }
                interactable.Interact();
                
            }
            _lastObject = hit.collider.gameObject;
        }
    }
    
}
