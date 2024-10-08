using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    private ShopManager shopManager;
    private Button button;

    private void Awake()
    {
        shopManager = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(Buy);
    }

    private void Buy()
    {
        shopManager.BuyProduct();
    }
}
