using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject cross;
    public Bullet shotScript;
    public bool spawn;
    public Vector3 crosPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn == true)
        {
            Instantiate(bulletPrefab, this.transform);
            shotScript = bulletPrefab.GetComponent<Bullet>();
            crosPos = cross.transform.position;
            spawn = false;
            shotScript.pew = true;
        }
    }

    
}
