using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemySpawner eSpawnScript;
    public GameObject shot;
    public Vector2 enemyPos;
    public Vector2 bullet;
    public SpriteRenderer sr;
    public bool bye = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eSpawnScript = GetComponentInParent<EnemySpawner>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bye == true)
        {
            bye = false;
            eSpawnScript.exist = false;
        }
    }
}
