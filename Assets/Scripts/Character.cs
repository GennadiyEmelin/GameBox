using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private EnemyAgent _enemyAgent;
    [SerializeField] private float lives;
    private float _hpFullAmount;
    [SerializeField] private Image hp;
    void Start()
    {
        _hpFullAmount = 1;
        lives = 10f;
    }

    void Update()
    {
        hp.fillAmount = _hpFullAmount;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemyAgent.Live -= 1;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {

        }

        if (collision.gameObject.GetComponent<EnemyAgent>())
        {
            _hpFullAmount -= 0.1f;
            lives --;
        }
    }
}
