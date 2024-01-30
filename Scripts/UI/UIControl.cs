using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    [Header("Canvas挂载物体")]
    public GameObject canvas_Obj;

    [Header("Canvas物体")]
    public Canvas canvas;

    [Header("BackGround物体")]
    public GameObject BackGroundImg;

    private static UIControl instance;
    public static UIControl GetInstance()
    {
        if (instance == null)
        {
            Debug.Log("未找到UI方法实例");
            return null;
        }
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (canvas == null)
        {
            GameObject.Find("Canvas");
        }
        //LiveOnePanel("StartUI");
        
    }

    private void Update()
    {
    }




    public void FindCanvas(string name)
    {
        canvas_Obj = GameObject.Instantiate(Resources.Load<GameObject>("UI/"+name));
        canvas_Obj.transform.SetParent(canvas.transform, false);
    }

    public void SceneFindCanvas()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    //场景中只保留一个给定的UI
    public void LiveOnePanel(string name)
    {
        Transform panelTransform;
        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            panelTransform = canvas.transform.GetChild(i);
            if (panelTransform.name == name || panelTransform.name == "BackGround")
            {
                panelTransform.gameObject.SetActive(true);
                canvas_Obj = panelTransform.gameObject;
            }
            else
            {
                panelTransform.gameObject.SetActive(false);
            }
        }
    }



}
