using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private AudioSource DamageSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyAgent>())
        {
            DamageSound.Play();
            character.Lives -= 0.2f;
        }
    }
}
