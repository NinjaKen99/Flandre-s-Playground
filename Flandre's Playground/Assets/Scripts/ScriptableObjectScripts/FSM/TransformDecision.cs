using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Decisions/Transform")]
public class TransformDecision : Decision
{
    public BoolVariable destroyerMode;

    public override bool Decide(StateController controller)
    {
        return destroyerMode.Value;
    }
}
