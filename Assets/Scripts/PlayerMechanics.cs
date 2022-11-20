using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMechanics : MonoBehaviour
{
    public float direction = 0;
    Rigidbody rb;
    //public Touch touch = Input.GetTouch(0);
    public float Speed = 1;
    public float S = 0.01f;
    public Transform SphereToPlase;
    public GameObject Player, RestartButton;
    private Vector3 allPosition = new Vector3(0,1,0);
    private Vector3 startPos;
    private Vector3 directionTouch = new Vector3(0,1,0);
    private void Start()
    {
        SphereToPlase = GetComponent<Transform>(); 
        rb =  GetComponent<Rigidbody>();
    }
    private Vector3 dir;
   
    // Update is called once per frame
    private void Update()
    {
        if(SphereToPlase.position.y < 0)
             PlayerEnd();
        if(direction == 0)
        {
            Speed = 1;
            rb.transform.Translate(0, 0, Speed * Time.deltaTime);
        }
        if(direction < 0)
        {
            if(Speed > 0)
                Speed = -Speed;
            rb.transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
        if(direction > 0)
        {
            Speed = 1;
            rb.transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
        
        
        //PlayerMec();
        
        if(Input.touchCount > 0 && direction != -2)
        {
            
            //#if !UNITY_EDITOR
            if( Input.GetTouch(0).phase == TouchPhase.Began)
            {
                direction = 0;
                startPos = Input.GetTouch(0).position;
            }
                
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
                direction = Input.GetTouch(0).position.x - startPos.x; 
            //if(Mathf.Abs(direction) < 10)
                //direction = 0;
            //#endif
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow) && direction != -2)
            direction = -1;
        if(Input.GetKeyDown(KeyCode.RightArrow) && direction != -2)
            direction = 1;
        if(Input.GetKeyDown(KeyCode.UpArrow) && direction != -2) 
            direction = 0;
            float Res = rb.transform.position.z;
        //
    }
    
    private void PlayerEnd()
    {
        direction = -2;
        RestartButton.SetActive(true);
    }

    

}
