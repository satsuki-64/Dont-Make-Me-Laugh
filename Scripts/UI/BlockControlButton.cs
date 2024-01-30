using UnityEngine;
using UnityEngine.Audio;

public class BlockControlButton : MonoBehaviour
{
    //public 
    private BlockControl blockControl = default;
    private EnergySystem energySystem = null;

    private void Start()
    {
        if (blockControl == null)
        {
            blockControl = GameObject.Find("GameManager").GetComponent<BlockControl>();
        }

        if (energySystem == null) 
        {
            energySystem = GameObject.Find("GameManager").GetComponent<EnergySystem>();
        }
    }

    public void BasicButton1() 
    {
        if (energySystem.EnergyNumber >= energySystem.BasicBlock1_Energy)  
        {
            if (blockControl.ControlState == BlockControlState.EMPTY)
            {
                
                energySystem.EnergyNumber -= energySystem.BasicBlock1_Energy;
                blockControl.ControlState = BlockControlState.READY;
                blockControl.CurrrentBlockType = BlockType.Normal1;
            }
        }
        
    }

    public void BasicButton2()
    {
        if (energySystem.EnergyNumber >= energySystem.BasicBlock2_Energy) 
        {
            if (blockControl.ControlState == BlockControlState.EMPTY)
            {
                
                energySystem.EnergyNumber -= energySystem.BasicBlock2_Energy;
                blockControl.ControlState = BlockControlState.READY;
                blockControl.CurrrentBlockType = BlockType.Normal2;
            }
        }
    }

    public void BasicButton3()
    {
        if (energySystem.EnergyNumber >= energySystem.BasicBlock3_Energy) 
        {
            if (blockControl.ControlState == BlockControlState.EMPTY)
            {
                
                energySystem.EnergyNumber -= energySystem.BasicBlock3_Energy;
                blockControl.ControlState = BlockControlState.READY;
                blockControl.CurrrentBlockType = BlockType.Normal3;
            }
        }
    }

    public void BasicButton4()
    {
        if (energySystem.EnergyNumber >= energySystem.BasicBlock4_Energy) 
        {
            if (blockControl.ControlState == BlockControlState.EMPTY)
            {
                
                energySystem.EnergyNumber -= energySystem.BasicBlock4_Energy;
                blockControl.ControlState = BlockControlState.READY;
                blockControl.CurrrentBlockType = BlockType.Normal4;
            }
        }
    }

    public void Random1Button1()
    {
        if (energySystem.EnergyNumber >= energySystem.BasicBlock5_Energy)
        {
            if (blockControl.ControlState == BlockControlState.EMPTY)
            {
                
                energySystem.EnergyNumber -= energySystem.BasicBlock5_Energy;
                blockControl.ControlState = BlockControlState.READY;
                blockControl.CurrrentBlockType = BlockType.Normal5;
            }
        }
    }
}
