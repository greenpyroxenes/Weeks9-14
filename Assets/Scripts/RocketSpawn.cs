using UnityEngine;
using UnityEngine.InputSystem;

public class RocketSpawn : MonoBehaviour
{
    //Set variables
    public GameObject rocketPrefab;
    public GameObject cross;
    public GameObject eSpawn;
    public Rocket rocketScript;
    public Crosshair crosshair;
    public EnemySpawner enemySpawn;
    public bool dest = false;
    public bool spawn = false;
    public bool shot = false;
    public bool spawned = false;
    public Vector3 crosPos;
    public Vector2 rocketPos;
    public SpriteRenderer srEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If spawn condition is met, Spawn rocket as prefab. Have the crosshair position set so the rocket can grab it
        if (spawn == true)
        {
            Instantiate(rocketPrefab, this.transform);
            rocketScript = rocketPrefab.GetComponent<Rocket>();
            crosPos = cross.transform.position;
            spawn = false;
            rocketScript.pew = true;
            shot = true;
            enemySpawn.check = true;
            crosshair.spawned = false;
        }
        //if bullet is shot, and destroy is true, make enemy gone true
        if (shot == true)
        {
            if (dest == true)
            {
                enemySpawn.gone = true;
            }
        }
        spawned = enemySpawn.exist = true;
    }
    public Vector2 GetBulletPos()
    {
        if (rocketScript.pew == true)
        {
            rocketPos = rocketScript.cur;
            return rocketPos;
        }
        else
        {
            return default;
        }
    }

    public void setFalse()
    {
        enemySpawn.check = false;
        shot = false;
    }

}

