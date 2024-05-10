using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected TopDownController controller;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<TopDownController>();
    }
}

