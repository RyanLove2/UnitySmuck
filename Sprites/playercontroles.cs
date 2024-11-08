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
    private float speedx,speedy;
    [SerializeField]
    private SpriteRenderer player;
   
  
     Transform trans;
     Vector3 pos;
     Animator ani;

    
    void Start()
    {
        speedx = 1.0f;

        attack = false;
        ani = GetComponent<Animator>();
        //trans = transform;
        trans = GetComponent<Transform>();
        pos = transform.position;
    }

    void SetMoving(bool val){

        moving = val;
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
        

        if(Input.GetKey("up") && Input.GetKey("right")){
            transform.position += new Vector3(speedx,speedy+1,0) * Time.deltaTime; 
            SetMoving(true);
            player.flipX = false;
        }
        else if(Input.GetKey("down") && Input.GetKey("left")){
            transform.position += new Vector3(-speedx,speedy-1,0) * Time.deltaTime; 
            SetMoving(true);
            player.flipX = true;
        }
        else if(Input.GetKey("down") && Input.GetKey("right")){
            transform.position += new Vector3(+speedx,speedy-1,0) * Time.deltaTime; 
            SetMoving(true);
            player.flipX = false;
        }
        else if(Input.GetKey("up") && Input.GetKey("left")){
            transform.position += new Vector3(-speedx,speedy+1,0) * Time.deltaTime; 
            SetMoving(true);
            player.flipX = true;
        }
        else if (Input.GetKey("left")){
           // Debug.Log("playerface Left:"+ player.flipX );
            Debug.Log("Moving:"+ moving );
            
            SetMoving(true);
            player.flipX = true;
            transform.position += new Vector3(-speedx,0,0)* Time.deltaTime;
        }
        else if(Input.GetKey("right")){
           // Debug.Log("playerface Left:"+ player.flipX );
            Debug.Log("Moving:"+ moving );
            SetMoving(true);
            player.flipX = false;
             transform.position += new Vector3(speedx,0,0)* Time.deltaTime;
           

        }
        else if(Input.GetKey("up")){
            transform.position += new Vector3(0,speedy+1,0) * Time.deltaTime;
           SetMoving(true);
        }
        else if(Input.GetKey("down")){
            transform.position += new Vector3(0,speedy-1,0) * Time.deltaTime;
            SetMoving(true);
        }
        else{
            // play idle animation 
            SetMoving(false);
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
