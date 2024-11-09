using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update

    Camera campos;
    float camx,camy;

    
    void Start()
    {
        campos = GetComponent<Camera>();
        camx = transform.position.x;
        camy = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        camx+=1;
    Debug.Log(camx);
    }
}
