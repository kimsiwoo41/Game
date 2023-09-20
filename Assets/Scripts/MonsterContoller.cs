using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterContoller : MonoBehaviour
{
    public int hp = 100;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hp -= 50; // hp = hp - 50;
        Destroy(collision.gameObject);

        if (hp <= 0)
        {
            PlayerController.instance.gold += 100;
            Destroy(gameObject);
        }
    }
}
