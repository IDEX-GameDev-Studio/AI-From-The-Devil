using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    [SerializeField] private float _rayDistance;
    [SerializeField] private TargetingEvents _targetingEvents;

    private IInteractable _lastObject;
    private IInteractable _currentObject;
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
        RayCastChecker();
    }
    public void RayCastChecker()
    {
        Vector2 currentMousePossition = _playerInputActions.Player.PointerPossition.ReadValue<Vector2>();
        Ray ray = _camera.ScreenPointToRay(currentMousePossition);
        RaycastHit hit;
        IInteractable interactable = null;
        if (Physics.Raycast(ray, out hit, _rayDistance))
        {

            if (hit.collider.TryGetComponent(out interactable))
            {
                _currentObject = interactable;
            }
            else
            {
                _currentObject = null;
            }
        }
        else
        {
            _currentObject = null;
        }
        if (_lastObject == null)
        {
        }

        // Developer blocks zone
        if (_playerInputActions.Player.Interact.WasPressedThisFrame())
        {
            interactable.Interact();
        }


        Debug.DrawRay(ray.origin, ray.direction * _rayDistance, Color.red);
        if (_lastObject == null && _currentObject is IInteractable)
        {
            _targetingEvents.Raise(_currentObject.InteractionData);
        }
        else if (_lastObject == _currentObject)
        {
            return;
        }
        else if (_lastObject != _currentObject && _currentObject is IInteractable)
        {
            // Dev
        }
        else if (_lastObject is IInteractable && _currentObject == null)
        {
            _targetingEvents.RaiseExit(_lastObject.InteractionData);
        }

        _lastObject = _currentObject;
    }
    
}
