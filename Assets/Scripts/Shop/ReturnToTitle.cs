using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToTitle : MonoBehaviour
{
    [SerializeField]
    private GameObject shop;

    [SerializeField]
    private GameObject main;

    private Button exitButton;

    void Start()
    {
        exitButton = GetComponent<Button>();
        exitButton.onClick.AddListener(TransitionToTitle);
    }

    private void TransitionToTitle()
    {
        main.SetActive(true);
        shop.SetActive(false);
    }

}
