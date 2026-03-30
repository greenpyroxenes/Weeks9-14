using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
    //Set variables
    public float speed = 8f;
    public Vector2 movement;
    public bool controller = false;
    public bool cursor = false;
    public BulletSpawner bulletScript;
    public RocketSpawn rocketScript;
    public Vector3 shotPos;
    public GameObject rifle;
    public GameObject rocket;
    public bool rifleOn;
    public bool spawned;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set rifle as default
        rifle.SetActive(true);
        rifleOn = true;
        rocket.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Make crosshair move based on controller or mouse
        if (controller == true)
        {
            transform.position += (Vector3)movement * speed * Time.deltaTime;
        }
        if (cursor == true)
        {
            transform.position = movement;
        }
        //Change the weapon when rifle is either true or false
        if(rifleOn == true)
        {
            rifle.SetActive(true);
            rocket.SetActive(false);
            bulletScript.spawn = spawned;
        }
        if(rifleOn == false)
        {
            rifle.SetActive(false);
            rocket.SetActive(true);
            rocketScript.spawn = spawned;
        }
    }

    //Movement with  controller
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

    //Movement with mouse
    public void OnPoint(InputAction.CallbackContext context)
    {
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

    //To shoot
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            spawned = true;
            shotPos = transform.position;
        }
    }

    //To swap weapons
    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            rifleOn = !rifleOn;
            bulletScript.spawn = false;
            rocketScript.spawn = false;
        }
    }
}
