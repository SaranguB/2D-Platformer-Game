
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public BoxCollider2D collission;
    public float playerSpeed;
    private Rigidbody2D rb2D;
    public float jump;
    public List<GameObject> hearts;
    public GameOverController gameOverController;
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;
    private Camera mainCamera;
    bool isGround;

   

    private bool canMove = false;
    private int health = 3;
    Vector2 startingPosition;
    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

    }

    public void Start()
    {

        startingPosition = transform.position;
        boxColInitSize = collission.size;
        boxColInitOffset = collission.offset;
        mainCamera = Camera.main;

    }

    public void startPosiiton()
    {
        transform.position = startingPosition;
    }

    private void Stop()
    {
        animator.speed = 0f;
    }
    void Update()
    {
        if (isGround)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayMovementAnimation(horizontal, vertical);
        MoveCharecter(horizontal, vertical);
        //CrouchAnimation();


    }
    private void PlayMovementAnimation(float horizontal, float vertical)
    {

        if (canMove)
        {
            if (vertical <= 0)
            {
                animator.SetFloat("Speed", Mathf.Abs(horizontal));
            }

            else
            {
                animator.SetFloat("Speed", 0);
            }

        }
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


        if (vertical > 0)
        {
            animator.SetBool("Jump", true);

        }
        else
        {

            animator.SetBool("Jump", false);
        }

    }

    public void ResetCollider()
    {

        collission.size = boxColInitSize;
        collission.offset = boxColInitOffset;
    }
    private void MoveCharecter(float horizontal, float vertical)
    {

        Vector3 position = transform.position;
        position.x += horizontal * playerSpeed * Time.deltaTime;
        transform.position = position;


        if (vertical > 0 && isGround)
        {
            rb2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);

           // Debug.Log("hi");
            Vector2 newSize = collission.size;
            newSize.y = 1f;
            collission.size = newSize;

            Vector2 newOffset = collission.offset;
            newOffset.y = 1.5f;
            collission.offset = newOffset;
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
    /*private void CrouchAnimation()
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
    }*/

    private void OnCollisionStay2D(Collision2D other)
    {
       

        if (other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("MovingPlatform"))
        {
            if (Vector2.Dot(other.contacts[0].normal, Vector2.up) > 0.5f)
            {
                
                isGround = true;
            }
            else
            {
                //Debug.Log("ground is false");

                isGround = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ResetCollider();
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = other.transform;

        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGround = false;
        }

        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = null;

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
            collission.isTrigger = true;
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {


        rb2D.constraints = RigidbodyConstraints2D.FreezePosition;
        gameOverController.PlayerDied();
        this.enabled = false;

    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger("Die");
    }

   public void JumpSound()
    {
        SoundManager.Instance.Play(Sounds.PLAYER_JUMP);
    }


}
