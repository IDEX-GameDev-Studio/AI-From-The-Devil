using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private TargetingEvents _targetingEvents;
    [SerializeField] private InteractionEvents _interactionEvents;

    private IInteractable _lastObject;
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
        // TEMPORARY test hook: press R in Play Mode to reload the scene
        // and check for duplicate event calls. Remove after testing.
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        RayCastChecker();
    }
    public void RayCastChecker()
    {
        Vector2 currentMousePossition = _playerInputActions.Player.PointerPossition.ReadValue<Vector2>();
        Ray ray = _camera.ScreenPointToRay(currentMousePossition);
        RaycastHit hit;
        IInteractable currentObject = null;
        if (Physics.Raycast(ray, out hit, _rayDistance, _interactableMask))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                currentObject = interactable;
            }
        }

        // Developer blocks zone: guard clause, clicking empty space is expected, not exceptional.
        if (_playerInputActions.Player.Interact.WasPressedThisFrame())
        {
            if (currentObject != null)
            {
                currentObject.Interact();
                _interactionEvents.Raise(currentObject.InteractionData);
            }
        }


        Debug.DrawRay(ray.origin, ray.direction * _rayDistance, Color.red);
        if (currentObject != _lastObject)
        {
            if (_lastObject != null)
            {
                _targetingEvents.RaiseExit(_lastObject.InteractionData);
            }

            if (currentObject != null)
            {
                _targetingEvents.Raise(currentObject.InteractionData);
            }

            _lastObject = currentObject;
        }
    }
    
}
