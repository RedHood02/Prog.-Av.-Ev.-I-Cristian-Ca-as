using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;
public class PlayerController : MonoBehaviour
{

    [SerializeField] Vector2 input;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float playerJump, playerSpeed;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] bool canJump;

    [SerializeField] StudioEventEmitter jumpingEmitter;
    [SerializeField] StudioEventEmitter stepEmitter;
    [SerializeField] StudioEventEmitter thudEmitter;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stepEmitter.EventInstance.setVolume(0.25f);
    }

    private void OnEnable()
    {
        stepEmitter.Stop();
        InputManager.OnPlayerMovement += Move;
        InputManager.OnPlayerStop += StopSFX;
        InputManager.OnPlayerJump += Jumping;
    }

    void Move(Vector2 input)
    {
        this.input = input;
        if (!stepEmitter.IsPlaying())
        {
            stepEmitter.Play();
        }
    }

    void StopSFX()
    {
        stepEmitter.Stop();
    }


    void Jumping()
    {
        if (canJump)
        {
            jumpingEmitter.Play();
            rb.AddForce(transform.up * playerJump, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector3(input.x, input.y);
        rb.position += playerSpeed * Time.fixedDeltaTime * velocity;

        Raycast();
    }

    private void OnDisable()
    {
        InputManager.OnPlayerMovement -= Move;
        InputManager.OnPlayerJump -= Jumping;
        InputManager.OnPlayerStop -= StopSFX;
    }

    void Raycast()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, 2f, whatIsGround))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.up * 1.25f);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(!thudEmitter.IsPlaying())
            {
                thudEmitter.Play();
            }
        }
    }
}
