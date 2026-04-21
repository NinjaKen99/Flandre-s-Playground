using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject
{
    // Player Constants
    public float jumpForce;
    public float decayRate;
    public float speed;
    public float maxSpeed;
    public float attackCooldown;
    public float flipDelay;
    public float flickerInterval;
    public float cursorSpeed;

    // Enemy Constants
    public float disappearDelay;

    // Air Fairy Constants
    public float maxYOffset;
    public float airFairyPatrolTime;

    // Ground Fairy Constants
    public float maxXOffset;
    public float groundFairyPatrolTime;
}
