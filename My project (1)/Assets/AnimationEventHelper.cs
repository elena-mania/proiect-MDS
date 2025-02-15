using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AnimationEventHelper : MonoBehaviour
{

    public UnityEvent OnAnimationEventTriggered, OnAttackPerformed ;
    public void TriggerEvenet()
    {
        OnAnimationEventTriggered?.Invoke();
    }

    public void TriggerAttack()
    {
        OnAttackPerformed?.Invoke();
    }
}
