using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Canvas MainUI;

    [SerializeField]
    private Canvas GameOverUI;

    private void Awake()
    {
        EventBus.Subscribe(EventType.START, DeactiveGameOverUI);
        EventBus.Subscribe(EventType.CRUSH, GameOver);
        EventBus.Subscribe(EventType.RESTART, ReGame);
    }

    private void GameOver()
    {
        DeactiveMainUI();
        ActiveGameOverUI();
    }

    private void ReGame()
    {
        DeactiveGameOverUI();
        ActiveMainUI();
    }

    private void ActiveMainUI()
    {
        MainUI.gameObject.SetActive(true);
    }

    private void DeactiveMainUI()
    {
        MainUI.gameObject.SetActive(false);
    }

    private void ActiveGameOverUI()
    {
        GameOverUI.gameObject.SetActive(true);
    }

    private void DeactiveGameOverUI()
    {
        GameOverUI.gameObject.SetActive(false);
    }

}
