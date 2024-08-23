using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public float YPosition;
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();
            animator.SetBool("Dead", true);
        }
    }

    private void Update()
    {
        Vector2 position = transform.position;

        if (position.y > YPosition)
        {
            Debug.Log("hi");
            Destroy(gameObject);
        }
    }
}
