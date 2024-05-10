using System;
using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");

    private readonly float magnitudeThreshold = 0.5f;

    protected override void Start()
    {
        base.Start();
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        Debug.Log(vector.magnitude > magnitudeThreshold);
        animator.SetBool(isWalking, vector.magnitude > magnitudeThreshold);
    }
}

