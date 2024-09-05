using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public float YPosition;
    public Animator animator;

    public Collider2D keyCollider;
    public float speed;

    private bool isKeyTouched = false;
    private void Awake()
    {


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        { 
            isKeyTouched = true;
            SoundManager.Instance.Play(Sounds.KEY_SOUND);
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();

        }
    }


    private void Update()
    {
        if (animator != null)
        {
            animator.enabled = false; 
        }


        if (isKeyTouched == true)
        {
           

            Vector3 position = transform.position;
            position.y += speed * Time.deltaTime;
            transform.position = position;

            if (position.y > YPosition)
            {
                //Debug.Log("hi");
                Destroy(gameObject);
            }
        }
    }
}
