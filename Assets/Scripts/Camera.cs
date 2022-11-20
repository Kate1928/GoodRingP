//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
public class Camera : MonoBehaviour
{
    public Vector3 Pos = new Vector3(0, 0, 0);
    //public float speed = 5f;
    private Transform CameraDrive;

    public GameObject Play;

    // Start is called before the first frame update
    private void Start()
    {
        CameraDrive = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    private void Update()
    { 
        if(Play.transform.position.y > 0)  
        {
            Pos.x = Play.transform.position.x;
            Pos.y = Play.transform.position.y + 10;
            Pos.z = Play.transform.position.z;
            CameraDrive.transform.position = Pos;
        }
        
        //CameraDrive.Rotate(0, speed * Time.deltaTime, 0);
    }
}
