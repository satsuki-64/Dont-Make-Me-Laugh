using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayPanel : MonoBehaviour
{
    public Image BluePlayer;
    public Image RedPlayer;

    private void Start()
    {
        BluePlayer.fillAmount = 0f;
        RedPlayer.fillAmount = 0f;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    
    public void WinGame(bool winner)
    {
        Destroy(this.gameObject);
        if (winner)
        {
            UIControl.GetInstance().FindCanvas("WinRedUI");
        }
        else
        {
            UIControl.GetInstance().FindCanvas("WinBlueUI");
        }
    }

    public void PauseGame()
    {
        this.gameObject.SetActive(false);
        //GameObject.Destroy(this.gameObject);
        UIControl.GetInstance().FindCanvas("PauseUI");
    }
}
