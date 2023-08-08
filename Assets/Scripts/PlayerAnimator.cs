using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    const string IS_WALKING = "IsWalking"; // This is referencing a Parameter that has been set up in the Animator window. Unfortunately, Unity only lets you reference this as a string in code. So we're using a const here for some added protection in case we make a typo in the code below.
    [SerializeField] Player player;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
