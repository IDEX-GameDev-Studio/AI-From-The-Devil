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
    private InteractionData _lastInteractionData;
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
        // Snapshot the data BEFORE Interact(): Interact() may destroy the object (pickup, one-shot door),
        // and reading .InteractionData afterwards would throw MissingReferenceException.
        if (_playerInputActions.Player.Interact.WasPressedThisFrame())
        {
            if (currentObject != null)
            {
                InteractionData data = currentObject.InteractionData;
                currentObject.Interact();
                _interactionEvents.Raise(data);
            }
        }


        Debug.DrawRay(ray.origin, ray.direction * _rayDistance, Color.red);
        if (currentObject != _lastObject)
        {
            // Use the cached data: _lastObject may already be destroyed (consumed, scene change),
            // but InteractionData is a ScriptableObject asset and outlives scene objects.
            if (_lastInteractionData != null)
            {
                _targetingEvents.RaiseExit(_lastInteractionData);
            }

            _lastInteractionData = currentObject != null ? currentObject.InteractionData : null;

            if (_lastInteractionData != null)
            {
                _targetingEvents.Raise(_lastInteractionData);
            }

            _lastObject = currentObject;
        }
    }
    
}
