using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public readonly string userId;
    public int maxScore { get; private set; }
    public int money { get; private set; }
    public Sprite playerSprite { get; private set; }

    public Data()
    {
        this.maxScore = 0;
        this.money = 0;
    }

    public Data(int maxScore, int money)
    {
        this.maxScore = maxScore;
        this.money = money;
    }

    public Data(Data data)
    {
        this.userId = data.userId;
        this.maxScore = data.maxScore;
        this.money = data.money;
        this.playerSprite = data.playerSprite;
    }

    public Data(string userId, int maxScore, int money, Sprite playerSprite)
    {
        this.userId = userId;
        this.maxScore = maxScore;
        this.money = money;
        this.playerSprite = playerSprite;
    }
}
