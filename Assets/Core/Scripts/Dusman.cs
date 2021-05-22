using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    private float Health = 100f;
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
    }
    
    public void TakeDamage(int damage)
    {
        Debug.Log("take damage");
        if (damage>=Health)
        {
            Death();
        }
        Health -= damage;
    }


    void Death()
    {
        anim.SetTrigger("Death");
        Destroy(this, 5f);
    }
}
