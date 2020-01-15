using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RockState", menuName = "ScriptableObjects/ControllerMapping", order = 1)]
public class ControllerMapping : ScriptableObject
{
    public string LeftStickHorizontal;
    public string LeftStickVertical;
    public string LeftStickPress;
    public string RightStickHorizontal;
    public string RightStickVertical;
    public string RightStickPress;
    public string LeftTrigger;
    public string RightTrigger;
    public string LeftBumper;
    public string RightBumper;
    public string ButtonBottom;
    public string ButtonRight;
    public string ButtonTop;
    public string ButtonLeft;
    public string DPadUp;
    public string DPadDown;
    public string DPadLeft;
    public string DPadRight;
}
