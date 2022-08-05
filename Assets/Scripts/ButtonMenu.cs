using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public void OnClickGamePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = false;
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
