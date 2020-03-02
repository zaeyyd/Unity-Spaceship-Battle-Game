using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy
{
    
    
  
    public override void Move(){
        Vector3 tempPos = pos;


        // randomly generates a number in order to randomize direction of Enemy movement
        int randomNumber = Random.Range(0,2);

        if(randomNumber<1){
            tempPos.x -= speed * Time.deltaTime;
        }
        else{
            tempPos.x += speed * Time.deltaTime;
        }

        
        tempPos.y -= speed * Time.deltaTime;
        
        pos = tempPos;
    }
}
