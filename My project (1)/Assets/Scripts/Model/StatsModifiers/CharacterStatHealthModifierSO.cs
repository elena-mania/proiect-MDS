using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatHealthModifierSO : CharacterStatModifier
{
    public override void AffectCharacter(GameObject character, float val)
    {
        Health health = character.GetComponent<Health>();
        if(health != null) 
        {
            health.AddHealth((int) val);
        }
    }
}