using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScripts : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private GameObject panelWin;
    [SerializeField] private Text timeText;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text enemyText;
    private float time;
    void Start()
    {
        
    }

    void Update()
    {
        GameWin();
        time += Time.deltaTime;
    }

    private void GameWin()
    {
        if (character.Money == 18 & character.Enemy == 19)
        {
            Time.timeScale = 0;
            timeText.text = time.ToString();
            moneyText.text = character.Money.ToString();
            enemyText.text = character.Enemy.ToString();
            panelWin.SetActive(true);
        }
    }
}
