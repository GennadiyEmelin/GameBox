using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private Character character;

    [Header("Other")]
    [SerializeField] private GameObject panelDead;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private Text textMoney;
    [SerializeField] private Text textEnemy;
    [SerializeField] private Text textMoneyDead;
    [SerializeField] private Text textTimeDead;
    [SerializeField] private Text textEnemyDead;

    private float timeGame;

    private void Start()
    {

    }

    private void Update()
    {
        timeGame = Time.timeScale;
        textMoney.text = character.Money.ToString();
        textEnemy.text = character.Enemy.ToString();
        OnPauseButton();
        OnDeadPanel();
    }

    public void OnClickGamePlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

    public void OnRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnPauseButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(panelPause.activeSelf == false)
            {
                panelPause.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                panelPause.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void OnDeadPanel()
    {
        if(character.Lives <= 0)
        {
            Time.timeScale = 0;
            panelDead.SetActive(true);
            textTimeDead.text = timeGame.ToString();
            textEnemyDead.text = character.Enemy.ToString();
            textMoneyDead.text = character.Money.ToString();
        }
    }
}
