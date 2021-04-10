using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S;
    public float speed = 30;
    public float speed_x = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    public float gameRestartDelay = 2f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;
    public AudioSource audio;
    //public AudioSource aaa;


    [Header("Set in Inspector")]
    [SerializeField]
    private float _shieldLevel = 1;
    private GameObject  lastTrigerGo = null;
    
    

    void Awake()
    {
        
        if (S == null)
        {
            S = this;
        }else
        {
            Debug.LogError("Hero.Awake() - Attempted to assing second Hero.S!");
            
        }
        audio = GetComponent<AudioSource>();
        
    }
    


    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        Vector3 Mouse = Input.mousePosition;
        Mouse.z = -Camera.main.transform.position.z;
        Vector3 Mouse3d = Camera.main.ScreenToWorldPoint(Mouse);


       // Vector3 pos = transform.position;
        //pos.x += xAxis * speed * Time.deltaTime;
        //pos.y += yAxis * speed * Time.deltaTime;
        //transform.position = pos;

        Vector3 pos = transform.position;
        pos.x += Mouse3d.x * speed_x  * Time.deltaTime;
        pos.y += Mouse3d.y * speed * Time.deltaTime;
        transform.position = pos;

        //transform.rotation = Quaternion.Euler(Mouse.y * pitchMult,  Mouse.x  * rollMult, 0);

        if ( Input.GetKeyDown(KeyCode.Space)){
            TempFire();
            audio.Play();
        }
    }
    public void TempFire(){
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.up * projectileSpeed;
    }
    public void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        
        print("Triggered: " +go.name);
       if (go == lastTrigerGo){
           return;
       }
       lastTrigerGo = go;

       if (go.tag == "Enemy"){
           //aaa.Play();

           shieldLevel--;
           Destroy(go);

        }
        else
        {
           print("Triggered by non-Enemy: " + go.name);
        }
    }

    public float shieldLevel {
        get
        {
            return(_shieldLevel);
        }
        set
        {
            _shieldLevel = Mathf.Min(value, 4);
            if(value < 0)
            {
                Destroy(this.gameObject);
                Main.S.DelayedRestart(gameRestartDelay);
                
            }       
        }   
    }
}
