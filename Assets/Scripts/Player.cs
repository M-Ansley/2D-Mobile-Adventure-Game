using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D _collider;
    private Rigidbody2D _body;
    [SerializeField] private float _speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // GetAxisRaw isn't gradual. Only ever -1, 0, or 1
        float verticalInput = Input.GetAxisRaw("Vertical");
        _body.velocity = new Vector2(horizontalInput, _body.velocity.y);

    }
}
