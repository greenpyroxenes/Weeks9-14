using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{

    public BulletSpawner spawnScript;
    public Enemy enemy;
    public GameObject enemyPrefab;
    public GameObject spawnedEnemy;
    public Vector2 bulletPos;
    public bool check = false;
    public bool gone = false;
    public bool exist = false;
    public List<GameObject> enemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (check == true)
        {
            bulletPos = spawnScript.GetBulletPos();
        }
        if(gone == true)
        {
            enemies.Remove(spawnedEnemy);
            Destroy(spawnedEnemy);
            spawnScript.dest = false;
            gone = false;
            for (int i = 0; i < enemies.Count; i++)
            {
                spawnScript.srEnemy = enemies[i].GetComponent<SpriteRenderer>();
                enemy = enemies[i].GetComponent<Enemy>();
                spawnedEnemy = enemies[i];
            }
        }
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            exist = true;
            spawnedEnemy = Instantiate(enemyPrefab, this.transform);
            enemies.Add(spawnedEnemy);
            for (int i = 0; i < enemies.Count; i++)
            {
                spawnScript.srEnemy = enemies[i].GetComponent<SpriteRenderer>();
                enemy = enemies[i].GetComponent<Enemy>();
            }
        }
    }
}
