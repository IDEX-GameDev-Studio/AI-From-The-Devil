using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 input = Keyboard.current != null
            ? new Vector2(
                (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0),
                (Keyboard.current.wKey.isPressed ? 1 : 0) - (Keyboard.current.sKey.isPressed ? 1 : 0)
              )
            : Vector2.zero;

        Vector3 movement = transform.right * input.x + transform.forward * input.y;

        controller.Move(movement * speed * Time.deltaTime);
    }
}