using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    public Button LevelButton;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    public void GetInLevelScene(int level)
    {
        GameObject.Destroy(this.gameObject);
        SceneManager.LoadScene("UITestScene"+level.ToString());
        //UIControl.GetInstance().SceneFindCanvas();
        UIControl.GetInstance().FindCanvas("PlayUI");
    }
}
