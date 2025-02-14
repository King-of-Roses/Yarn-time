using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    private float _currentVelocity;
    private Rigidbody2D _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _rigidbody.velocity = new Vector2(_currentVelocity, _rigidbody.velocity.y);
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        _currentVelocity = ctx.ReadValue<float>() * speed;
    }
}
