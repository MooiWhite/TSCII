using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            camera.transform.position += new Vector3(0.0f, 0.0f, 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            camera.transform.position -= new Vector3(0.0f, 0.0f, 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            camera.transform.position -= new Vector3(0.1f, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            camera.transform.position += new Vector3(0.1f, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.Z)){
            camera.transform.Rotate(0.0f,30.0f,0.0f,Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.X)){
            camera.transform.Rotate(0.0f,-30.0f,0.0f,Space.Self);
        }
    }
}
