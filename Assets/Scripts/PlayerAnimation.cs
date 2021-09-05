using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Objects")]
    private Animator _animator;
    private GameObject _spriteGameObject;

    private Vector3 _currentSpriteGameObjectScale;

    void Start()
    {
        GetObjects();
        SetDefaults();
    }

    private void GetObjects()
    {
        _spriteGameObject = transform.Find("Sprite").gameObject;
        _animator = _spriteGameObject.GetComponent<Animator>();
    }

    private void SetDefaults()
    {
        _currentSpriteGameObjectScale = _spriteGameObject.transform.localScale;
    }

    public void Move(float horizontalInput)
    {
        _animator.SetFloat("Velocity", Mathf.Abs(horizontalInput));
        SetSpriteObjectDirection(horizontalInput);
    }

    private void SetSpriteObjectDirection(float horizontalInput)
    {
        _currentSpriteGameObjectScale = _spriteGameObject.transform.localScale;

        if (horizontalInput > 0)
        {
            _currentSpriteGameObjectScale.x = 1;
            _spriteGameObject.transform.localScale = _currentSpriteGameObjectScale;
        }
        else if (horizontalInput < 0)
        {
            _currentSpriteGameObjectScale.x = -1;
            _spriteGameObject.transform.localScale = _currentSpriteGameObjectScale;
        }
    }

    public void Jumping(bool jumping)
    {
        _animator.SetBool("Jumping", jumping);
    }

    public void Falling(bool falling)
    {
        _animator.SetBool("Falling", falling);
    }

}
