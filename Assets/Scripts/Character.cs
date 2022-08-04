using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private float lives;
    private float money;
    private float enemy;
    [SerializeField] private Image hp;
    void Start()
    {
        lives = 1f;
    }

    void Update()
    {
        hp.fillAmount = lives;

        MaxLives();
    }

    private void MaxLives()
    {
        if (lives > 1f)
        {
            lives = 1f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Help1"))
        {
            lives += 1f;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Hepl05"))
        {
            lives += 0.5f;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Money"))
        {
            money += 1f;
            Destroy(collision.gameObject);
        }
    }

    public float Money
    {
        get { return money; }
    }

    public float Lives
    {
        get { return lives; }
        set { lives = value; }
    }

    public float Enemy
    {
        get { return enemy; }
        set { enemy = value; }
    }
}