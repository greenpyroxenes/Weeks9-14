using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemySpawner eSpawnScript;
    public GameObject shot;
    public Vector2 enemyPos;
    public Vector2 bullet;
    public SpriteRenderer sr;
    public bool bye = false;
    public Transform enemyTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eSpawnScript = GetComponentInParent<EnemySpawner>();
        sr = GetComponent<SpriteRenderer>();
        enemyTransform = GetComponent<Transform>();
        enemyTransform.localScale = Vector2.zero;
        StartCoroutine(GetCloser());
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

    IEnumerator GetCloser()
    {
        float t = 0;

        while(t < 2)
        {
            t += Time.deltaTime;
            enemyTransform.localScale = new Vector2(0.25f, 0.25f) * t;
            yield return null;
        }
    }
}
