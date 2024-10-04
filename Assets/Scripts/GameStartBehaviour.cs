using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartBehaviour : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(GameStart);
    }

    private void GameStart()
    {
        SceneManager.LoadScene("InGame");
    }
}
