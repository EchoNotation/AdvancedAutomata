using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineFrame : MonoBehaviour
{
    public enum FrameType {
        LIGHT,
        MEDIUM,
        HEAVY,
        FLYING,
    }

    public enum HardpointType {
        WEAPON,
        ARMOR,
        UTILITY,
    }

    private FrameType type;
    //0 : Weapon, 1 : Armor, 2 : Utility
    private int[] numOfHardpoints;
    private int[] numOfAvailableHardpoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void configure(FrameType fType)
    {
        type = fType;
        numOfHardpoints = new int[3];
        numOfAvailableHardpoints = new int[3];

        switch(fType)
        {
            case FrameType.LIGHT:
                break;
            case FrameType.MEDIUM:
                break;
            case FrameType.HEAVY:
                break;
            case FrameType.FLYING:
                break;
            default:
                Debug.Log("Invalid FrameType in MachineFrame-- Did you forgot to add a new case? FrameType: " + fType.ToString());
                break;
        }
    }

    void connectHardpoint(Accessory accessory)
    {

    }
}
