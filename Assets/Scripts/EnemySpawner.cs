using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    //Set variables
    public BulletSpawner spawnScript;
    public RocketSpawn rocketSpawnScript;
    public Enemy enemy;
    public GameObject enemyPrefab;
    public GameObject spawnedEnemy;
    public Vector2 bulletPos;
    public Vector2 location;
    public bool check = false;
    public bool gone = false;
    public bool exist = false;
    public List<GameObject> enemies;
    public float speed = 5.0f;
    public float borderOne;
    public float borderTwo;
    public float borderThree;
    public float borderFour;
    public float divide;
    public float divide2;
    public float timer;
    public float speedY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get bounds of screen to be offset
        divide = (Screen.width / 6);
        divide2 = (Screen.height / 6);
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //Have the spawner go around the screen randomly
        Vector2 newPos = transform.position;
        newPos.x += speed * Time.deltaTime;
        newPos.y += speedY * Time.deltaTime;
        transform.position = newPos;
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        borderOne = (Screen.width - Screen.width) + (divide);
        borderTwo = Screen.width - (divide);
        borderThree = (Screen.height - Screen.height) + (divide2);
        borderFour = Screen.height - (divide2);
        //if the spawner hits a border change direction, if it goes too far out set back to 0
        if (screenPos.x < borderOne || screenPos.x > borderTwo)
        {
            speed *= -1;
        }
        if (screenPos.y < borderThree || screenPos.y > borderFour)
        {
            speedY *= -1;
        }
        if(screenPos.x < borderOne - 30 || screenPos.x > borderTwo + 30)
        {
            transform.position = Vector2.zero;
        }
        if (screenPos.y < borderThree - 30 || screenPos.y > borderFour + 30)
        {
            transform.position = Vector2.zero;
        }
        //Remove the enemy in the list and set varibles to be reset
        if (gone == true)
        {
            enemies.Remove(spawnedEnemy);
            Destroy(spawnedEnemy);
            spawnScript.dest = false;
            rocketSpawnScript.dest = false;
            gone = false;
            for (int i = 0; i < enemies.Count; i++)
            {
                spawnScript.srEnemy = enemies[i].GetComponent<SpriteRenderer>();
                rocketSpawnScript.srEnemy = enemies[i].GetComponent<SpriteRenderer>();
                enemy = enemies[i].GetComponent<Enemy>();
                spawnedEnemy = enemies[i];
            }
        }
        //Timer counts down to spawn enemy. Enemy is spawned once timer reaches 0 and gets added to a list
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            exist = true;
            spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemies.Add(spawnedEnemy);
            for (int i = 0; i < enemies.Count; i++)
            {
                spawnScript.srEnemy = enemies[i].GetComponent<SpriteRenderer>();
                rocketSpawnScript.srEnemy = enemies[i].GetComponent<SpriteRenderer>();
                enemy = enemies[i].GetComponent<Enemy>();
            }
            timer = 3;
            speed = Random.Range(5, 10);
            speedY = Random.Range(5, 10);
        }
    }
}
