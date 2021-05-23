using System;
using System.Collections;
using System.Collections.Generic;
using Chronos;
using Lean.Touch;
using UnityEngine;

[System.Serializable]
public enum LANE
{
    Left,
    Mid,
    Right
}

public class PlayerMovement : MonoBehaviour
{
    private LANE e_Lane = LANE.Mid;
    private float Xcordinate = 0f;
    public float Health = 100f;

    private bool SwipeLeft;
    public float Speed = 14f;
    private bool SwipeRight;
    private Animator animator;
    public float xValue;
    private UnityEngine.CharacterController cc;
    private GameManager GM;
    public Transform Player;
    public GameObject CamLoc;
    private Vector3 desiredPosition;
    public GlobalClock clock;
    private Rigidbody rb;
    private Vector3 movement;
    public Camera camera;
    public GameObject MermiLoc;
    public GameObject MermiPrefab;
    
    float timeElapsed;
    float lerpDuration = 3;

    float startValue=0;
    float endValue=10;
    float valueToLerp;
    private bool death = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        cc = GetComponent<UnityEngine.CharacterController>();

        
    }

    public void SwipeitLeft()
    {
        if (GM.GetState()!=STATE.RUN)
            return;
        if (e_Lane == LANE.Mid)
        {
            Xcordinate = -xValue;
            e_Lane = LANE.Left;
            animator.SetTrigger("Roll");
        }
        else if (e_Lane == LANE.Right)
        {
            Xcordinate = 0;
            e_Lane = LANE.Mid;
            animator.SetTrigger("Roll");
        }
        var x = Xcordinate - transform.position.x;
        var vector = new Vector3(x, 0, 0);

        cc.Move(vector);
    }

    public void Shoot(LeanFinger LF)
    {
        if (GM.GetState()!=STATE.ATTACK)
            return;
        var mermi = Instantiate(MermiPrefab, MermiLoc.transform.position, MermiLoc.transform.rotation);
        mermi.GetComponent<Rigidbody>().AddForce(LF.GetWorldPosition(500) * 10f);
        Destroy(mermi, 5f);
    }
    

    public void SwipeitRight()
    {
        if (GM.GetState()!=STATE.RUN)
            return;
        if (e_Lane == LANE.Mid)
        {
            Xcordinate = xValue;
            e_Lane = LANE.Right;
            animator.SetTrigger("Roll");
        }
        else if (e_Lane == LANE.Left)
        {
            Xcordinate = 0;
            e_Lane = LANE.Mid;
            animator.SetTrigger("Roll");
        }
        var x = Xcordinate - transform.position.x;
        var vector = new Vector3(x, 0, 0);

        cc.Move(vector);
    }

    public void Jump()
    {
        if (GM.GetState()!=STATE.RUN)
        return;
        
        animator.SetTrigger("Jump");
        movement.y = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            clock.localTimeScale = -1f;
     
            
        }
        else
        {
            clock.localTimeScale = 1f;
        }
        
        // Applying Gravity
        if (cc.isGrounded == false)
        {
 
            movement.y += Physics.gravity.y * 0.08f;
 
        }
        var vector = new Vector3(0, movement.y * Time.deltaTime, Time.deltaTime * Speed);
        cc.Move(vector);
    }

    void Death()
    {
        death = true;
        //GM.ChangeState(2);
        animator.SetTrigger("Death");
        //aDestroy(GameObject.Find("Player") , 5f);
        clock.localTimeScale = 0f;
    }


    private void FixedUpdate()
    {
        if (Health <= 0)
        {
            Death();
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        
        if (other.collider.GetComponent<EngelTag>()!=null)
        {
            Debug.Log("CARPTIK");
            Destroy(other.collider.gameObject);
            Health -= 20;
            if (Speed> 21f)
            {
                Speed -= 7f;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<OyunSonuTag>()!=null)
        {
            GM.ChangeState(1);
            animator.SetTrigger("Idle");
            rb.velocity = Vector3.zero;
            
            
        }
    }
}