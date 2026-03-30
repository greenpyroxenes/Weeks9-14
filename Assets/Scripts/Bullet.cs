using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    //Same code as rocket
    public bool pew = false;
    public bool enemyDest = false;
    public BulletSpawner spawn;
    public Vector3 cros;
    public Vector2 cur;
    public float xPos;
    public float yPos;
    float t = 0;
    public SpriteRenderer sr;
    public SpriteRenderer enemySr;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawn = GetComponentInParent<BulletSpawner>();
        cros = spawn.crosPos;
        transform.parent = null;
        sr = GetComponent<SpriteRenderer>();
        if (spawn.spawned == true)
        {
            enemySr = spawn.srEnemy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pew == true)
        {
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(spawn.transform.position, cros, t);
            cur = transform.position;
            xPos = cur.x;
            yPos = cur.y;
            transform.position = cur;
        }
        if(transform.position == cros)
        {
            pew = false;
            Destroy(gameObject);
        }
            if (enemySr.bounds.Contains(transform.position))
            {
                pew = false;
                spawn.dest = true;
                Destroy(gameObject);
            }
    }

    
}
