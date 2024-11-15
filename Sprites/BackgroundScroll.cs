using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // Start is called before the first frame update

  //  public float speed;

   

    [SerializeField]
     playercontroles player;

     [SerializeField]
     bool scroll;
    void Start()
    {
      scroll = true;
    }

    
    // Update is called once per frame
    void Update()
    {
     Debug.Log(player.GetMoving());

    if(player.GetDirection() == 0){
        transform.position += new Vector3(-1,0,0)* Time.deltaTime;
    }
    else if(player.GetDirection() == 1){
      transform.position += new Vector3(1,0,0)*Time.deltaTime;
    }
     
       // bck_ren.material.mainTextureOffset += new Vector2(speed* Time.deltaTime,0);
    }
}
