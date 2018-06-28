using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousMovement : MonoBehaviour {
    public float moveSpeed;
    public Vector3 target;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();

        if(gameObject.transform.position != target)
        {
            transform.position = Vector2.MoveTowards(gameObject.transform.position,target,moveSpeed*Time.deltaTime);
            //transform.Translate(new Vector3((target.normalized.x - gameObject.transform.position.normalized.x) * moveSpeed * Time.deltaTime, -(target.y - gameObject.transform.position.normalized.y) * moveSpeed * Time.deltaTime));
        }
        

    }

    void SetTarget()
    {
        target = GameObject.Find("Sprite").transform.position;
    }
}
