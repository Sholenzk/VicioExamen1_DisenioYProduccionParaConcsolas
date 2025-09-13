using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    private float moveSpeed = 2.3f;
    private Vector2 moveDir;
    
    private Rigidbody2D rb;
    [SerializeField] private Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.up = target.position - transform.position;
            Vector3 dir = (target.position - transform.position).normalized;
            moveDir = dir;
        }
    }

    void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDir.x, moveDir.y) * moveSpeed;
        }
    }
}
