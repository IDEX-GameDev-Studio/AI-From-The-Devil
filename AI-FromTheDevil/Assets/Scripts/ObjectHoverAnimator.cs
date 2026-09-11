using UnityEngine;

public class ObjectHoverAnimator : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private string targetTag = "Item";
    [SerializeField] private Animator canvasImageAnimator;
    [SerializeField] private LayerMask interactableLayers;

    [Header("Animator Parameters")]
    [SerializeField] private string hoverTriggerName = "PlayScale";
    [SerializeField] private string keepHoverBoolName = "IsHovered";
    [SerializeField] private string unhoverTriggerName = "PlayUnhover";

    private bool isCurrentlyHovering = false;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        
        if (canvasImageAnimator == null)
        {

        }
    }

    private void Update()
    {
        if (canvasImageAnimator == null) return;

        CheckMouseHover();
    }

    private void CheckMouseHover()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayers))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                if (!isCurrentlyHovering)
                {
                    // 1. Mouse just entered the object: Play scale animation
                    canvasImageAnimator.SetTrigger(hoverTriggerName);
                    canvasImageAnimator.SetBool(keepHoverBoolName, true);
                    isCurrentlyHovering = true;
                }
                return;
            }
        }
        
        if (isCurrentlyHovering)
        {
            canvasImageAnimator.SetBool(keepHoverBoolName, false);
            canvasImageAnimator.SetTrigger(unhoverTriggerName);
            isCurrentlyHovering = false;
        }
    }
}
