using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private Character character;

    [Header("Oter")]
    [SerializeField] private GameObject panelPause;
    [SerializeField] private Text textMoney;
    [SerializeField] private Text textEnemy;

    private void Start()
    {
        
    }

    private void Update()
    {
        textMoney.text = character.Money.ToString();
        textEnemy.text = character.Enemy.ToString();
    }

    public void OnClickGamePlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
