//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
public class PlayerRotate : MonoBehaviour
{
    public float speed = 15f;
    private Transform CameraDrive;

    // Start is called before the first frame update
    private void Start()
    {
        CameraDrive = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    private void Update()
    {
        CameraDrive.Rotate(speed * Time.deltaTime, 0, 0);
    }
}
