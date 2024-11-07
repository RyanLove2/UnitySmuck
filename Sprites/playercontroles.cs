using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.TextCore;

public class playercontroles : MonoBehaviour
{
    // Start is called before the first frame update
    //Input.GetButtonDown
    private bool attack, moving;
    private float speed;
    [SerializeField]
    private SpriteRenderer player;
   

     Animator ani;

    
    void Start()
    {
        speed = 0.0f;
        attack = false;
        ani = GetComponent<Animator>();
    }

    void Shooting(){

         if(Input.GetButtonDown("Fire1")){
         
           attack = true;
        }
        else if(Input.GetButtonUp("Fire1")){
            attack = false;
            

        }

        if (attack == true){
            Debug.Log("Bang Bang");
            ani.SetBool("prim_att",true);

        }
        else{
            ani.SetBool("prim_att",false);
        }


    }

    void Controles(){

        Shooting();
        
        if (Input.GetKey("left")){
           // Debug.Log("playerface Left:"+ player.flipX );
            Debug.Log("Moving:"+ moving );
            moving = true;
            player.flipX = true;
        
        }
        else if(Input.GetKey("right")){
           // Debug.Log("playerface Left:"+ player.flipX );
            Debug.Log("Moving:"+ moving );
            moving = true;
            player.flipX = false;
         
           

        }
        else{
            // play idle animation 
            moving = false;
             ani.SetBool("moving",false);
        
        }
        // need to player animation when presing left or right
       if (moving == true){
            ani.SetBool("ani_idle",false);
             ani.SetBool("moving",true);
       }
       else{
            ani.SetBool("ani_idle",false);
             
            ani.SetBool("moving",false);
       }

    }

    // Update is called once per frame
    void Update()
    {
      Controles();
    }
}
