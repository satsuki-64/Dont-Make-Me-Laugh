using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraControl : MonoBehaviour
{
    public Vector3 CameraPositionOffset = default;

    private GameObject playerA;

    [SerializeField]
    private GameObject cameraObject;

    private void Start()
    {
        if (playerA == null) 
        {
            playerA = GameObject.Find("PlayerA");
        }

        if (cameraObject == null) 
        {
            cameraObject = GameObject.Find("Camera");
        }

        InitCameraOffset();
    }

    private void Update()
    {
        UpdateCameraPosition();
    }

    private void InitCameraOffset()
    {
        CameraPositionOffset = cameraObject.transform.position - playerA.transform.position;
    }

    private void UpdateCameraPosition() 
    {
        Vector3 cameraPositionVector3 = new Vector3(playerA.transform.position.x + CameraPositionOffset.x
            ,cameraObject.transform.position.y
            ,cameraObject.transform.position.z);

        cameraObject.transform.position = cameraPositionVector3;
    }
}
