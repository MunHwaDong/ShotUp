using UnityEngine;
using UnityEngine.UI;

public class NextProductButton : MonoBehaviour
{
    private ShopManager shopManager;
    private Button button;

    private void Start()
    {
        shopManager = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(shopManager.ShowNextProduct);
    }
}
