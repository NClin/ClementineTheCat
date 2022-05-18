using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cockroachLogic : MonoBehaviour
{
    Animator animator;
    Rigidbody2D roachrb;
    Transform destination;
    [SerializeField]
    float speed;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        roachrb = GetComponent<Rigidbody2D>();
        destination = GameObject.Find("bed").transform;
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play(Animator.StringToHash("cockroach"));

        transform.up = destination.position - transform.position;
    }

    private void FixedUpdate()
    {
        roachrb.AddForce(transform.up *  speed);
    }
}
