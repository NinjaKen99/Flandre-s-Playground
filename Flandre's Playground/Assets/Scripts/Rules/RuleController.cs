using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RuleController : MonoBehaviour
{
    public RuleTypes ruleType; // Inspector set types
    public RuleList ruleList; // List of BoolVariables
    public BoolVariable destroyerMode;

    // Event to kill player
    public UnityEvent playerDeath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        // If Destroy is enabled
        if (destroyerMode.Value)
        {
            // Act based on rule
            switch (ruleType)
            {
                case RuleTypes.Traps:
                    playerDeath.Invoke();
                    break;
                case RuleTypes.FlanCantMove:
                    ruleList.playermove.SetValue(false);
                    break;
                case RuleTypes.FlanCantJump:
                    ruleList.playerjump.SetValue(false);
                    break;
                case RuleTypes.FlanCantAttack:
                    ruleList.playerattack.SetValue(false);
                    break;
                case RuleTypes.KedamaCantDie:
                    ruleList.kedamaHit.SetValue(false);
                    break;
                case RuleTypes.KedamaCantDestroy:
                    ruleList.kedamaDestroy.SetValue(false);
                    break;
                case RuleTypes.AFairyCantDie:
                    ruleList.aFairyHit.SetValue(false);
                    break;
                case RuleTypes.AFairyCantDestroy:
                    ruleList.aFairyDestroy.SetValue(false);
                    break;
                case RuleTypes.GFairyCantDie:
                    ruleList.gFairyHit.SetValue(false);
                    break;
                case RuleTypes.GFairyCantDestroy:
                    ruleList.gFairyDestroy.SetValue(false);
                    break;
            }
            // Destroy rule object afterwards
            Destroy(this.gameObject);
        }


    }
}
