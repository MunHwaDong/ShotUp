using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    public Sprite productImage;
    public int price;

    public Product(Sprite productImage, int price)
    {
        this.productImage = productImage;
        this.price = price;
    }
}
