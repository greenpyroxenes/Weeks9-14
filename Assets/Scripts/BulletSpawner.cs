using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;
    public bool spawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn == true)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            spawn = false;
        }
    }

    
}
