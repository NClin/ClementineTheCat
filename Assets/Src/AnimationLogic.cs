using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLogic : MonoBehaviour
{
    Animator animator;
    Rigidbody2D catrb;
    SpriteRenderer catSprite;
    CatController catController;
    void Start()
    {
        animator = GetComponent<Animator>();
        catrb = GetComponentInParent<Rigidbody2D>();
        catSprite = GetComponent<SpriteRenderer>();
        catController = GetComponentInParent<CatController>();
    }

    void FixedUpdate()
    {
        if (catController.attacking)
        {
            animator.Play(Animator.StringToHash("cat_paw"));
            return;
        }

        if (catrb.velocity.magnitude > 0.06f)
        {
            animator.Play(Animator.StringToHash("cat_walk"));
        }
        else
        {
            animator.Play(Animator.StringToHash("cat_idle"));
        }

        if (catrb.velocity.x < 0)
        {
            catSprite.flipX = true;
        }
        if (catrb.velocity.x > 0)
        {
            catSprite.flipX = false;
        }
    }
}
