using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startPanel;
    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1;
        GameManager.isgameOver = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
        startPanel.SetActive(false);
        Time.timeScale = 1;

    }
}
