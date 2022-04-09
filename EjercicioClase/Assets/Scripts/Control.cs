using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject monkey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            monkey.transform.position += new Vector3(0.0f, 0.0f, 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            monkey.transform.position -= new Vector3(0.0f, 0.0f, 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            monkey.transform.position -= new Vector3(0.1f, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            monkey.transform.position += new Vector3(0.1f, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.R)){
            monkey.transform.Rotate(0.0f,30.0f,0.0f,Space.World);
        }
        if (Input.GetKeyDown(KeyCode.T)){
            monkey.transform.Rotate(0.0f,-30.0f,0.0f,Space.World);
        }
        if (Input.GetMouseButton(0)){
            monkey.transform.localScale *= 0.5f;
        }
        if (Input.GetMouseButton(1)){
            monkey.transform.localScale *= 2.0f;
        }
    }
}
