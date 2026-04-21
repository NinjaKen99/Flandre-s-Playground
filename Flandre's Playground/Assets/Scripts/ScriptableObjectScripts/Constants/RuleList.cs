using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuleList", menuName = "ScriptableObjects/RuleList", order = 5)]
public class RuleList : ScriptableObject
{
    // List of BoolVariables
    public BoolVariable playermove;
    public BoolVariable playerjump;
    public BoolVariable playerattack;
    public BoolVariable kedamaHit;
    public BoolVariable kedamaDestroy;
    public BoolVariable aFairyHit;
    public BoolVariable aFairyDestroy;
    public BoolVariable gFairyHit;
    public BoolVariable gFairyDestroy;


}
