using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D collission;
    Vector2 newOffset;
    Vector2 newSize;

    void Update()
    {
        float Speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(Speed));

        Vector3 scale = transform.localScale;
        if (Speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (Speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        bool crouch = false;
        animator.SetBool("Crouch", crouch);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouch = true;
            newOffset = collission.offset;
            newOffset.y = .5f;
            collission.offset = newOffset;

            newSize = collission.size;
            newSize.y = 1f;
            collission.size = newSize;
            animator.SetBool("Crouch", crouch);

        }
        else
        {
            crouch = false;
            newOffset = collission.offset;
            newOffset.y = 1f;
            collission.offset = newOffset;

            newSize = collission.size;
            newSize.y = 2f;
            collission.size = newSize;
            animator.SetBool("Crouch", crouch);
        }

        float verticalSpeed = Input.GetAxisRaw("Vertical");
        bool jump = false;
        if (verticalSpeed > 0)
        {
            jump = true;
        }
        else 
        {
            verticalSpeed = 0;
            jump = false;
        }
        animator.SetBool("Jump", jump);

    }
}
