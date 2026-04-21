using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {
        FlanStateController m = (FlanStateController)controller;
        m.gameObject.GetComponent<Animator>().SetTrigger("attack");
    }
}
