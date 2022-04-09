using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClothSimulationII : MonoBehaviour
{
    public GameObject particle;
    Vector3 posPF = new Vector3(0.0f,0.0f,0.0f); //Posición particle fija

    public float m = 0.1f;
    public float k = 1.0f; //Mat homogéneo
    public float d = 0.1f;
    public Vector3 gravity = new Vector3(0.0f,-9.807f,0.0f);
    Vector3 pos = new Vector3(0.0f,0.0f,0.0f);
    public Vector3 force = new Vector3(0.0f,0.0f,0.0f);
    Vector3 ac = new Vector3(0.0f,0.0f,0.0f);
    Vector3 vel = new Vector3(0.0f,0.0f,0.0f);
    public float x,z = 0.0f;

    public int temporal = 1;

    void createClone(float x,float z, string ID){
        GameObject clone = Instantiate(particle);
        clone.transform.position = new Vector3(x,0.0f,z);
        clone.name = ID;
        //positions.Add(clone.transform.position);
    }

    void Add_OneForce(int start, int end,int num,int part){
        temporal = part+num+start;
        force -= (k*(GameObject.Find(part.ToString()).transform.position-GameObject.Find(temporal.ToString()).transform.position));
        if (start!=end){
            Add_OneForce(start+1,end,num,part);
        }
    }

    void Draw_OneCon(int start, int end, int num, int part){
        temporal = part+num+start;
        Debug.DrawLine(GameObject.Find(part.ToString()).transform.position,GameObject.Find(temporal.ToString()).transform.position);
        if (start!=end){
            Draw_OneCon(start+1,end,num,part);
        }
    }

    void Add_FiveForces(int part){
        Add_OneForce(0,1,0,part);
        //temporal = part+1;
        //force -= (k*(GameObject.Find(part.ToString()).transform.position-GameObject.Find(temporal.ToString()).transform.position));
        Add_OneForce(0,2,14,part);
        /*for (int i=0;i<=2;i++){
            temporal = part+14+i;
            force -= (k*(GameObject.Find(part.ToString()).transform.position-GameObject.Find(temporal.ToString()).transform.position));
        }*/
    }

    void Add_EightForces(int part){
        Add_OneForce(0,1,0,part);
        //temporal = part+1;
        //force -= (k*(GameObject.Find(part.ToString()).transform.position-GameObject.Find(temporal.ToString()).transform.position));
        Add_OneForce(0,2,15,part);
        /*for (int i=0;i<=2;i++){
            temporal = part+15+i;
            force -= (k*(GameObject.Find(part.ToString()).transform.position-GameObject.Find(temporal.ToString()).transform.position));
        }*/
        for (int i=0;i<=2;i++){
            temporal = part-16+i;
            force -= (k*(GameObject.Find(part.ToString()).transform.position-GameObject.Find(temporal.ToString()).transform.position));
        }
    }

    void Set_FC_Velocity(int start, int end){
        force = (gravity*m)-(k*(GameObject.Find(start.ToString()).transform.position-posPF))-(d*vel);
        Add_FiveForces(start); //Total forces
        ac = force/m;
        vel+= ac*Time.deltaTime;
        GameObject.Find(start.ToString()).transform.position+= vel*Time.deltaTime;
        Debug.DrawLine(GameObject.Find(start.ToString()).transform.position,GameObject.Find((start-1).ToString()).transform.position);
        Draw_FiveConections(start);
        if (start!=end){
            Set_FC_Velocity(start+1,end);
        }
    }

    void Set_EC_Velocity(int start,int end){
        force = (gravity*m)-(k*(GameObject.Find(start.ToString()).transform.position-GameObject.Find((start-1).ToString()).transform.position))-(d*vel);
        Add_EightForces(start); //Total forces
        ac = force/m;
        vel+= ac*Time.deltaTime;
        GameObject.Find(start.ToString()).transform.position+= vel*Time.deltaTime;
        Debug.DrawLine(GameObject.Find(start.ToString()).transform.position,GameObject.Find((start-1).ToString()).transform.position);
        Draw_EightConections(start);
        if (start!=end){
            Set_EC_Velocity(start+1,end);
        }
    }

    void Draw_FiveConections(int part){
        temporal = part+1;
        Debug.DrawLine(GameObject.Find(part.ToString()).transform.position,GameObject.Find(temporal.ToString()).transform.position);
        Draw_OneCon(0,2,14,part);
        /*for (int i=0;i<=2;i++){
            temporal = part+14+i;
            Debug.DrawLine(GameObject.Find(part.ToString()).transform.position,GameObject.Find(temporal.ToString()).transform.position);
        }*/
    }
        
    void Draw_EightConections(int part){
        temporal = part-1;
        Debug.DrawLine(GameObject.Find(part.ToString()).transform.position,GameObject.Find(temporal.ToString()).transform.position);
        temporal = part+1;
        Debug.DrawLine(GameObject.Find(part.ToString()).transform.position,GameObject.Find(temporal.ToString()).transform.position);
        Draw_OneCon(0,2,15,part);
        /*for (int i=0;i<=2;i++){
            temporal = part+15+i;
            Debug.DrawLine(GameObject.Find(part.ToString()).transform.position,GameObject.Find(temporal.ToString()).transform.position);
        }*/
        for (int i=0;i<=2;i++){
            temporal = part-16+i;
            Debug.DrawLine(GameObject.Find(part.ToString()).transform.position,GameObject.Find(temporal.ToString()).transform.position);
        }
    }

    void Start()
    {
        particle.name="1";
        posPF=particle.transform.position;
        for(int i=2; i<=255; i++){
            if (i%16==0){
                x=0.0f;
                z += 1.0f;
                createClone(x,z,i.ToString());
            }else{
                x += 1.0f;
                createClone(x,z,i.ToString());
            }   
        }
    }

    // Update is called once per frame
    void Update()
    {
        posPF=particle.transform.position;
        force = (gravity*m)-(k*(GameObject.Find("2").transform.position-posPF))-(d*vel);
        Add_FiveForces(2); //Total forces

        ac = force/m;
        vel+= ac*Time.deltaTime;
        pos+= vel*Time.deltaTime;
        GameObject.Find("2").transform.position = pos; 

        Debug.DrawLine(pos,posPF);
        Draw_FiveConections(2);

        Set_FC_Velocity(3,14);

        Set_EC_Velocity(17,28);
        
        Set_EC_Velocity(34,44);
        /*for (int i=33;i<=44;i++){
            Set_EC_Velocity(i);
        }*/
    }
}
