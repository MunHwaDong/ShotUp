using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnMainBehaviour : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ReturnMain);
    }

    private void ReturnMain()
    {
        SceneManager.LoadScene("Main");
    }
}
