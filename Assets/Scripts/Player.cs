using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Objects")]
    private Rigidbody2D _body;
    private BoxCollider2D _collider;
    private PlayerAnimation _playerAnimation;

    [Header("Movement")]
    [SerializeField] private float _speed = 2.5f;
    private Vector2 _velocity = new Vector2();

    [Header("Jumping")]
    [SerializeField] private float _jumpForce = 7.5f;
    private bool _isGrounded = false;
    private bool _jumped = false;

    private Vector3 _currentSpriteGameObjectScale;

    void Start()
    {
        GetObjects();
    }

    private void GetObjects()
    {
        _collider = GetComponent<BoxCollider2D>();
        _body = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        Player_Movement();
    }

    #region Player_Movement

    private void Player_Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // GetAxisRaw isn't gradual. Only ever -1, 0, or 1
        float verticalInput = Input.GetAxisRaw("Vertical");

        _playerAnimation.Move(horizontalInput);

        _velocity.x = horizontalInput * _speed;
        _velocity.y = _body.velocity.y;

        Player_Jump();

        _body.velocity = _velocity;

        //Debug.DrawRay(transform.position, Vector2.down * 0.75f, Color.green);
    }


    private void Player_Jump()
    {
        if (CheckGrounded(0)) // is grounded
        {
           if (!_jumped)
            {
                if (Input.GetButtonDown("Jump"))
                {
                        _velocity.y = _jumpForce;
                        _playerAnimation.Jumping(true);
                        _playerAnimation.Falling(false);
                        _jumped = true;
                    

                }
            }
            else
            {
                _playerAnimation.Jumping(false);
                _jumped = false;
                _playerAnimation.Falling(false);
            }

        }
        else // isn't grounded
        {
            if (!_jumped) // player is falling
            {
             //   _playerAnimation.Falling(true);
            }
        }

    }


    /// <summary>
    /// 0 = Velocity check | 1 = Raycast check
    /// </summary>
    private bool CheckGrounded(int version)
    {
        switch (version)
        {
            case 0: // VELOCITY CHECK
                if (_body.velocity.y == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                break;
            case 1: // RAYCAST CHECK
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.75f, 1 << 8); // layers are done using a 32-bit integer bit mask. 32 possible lyers.
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.name);
                    return true;
                }
                else
                {
                    return false;
                }
                break;
            default:
                return false;
                break;
        }
    }

    #endregion





}
