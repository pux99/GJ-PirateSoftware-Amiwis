using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Sprite idleFirstFrame;  // Assign this in the Inspector

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayDeathAnimation()
    {
            StartCoroutine(PlayDeathAnimationCoroutine());       
    }

    private IEnumerator PlayDeathAnimationCoroutine()
    {
        // Change the sprite to the first frame of the idle animation
        spriteRenderer.sprite = idleFirstFrame;

        // Wait for one frame to ensure the sprite change is rendered
        yield return null;

        // Trigger the death animation
        animator.SetTrigger("Die");
    }
}
