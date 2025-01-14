using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 Pointerposition { get; set; }

    public SpriteRenderer characterRenderer, weaponRenderer;

    public Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;

    public Transform circleOrigin;
    public float radius;
    private void Update()
    {
        Vector2 direction = (Pointerposition - (Vector2)transform.position).normalized;
        transform.right = direction;
        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }    
        else if(direction.x > 0) 
        {
            scale.y = 1;
        }

        transform.localScale = scale;

        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 100) 
        {
            weaponRenderer.sortingOrder = 0;

        }
        else 
            {
            weaponRenderer.sortingOrder = 4;

            }

        
    }

    public void Attack()
    {
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void DetectColliders()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius)) 
        {
            //Debug.Log(collider.name);
            Healthv2 health;
            if (health = collider.GetComponent<Healthv2>())
            {
                health.GetHit(1, transform.parent.gameObject);   
            }
        }
    }
}
