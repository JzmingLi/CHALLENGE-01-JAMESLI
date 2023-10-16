using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsList : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void MouseTouch()
    {
        animator.SetBool("Touched", true);
    }
    
    public void MouseLeave()
    {
        animator.SetBool("Touched", false);
    }

}
