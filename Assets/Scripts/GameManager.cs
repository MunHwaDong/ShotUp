using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    //GameManager의 생성자에서 Data를 new 해주니, Singleton의 생성자를 덮어버리고 계속 씬이 전환될 때마다 새로운 Data 클래스를 new 해주는 것 같아
    //GameManager의 생성자를 제거
    public static Data playerData = new Data();

    private PlayDataViewModel playDataViewModel;
    private ShopManager shopManager;

    public void Start()
    {
        Sprite defalutSprite = Resources.Load<Sprite>("char_paperairplane");

        GameManager.playerData.SetSprite(defalutSprite);

        //씬 로드 후 업데이트 함수가 언제 호출되는지 이해함
        //씬 로드는 동기적으로 씬이 로드되는 동안, 로드되는 씬에서 동작하는 코드들과는 동기적이지만,
        //현재 코드 흐름과는 비동기적으로 작동한다. (정확히는 비동기라기보다, 즉시 실행)
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "InGame")
        {
            playDataViewModel = GameObject.FindGameObjectWithTag("UIManager").GetComponent<PlayDataViewModel>();

            if (playDataViewModel != null)
                playDataViewModel.onDestoryViewModel += UpdatePlayerData;

            EventBus.Publish(EventType.START);
        }

        else if (scene.name == "Main")
        {
            shopManager = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>();

            if (shopManager != null)
                shopManager.updatePlayerData += UpdatePlayerData;
        }
    }

    private void UpdatePlayerData(Data data)
    {
        GameManager.playerData.CopyData(data);
    }

}
