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

    public Data(string userId, int maxScore, int money, Sprite sprite)
    {
        this.userId = userId;
        this.maxScore = maxScore;
        this.money = money;
        this.playerSprite = sprite;
    }

    public void CopyData(Data data)
    {
        this.maxScore = data.maxScore;
        this.money = data.money;

        if(data.playerSprite)
        {
            this.playerSprite = data.playerSprite;
        }
    }

    public void SetSprite(Sprite sprite)
    {
        this.playerSprite = sprite;
    }
}
