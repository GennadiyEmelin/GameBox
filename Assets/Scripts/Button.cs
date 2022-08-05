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
    [SerializeField] private GameObject gamePanelInfo;
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
        timeGame += Time.deltaTime;
        textMoney.text = character.Money.ToString();
        textEnemy.text = character.Enemy.ToString();
        OnPauseButton();
        OnDeadPanel();
    }

    public void OnClikcResume()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
        gamePanelInfo.SetActive(true);
        Cursor.visible = false;
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickRestartGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnPauseButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(panelPause.activeSelf == false)
            {
                Cursor.visible = true;
                gamePanelInfo.SetActive(false);
                panelPause.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Cursor.visible = false;
                gamePanelInfo.SetActive(true);
                panelPause.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void OnDeadPanel()
    {
        if(character.Lives <= 0)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            panelDead.SetActive(true);
            textTimeDead.text = timeGame.ToString();
            textEnemyDead.text = character.Enemy.ToString();
            textMoneyDead.text = character.Money.ToString();
        }
    }
}
