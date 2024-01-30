using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public enum BlockControlState 
{
    EMPTY,
    READY,
    INIT,
    CHECKED,
    PUT,
}

public enum BlockType 
{
    EMPTY,
    Normal1, // 基础四种物体
    Normal2, Normal3, Normal4,Normal5, // 四种功能性物体
    Random1  // 随机物体
}

public enum BasicBlockType 
{
    Basic1,
    Basic2,
    Basic3,
    Basic4
}

public class BlockControl : MonoBehaviour
{
    //当前PlayerB所选择的物体类型
    [Header("当前PlayerB所选择的物体类型")]
    public BlockType CurrrentBlockType = BlockType.EMPTY;

    [Header("当前功能块控制状态")]
    public BlockControlState ControlState = BlockControlState.EMPTY;

    [HideInInspector]
    //可防止功能块物体的Layer
    public string LayerName = "ActiveGround";

    public const float ZConstPosition = -1.2f;

    public float maxDiffTime = 0.25f;
    private float diffTime = 0f;


    private GameObject currentBlockObject = null;
    private GameObject BlockObjectParent = null;

    private void Start()
    {
        diffTime = maxDiffTime;

        if (BlockObjectParent == null) 
        {
            BlockObjectParent = GameObject.Find("BlockObjectParent");
        }
    }

    private void Update()
    {
        if (ControlState == BlockControlState.READY) 
        {
            ControlState = BlockControlState.INIT;
        }

        BlockStateControl(ref ControlState, ref CurrrentBlockType);
    }

    private void BlockStateControl(ref BlockControlState blockState,ref BlockType blockType) 
    {
        switch (blockState) 
        {
            // 完成Block物体的加载
            case BlockControlState.INIT:
                currentBlockObject = LoadBlockGameObjectFromType(blockType);
                blockState = BlockControlState.CHECKED;
                break;

            // 将Block放置到合适的位置
            case BlockControlState.CHECKED:

                // 执行Block旋转
                if (Input.GetKeyDown(KeyCode.Space)) 
                {
                    RotateBlockObject(currentBlockObject);
                }

                // 执行Block跟随鼠标移动
                PositionWithPointer(currentBlockObject);

                // 放置当前鼠标控制的Block物体
                if (Input.GetMouseButtonDown(0)) 
                {
                    CurrrentBlockType = BlockType.EMPTY;
                    blockState = BlockControlState.EMPTY;
                    currentBlockObject = null;
                }

                break;
        }
    }

    private GameObject LoadBlockGameObjectFromType(BlockType blockType)
    {
        GameObject initObject = null;

        if (blockType != BlockType.EMPTY)
        {

            #region 根据类型选择生成物体
            if (blockType == BlockType.Normal1)
            {
                int randomNumber = 0;
                randomNumber = Random.Range(0, 4);

                switch (randomNumber)
                {
                    case 0:
                        initObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("BasicBlock1"));
                        break;

                    case 1:
                        initObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("BasicBlock2"));
                        break;

                    case 2:
                        initObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("BasicBlock3"));
                        break;

                    case 3:
                        initObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("BasicBlock4"));
                        break;
                }
            }

            if (blockType == BlockType.Normal2 || blockType == BlockType.Normal3 ||
                blockType == BlockType.Normal4 || blockType == BlockType.Normal5) 
            {
                // 箭头
                if (blockType == BlockType.Normal2)
                {
                    initObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("ArrowObject"));
                    initObject.AddComponent<FunctionBlockControl>();
                    initObject.GetComponent<FunctionBlockControl>().FunctionBlockTypeInfo = FunctionBlockType.ARROW;
                }

                // 弹射球
                if (blockType == BlockType.Normal3)
                {
                    initObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("PowerballObject"));
                    initObject.AddComponent<FunctionBlockControl>();
                    initObject.GetComponent<FunctionBlockControl>().FunctionBlockTypeInfo = FunctionBlockType.POWERBALL;
                }

                // 螺旋桨
                if (blockType == BlockType.Normal4)
                {
                    initObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("PropellerObject"));
                    initObject.AddComponent<FunctionBlockControl>();
                    initObject.GetComponent<FunctionBlockControl>().FunctionBlockTypeInfo = FunctionBlockType.PROPELLER;
                }

                // Heart物体
                if (blockType == BlockType.Normal5)
                {
                    initObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("HeartObject"));
                    initObject.AddComponent<FunctionBlockControl>();
                    initObject.GetComponent<FunctionBlockControl>().FunctionBlockTypeInfo = FunctionBlockType.HEART;
                }
            }
            
            if (blockType == BlockType.Random1)
            {
                initObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("RandomBlock1"));
            }
            #endregion

            initObject.transform.SetParent(BlockObjectParent.transform);
            initObject.transform.position = Vector3.zero;
            return initObject;   
        }
        return null;
    }

    private void PositionWithPointer(GameObject targetBlockObject) 
    {
        float x = 0;
        float y = 0;
        float z = -5;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,100,LayerMask.GetMask(LayerName))) 
        {
            Vector3 hitPoint = hit.point;
            Debug.Log("当前的位置点为：" + hitPoint);

            Debug.Log(hit.collider.gameObject.name);
            x = hitPoint.x;
            y = hitPoint.y;

            targetBlockObject.transform.position = new Vector3(x, y, ZConstPosition);

            return;
        }

        Debug.LogWarning("目标功能块的位置同步错误");
    }
    
    private void RotateBlockObject(GameObject block) 
    {
        block.transform.Rotate(Vector3.forward, 45, Space.World);
    }
}
