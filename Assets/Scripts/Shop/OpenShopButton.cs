using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShopButton : MonoBehaviour
{
    [SerializeField]
    private GameObject shop;

    [SerializeField]
    private GameObject main;

    private Button shopButton;

    void Start()
    {
        shopButton = GetComponent<Button>();
        shopButton.onClick.AddListener(TransitionToShop);
    }

    private void TransitionToShop()
    {
        main.SetActive(false);
        shop.SetActive(true);
    }

}
