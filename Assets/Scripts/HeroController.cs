using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 350f;
    private bool grounded;
    private Rigidbody2D _rgd;
    private bool started;
    private Animator _animator;
    private bool jumping;

    private void Awake()
    {
        _rgd = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        grounded = true;
        //started = true;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (started && grounded)
            {
                _animator.SetTrigger("jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                _animator.SetBool("GameStarted", true);
                started = true;
            }
        }

        _animator.SetBool("grounded", grounded);

    }

    private void FixedUpdate()
    {
        if (started)
        {
            _rgd.velocity = new Vector2(speed, _rgd.velocity.y);
        }
        if (jumping)
        {
            _rgd.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
