using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 1f;
    public bool keepOnScreen = true;

    [Header("Set Dynamically")]
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;

    void Awake(){
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight*Camera.main.aspect;
    }
    

     
    void LateUpdate(){ // this detects where on the screen the objects are
        Vector3 pos = transform.position;
        isOnScreen = true;
        
        if(pos.x > camWidth - radius){
            pos.x = camWidth - radius;
            isOnScreen = false;
        }

        if(pos.x < -camWidth + radius){
            pos.x = -camWidth + radius;
            isOnScreen = false;
        }

        if(pos.y > camHeight - radius){
            pos.y = camHeight - radius;
            isOnScreen = false;
        }

        if(pos.y <  -camHeight + radius){
            pos.y = -camHeight + radius;
            isOnScreen = false;
        }

        if(keepOnScreen && !isOnScreen){
        transform.position = pos;
        isOnScreen = true;
        }
    }

    void OnDrawGizmos(){ // this draws a boundry 
        if(!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth*2, camHeight*2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
   
}
