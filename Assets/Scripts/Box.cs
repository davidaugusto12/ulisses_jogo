using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public ContactFilter2D groundContactFilter;
    public float groundCheckDistance = 0.1f;
    public bool IsGrounded { get; private set; }

    private Collider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        boxCollider.Cast(Vector2.down, groundContactFilter, hits, groundCheckDistance);

        IsGrounded = hits.Count > 0;
    }
}



