using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Sprite idleFirstFrame;  // Assign this in the Inspector

    public CameraShake cameraShake;
    public float shakeIntensity = 5f;
    public float shakeDuration = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StartCoroutine(PlayDeathAnimationCoroutine());
    //        PlayTPAnimation();
    //    }
    //}
    public void PlayDeathAnimation()
    {
            StartCoroutine(PlayDeathAnimationCoroutine());       
    }

    public void PlayTPAnimation()
    {
        animator.SetTrigger("TP");
    }

    private IEnumerator PlayDeathAnimationCoroutine()
    {
        // Change the sprite to the first frame of the idle animation
        spriteRenderer.sprite = idleFirstFrame;

        // Wait for one frame to ensure the sprite change is rendered
        yield return null;
        cameraShake.ShakeCamera();
        // Trigger the death animation
        animator.SetTrigger("Die");
    }
}
