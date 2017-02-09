using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator anim;
    public Rigidbody rbody;

    private float inputH;
    private float inputV;
    private bool run;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        run = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("space"))
        {
            anim.Play("WAIT04", -1, 0f);
        }
        if (Input.GetKeyDown("1"))
        {
            anim.Play("WAIT01", -1, 0f);
        }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("WAIT02", -1, 0f);
        }
        if (Input.GetKeyDown("up"))
        {
            anim.Play("WALK00_F", -1, 0f);
        }
        if (Input.GetKeyDown("left"))
        {
            anim.Play("WALK00_L", -1, 0f);
        }
        if (Input.GetMouseButtonDown(0)) {

            int n = Random.Range(0, 2);

            if (n == 0)
            {

                anim.Play("DAMAGED00", -1, 0f);
            }
            else {
                anim.Play("DAMAGED01", -1, 0f);
            }

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("run", run);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        if(moveZ <= 0f)
        {
            moveX = 0f;
        }
        else if(run)
        {
            moveX *= 3f;
            moveZ *= 3f;
        }

        rbody.velocity = new Vector3(moveX, 0f, moveZ);
    }
}