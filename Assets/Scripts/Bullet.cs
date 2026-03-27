using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public bool pew = false;
    public bool destroy = false;
    public BulletSpawner spawn;
    public Vector3 cros;
    public Vector2 cur;
    public float xPos;
    public float yPos;
    float t = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawn = GetComponentInParent<BulletSpawner>();
        cros = spawn.crosPos;
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
            destroy = true;
            Destroy(gameObject);
        }
    }
}
