using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]

    public float speed = 10f; // speed of enemy
    
    private BoundsCheck bndCheck; 

    void Awake(){
        bndCheck = GetComponent<BoundsCheck>();
    }

    public Vector3 pos {
        get{
            return(this.transform.position);

        }
        set{
            this.transform.position = value;
        }
    }


    void Update(){ // moves the Enemy
        Move();

        // destroys the enemy is they go out of the screen
        if( bndCheck != null && !bndCheck.isOnScreen){
            if(pos.y < bndCheck.camHeight - bndCheck.radius){
                Destroy(gameObject);
            }
            if(pos.x < bndCheck.camHeight - bndCheck.radius){
                Destroy(gameObject);
            }
            if(pos.x > -bndCheck.camWidth + bndCheck.radius){
                Destroy(gameObject);
            }
        }
    }


    public virtual void Move(){ // moves the enemy down
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
}
