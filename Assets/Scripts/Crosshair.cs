using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
    public float speed = 8f;
    public Vector2 movement;
    public bool controller = false;
    public bool cursor = false;
    public BulletSpawner bulletScript;
    public Vector3 shotPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (controller == true)
        {
            transform.position += (Vector3)movement * speed * Time.deltaTime;
        }
        if (cursor == true)
        {
            transform.position = movement;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            movement = context.ReadValue<Vector2>();
            controller = true;
        }
        else
        {
            controller = false;
        }
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        //Same as mouse.current.position.readvalue
        if (context.performed == true)
        {
            movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            cursor = true;
        }
        else
        {
            cursor = false;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            bulletScript.spawn = true;
            shotPos = transform.position;
        }
    }
}
