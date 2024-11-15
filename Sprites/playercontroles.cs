using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.TextCore;

public class playercontroles : MonoBehaviour
{
    // Start is called before the first frame update
    //Input.GetButtonDown
    private bool attack,moving, movingleft;
    
    private float speedx,speedy, bck_speed;
    [SerializeField]
    private SpriteRenderer player;
   
    [SerializeField]
    private Renderer bck_ren;

     Transform trans;
     Vector3 pos;
     Animator ani;

    public enum dir{
        right,
        left,

        shooting,
        idle
    }
    int playerdir;

    void Start()
    {
        speedx = 2.5f;
        bck_speed = 0.09f;
        attack = false;
        movingleft = false;
        ani = GetComponent<Animator>();
        //trans = transform;
        trans = GetComponent<Transform>();
        pos = transform.position;
    }

    void SetMoving(bool val){

        moving = val;
    }

    void SetMovingLeft(bool val){
        movingleft = val;
    }

  
    public bool GetMoving(){
        return moving;
    }

    public int GetDirection(){
        return playerdir;
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
    float GetSpeed(){
        return speedx;
    }

    void PlayerBoundry(){
        if(transform.position.x <= -4602.77f ){
            transform.position += new Vector3(speedx,speedy,0) * Time.deltaTime; 

        }
        else if(transform.position.x >= -4592.91f){//-4584.08f
            transform.position += new Vector3(-speedx,speedy,0) * Time.deltaTime; 
        }

        if(transform.position.y >= 12364.77f){
            transform.position += new Vector3(0,speedy-2,0) * Time.deltaTime; 
        }
        else if(transform.position.y <= 12355.27f){
            transform.position += new Vector3(0,speedy+2,0) * Time.deltaTime; 
        }
    }
    
    void Controles(){

        Shooting();
        Debug.Log(transform.position);

        if(Input.GetKey("up") && Input.GetKey("right")){
            transform.position += new Vector3(speedx,speedy+2,0) * Time.deltaTime; 
            SetMoving(true);
            player.flipX = false;
            playerdir = (int)dir.right;
            
        }
        else if(Input.GetKey("down") && Input.GetKey("left")){
            transform.position += new Vector3(-speedx,speedy-2,0) * Time.deltaTime; 
            SetMoving(true);
           // SetMovingLeft(true);
           playerdir = (int)dir.left;
            player.flipX = true;
        }
        else if(Input.GetKey("down") && Input.GetKey("right")){
            transform.position += new Vector3(+speedx,speedy-2,0) * Time.deltaTime; 
            SetMoving(true);
            player.flipX = false;
            playerdir = (int)dir.right;
        }
        else if(Input.GetKey("up") && Input.GetKey("left")){
            transform.position += new Vector3(-speedx,speedy+2,0) * Time.deltaTime; 
            SetMoving(true);
           // SetMovingLeft(true);
            player.flipX = true;
            playerdir = (int)dir.left;
            
        }
        else if (Input.GetKey("left")){
           // Debug.Log("playerface Left:"+ player.flipX );
           // Debug.Log("Moving:"+ moving );
            
            SetMoving(true);
            //SetMovingLeft(true);
            playerdir = (int)dir.left;
            player.flipX = true;
            transform.position += new Vector3(-speedx,0,0)* Time.deltaTime;
        }
        else if(Input.GetKey("right")){
           // Debug.Log("playerface Left:"+ player.flipX );
          //  Debug.Log("Moving:"+ moving );
            SetMoving(true);
            player.flipX = false;
             transform.position += new Vector3(speedx,0,0)* Time.deltaTime;
             playerdir = (int)dir.right;
           

        }
        else if(Input.GetKey("up")){
            transform.position += new Vector3(0,speedy+2,0) * Time.deltaTime;
           // SetMoving(true);
        }
        else if(Input.GetKey("down")){
            transform.position += new Vector3(0,speedy-2,0) * Time.deltaTime;
           // SetMoving(true);
        }
        else{
            // play idle animation 
            SetMoving(false);
            SetMovingLeft(false);
             ani.SetBool("moving",false);
        
        }


        // need to player animation when presing left or right
       if (moving == true){
            ani.SetBool("ani_idle",false);
            ani.SetBool("moving",true);
          //  ani.SetBool("movingleft",true);
            if(Input.GetKey("right")){
                bck_ren.material.mainTextureOffset += new Vector2(bck_speed* Time.deltaTime,0);
            }
            else if(Input.GetKey("left")){
                bck_ren.material.mainTextureOffset += new Vector2(1-bck_speed* Time.deltaTime,0);
            }
            //bck_ren.material.mainTextureOffset += new Vector2(speedx* Time.deltaTime-1,0);
       }
       else{
            ani.SetBool("ani_idle",false);
            ani.SetBool("moving",false);
            playerdir = (int)dir.idle;
         
            
       }
          PlayerBoundry();
    }

    // Update is called once per frame
    void Update()
    {
      Controles();
    
    }
}
