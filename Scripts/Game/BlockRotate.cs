using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotate : MonoBehaviour
{
    public GameObject block;

    public float maxDiffTime = 0.25f;

    private float diffTime = 0f;

    private void Start()
    {
        diffTime = maxDiffTime;
    }

    private void Update()
    {
        if(diffTime <= 0f)
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                blockRotate(block);
                diffTime = maxDiffTime;
            }
        }
        else
        {
            diffTime -= Time.deltaTime;
        }
    }

    public void blockRotate(GameObject block)
    {
        block.transform.Rotate(Vector3.forward, 45, Space.World);
    }
}
