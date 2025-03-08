using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCounter : MonoBehaviour
{
    private int switchCounter = 0;

    public void IncSwitchCounter () { switchCounter++; }
    public void DecSwitchCounter() { switchCounter--; }
    
    // returns the current amount of switches activated for this trap,
    // max is the amount of players
    public int GetSwitchCounter () { return switchCounter; }
}
