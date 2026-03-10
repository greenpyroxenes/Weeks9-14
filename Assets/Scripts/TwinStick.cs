using UnityEngine;
using UnityEngine.InputSystem;

public class TwinStick : MonoBehaviour
{

    public float speed = 5f;
    public float rotSpeed = 10f;
    public Vector2 movement;
    public Vector2 look;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        Vector3 newRot = transform.eulerAngles;
        newRot.z += look.x * rotSpeed * Time.deltaTime;
        transform.eulerAngles = newRot;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }
}
