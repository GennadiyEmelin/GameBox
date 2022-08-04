using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAgent : MonoBehaviour
{
    [SerializeField] private EnemyAgent enemyAgent;
    [SerializeField] private Character character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyAgent>().Live -= 1;
            character.Enemy += 1;
        }
    }

}
