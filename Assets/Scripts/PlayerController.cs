using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public BoxCollider2D collission;
    public float speed;
    private Rigidbody2D rb2D;
    public float jump;
    public List<GameObject> hearts;
    public GameOverController gameOverController;
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;
    private Camera mainCamera;
    bool isGround;

    private int health = 3;

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

    }

    public void Start()
    {


        boxColInitSize = collission.size;
        boxColInitOffset = collission.offset;
        mainCamera = Camera.main;

    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayMovementAnimation(horizontal, vertical);
        MoveCharecter(horizontal, vertical);
        CrouchAnimation();

    }
    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;


        if (vertical > 0 && isGround)
        {
            animator.SetBool("Jump", true);

        }
        else
        {

            animator.SetBool("Jump", false);
        }


    }

    private void MoveCharecter(float horizontal, float vertical)
    {

        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;




        if (vertical > 0 && isGround)
        {
            rb2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            isGround = false;
        }

    }

    public void PlaySound()
    {
        if (isGround)
        {
            SoundManager.Instance.Play(Sounds.PLAYER_MOVE);

        }
    }
    private void CrouchAnimation()
    {
        bool crouch = false;
        animator.SetBool("Crouch", crouch);
        Vector2 newOffset;
        Vector2 newSize;
        if (isGround)
        {


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
                newOffset.y = boxColInitOffset.y;
                collission.offset = newOffset;

                newSize = collission.size;
                newSize.y = boxColInitSize.y;
                collission.size = newSize;
                animator.SetBool("Crouch", crouch);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGround = false;
        }
    }
    public void PickUpKey()
    {
        scoreController.IncreaseScore(10);
    }

    public void KillPlayer()
    {
        if (health > 0)
        {
            SoundManager.Instance.Play(Sounds.PAIN);
            health--;
            hearts[health].SetActive(false);
        }
        if (health == 0)
        {
            PlayDeathAnimation();
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        //  Debug.Log("hi");
        mainCamera.transform.parent = null;
        rb2D.constraints = RigidbodyConstraints2D.FreezePosition;
        gameOverController.PlayerDied();
        this.enabled = false;
        //ReloadLevel();
    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger("Die");
    }




}
