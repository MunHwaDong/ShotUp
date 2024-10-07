using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    private readonly string userId;
    public int maxScore { get; private set; }
    public int money { get; private set; }
    public Sprite playerSprite { get; private set; }

    public Data(int maxScore, int money)
    {
        this.maxScore = maxScore;
        this.money = money;
    }

    public Data(string userId, int maxScore, int money, Sprite playerSprite)
    {
        this.userId = userId;
        this.maxScore = maxScore;
        this.money = money;
        this.playerSprite = playerSprite;
    }
}
