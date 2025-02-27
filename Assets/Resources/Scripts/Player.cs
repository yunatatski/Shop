﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
    private Rigidbody rb;
    private Vector3 startPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public void Move(Vector3 destination)
    {
        transform.position += destination * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If player ends up out of bounds
        if(collision.gameObject.CompareTag("OutOfBounds"))
        {
            //reset their position
            transform.position = startPos;
        }
    }

    public void Reset()
    {
        this.transform.position = startPos;
    }
}
