using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private List<Product> products;

    private int productIdx = 0;

    public delegate void UpdateProduct(Product prod);
    public event UpdateProduct updateProduct;

    public delegate void UpdateCurrentMoney(int money);
    public event UpdateCurrentMoney updateMoney;

    public delegate void UpdatePlayerData(Data data);
    public event UpdatePlayerData updatePlayerData;

    private void Start()
    {
        updateProduct?.Invoke(products[productIdx]);

        gameObject.transform.parent.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        updateMoney?.Invoke(GameManager.playerData.money);
    }

    public void ShowPreviousProduct()
    {
        productIdx = ((productIdx - 1) + products.Count) % products.Count;
        updateProduct?.Invoke(products[productIdx]);
    }

    public void ShowNextProduct()
    {
        productIdx = (productIdx + 1) % products.Count;
        updateProduct?.Invoke(products[productIdx]);
    }

    public void BuyProduct()
    {
        int change = GameManager.playerData.money - products[productIdx].price;

        if (change < 0) return;

        Data newData = new Data(GameManager.playerData.userId,
                                GameManager.playerData.maxScore,
                                change,
                                products[productIdx].productImage);

        updateMoney?.Invoke(change);
        updatePlayerData?.Invoke(newData);
    }
}
