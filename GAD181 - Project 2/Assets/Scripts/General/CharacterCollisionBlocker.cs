using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionBlocker : MonoBehaviour
{
    public CapsuleCollider characterCollider, characterBlockerCollider;

    void Start()
    {
        Physics.IgnoreCollision(characterCollider, characterBlockerCollider, true);
    }
}
