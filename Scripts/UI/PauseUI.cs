using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;

public class PauseUI : MonoBehaviour
{
    public Button BackButton;
    public Button ForwardButton;
    public Button RestartButton;

    public Image BluePlayer;
    public Image RedPlayer;

    private void Start()
    {
        BackButton.onClick.AddListener(BackToStart);
        ForwardButton.onClick.AddListener(Continue);
        RestartButton.onClick.AddListener(ReStartGame);
    }
    
    public void BackToStart()
    {
        SceneManager.LoadScene("UITestScene");
        GameObject.Destroy(this.gameObject);
        UIControl.GetInstance().FindCanvas("StartUI");
    }

    public void Continue()
    {
        GameObject.Destroy(this.gameObject);
        UIControl.GetInstance().LiveOnePanel("PlayUI");
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }
}
