using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Rocket : MonoBehaviour
{
    //Set Variables
    public bool pew = false;
    public bool enemyDest = false;
    public RocketSpawn spawn;
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
        //When spawned. Grab enemy sprite renderer, and rocket spawn script.
        //Make it unparent
        spawn = GetComponentInParent<RocketSpawn>();
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
        //If shot, have the shot spawn, then lerp towards the crosshair.
        if (pew == true)
        {
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(spawn.transform.position, cros, t);
            cur = transform.position;
            xPos = cur.x;
            yPos = cur.y;
            transform.position = cur;
        }
        //If the bullet is at the crosshairs shot position, delete it
        if (transform.position == cros)
        {
            pew = false;
            Destroy(gameObject);
        }
        //if the bullet is in the enemy boubds, delete it and set variable for spawn code
            if (enemySr.bounds.Contains(transform.position))
            {
                pew = false;
                spawn.dest = true;
                Destroy(gameObject);
            }
    }


}