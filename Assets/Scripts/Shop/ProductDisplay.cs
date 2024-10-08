using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductDisplay : MonoBehaviour
{
    private ShopManager shopManager;

    [SerializeField]
    private Image product;

    [SerializeField]
    private TextMeshProUGUI price;

    [SerializeField]
    private TextMeshProUGUI playerMoney;

    private void Awake()
    {
        shopManager = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>();
        shopManager.updateProduct += DisplayProduct;
        shopManager.updateMoney += DisplayMoney;
    }

    private void DisplayProduct(Product prod)
    {
        product.sprite = prod.productImage;
        price.text = prod.price.ToString();
    }

    private void DisplayMoney(int money)
    {
        playerMoney.text = money.ToString();
    }
}
