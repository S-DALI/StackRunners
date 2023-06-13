using Assets.ExtraAssets.Scripts;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;

    public event Action startGame;
    public event Action endGame;
    private void Start()
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);
    }
    public void StartGame()
    {
        startGame?.Invoke();
        startPanel.SetActive(false);
    }
    public void EndGame()
    {
        endGame?.Invoke();
        endPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
