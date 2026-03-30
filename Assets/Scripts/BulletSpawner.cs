using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawner : MonoBehaviour
{
    //Same code as rocket spawner
    public GameObject bulletPrefab;
    public GameObject cross;
    public GameObject eSpawn;
    public Bullet shotScript;
    public Crosshair crosshair;
    public EnemySpawner enemySpawn;
    public bool dest = false;
    public bool spawn = false;
    public bool shot = false;
    public bool spawned = false;
    public Vector3 crosPos;
    public Vector2 bulletPos;
    public SpriteRenderer srEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawn == true)
        {
            Instantiate(bulletPrefab, this.transform);
            shotScript = bulletPrefab.GetComponent<Bullet>();
            crosPos = cross.transform.position;
            spawn = false;
            shotScript.pew = true;
            shot = true;
            enemySpawn.check = true;
            crosshair.spawned = false;
        }
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
        if (shotScript.pew == true)
        {
            bulletPos = shotScript.cur;
            return bulletPos;
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
