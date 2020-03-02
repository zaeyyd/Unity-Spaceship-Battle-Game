using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    static public Hero S;
    
    [Header("Set in Inspector")]
    
    // variables to control speed and movement of Hero
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;


    private GameObject lastTriggerGo = null;
    
    void Awake(){ // this renders the Hero object
    
        if(S==null){
        S = this;
        }
        else{
        Debug.LogError("Hero.Awake() - Seconf Hero was attempted");
        }
    }
    
    void Update(){
    
    // gets information from Input class
    
    float xAxis = Input.GetAxis("Horizontal");
    float yAxis = Input.GetAxis("Vertical");

    // changes postion based on axed

    Vector3 pos = transform.position;
    pos.x += xAxis*speed*Time.deltaTime;
    pos.y += yAxis*speed*Time.deltaTime;
    transform.position = pos;

    // rotate ship slightly

    transform.rotation = Quaternion.Euler(yAxis*pitchMult,xAxis*rollMult,0);


    }
    
    // destroies the enemy and Hero after collision
    void OnTriggerEnter(Collider other){
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;


        if(go == lastTriggerGo){
            return;
        }
        lastTriggerGo = go;

        if(go.tag == "Enemy"){
            Destroy(go);
            Destroy(gameObject);
        }
        else{
            print("Triggered by non-Enemy:"+ go.name);
        }
    }
    
    
    
}
