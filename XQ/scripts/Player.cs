using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator anim;

    private float inputH;
    private float inputV;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
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

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
    }
}