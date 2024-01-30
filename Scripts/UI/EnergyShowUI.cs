using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyShowUI : MonoBehaviour
{
    private EnergySystem energySystem;

    public Text basicText1;
    public Text basicText2;
    public Text basicText3;
    public Text basicText4;
    public Text randomText1;

    public Text EnergyText;

    private void Start()
    {
        if (energySystem == null) 
        {
            energySystem = GameObject.Find("GameManager").GetComponent<EnergySystem>();
        }
    }

    private void Update()
    {
        basicText1.text = energySystem.BasicBlock1_Energy.ToString();
        basicText2.text = energySystem.BasicBlock2_Energy.ToString();
        basicText3.text = energySystem.BasicBlock3_Energy.ToString();
        basicText4.text = energySystem.BasicBlock4_Energy.ToString();
        randomText1.text = energySystem.BasicBlock5_Energy.ToString();

        EnergyText.text = energySystem.EnergyNumber.ToString();
    }

}
