using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private EnemyAgent _enemyAgent;
    [SerializeField] private float lives;
    [SerializeField] private Image hp;
    void Start()
    {
        lives = 1f;
    }

    void Update()
    {
        hp.fillAmount = lives;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<EnemyAgent>().Live -= 1;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {

        }

        if (collision.gameObject.GetComponent<EnemyAgent>())
        {
            lives -= 0.1f;
        }
    }
}
