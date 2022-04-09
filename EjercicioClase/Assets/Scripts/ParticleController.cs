using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    //public GameObject Particle;
    public GameObject Particle1; //Posición original
    public GameObject Particle2; //Definir arreglo de partículas
    public GameObject Particle3;

    public Vector3 gravity = new Vector3(0.0f,-9.807f,0.0f);
    public float m = 0.1f;
    public float k1 = 1.0f; //Material Homogéneo = misma k
    public float k2 = 1.0f;
    public float k3 = 1.0f;
    public float d = 0.1f;
    Vector3 force = new Vector3(0.0f,0.0f,0.0f);
    Vector3 ac = new Vector3(0.0f,0.0f,0.0f);
    Vector3 vel = new Vector3(0.0f,0.0f,0.0f);
    Vector3 pos = new Vector3(0.0f,0.0f,0.0f);
    Vector3 pos1 = new Vector3(0.0f,0.0f,0.0f);
    Vector3 pos2 = new Vector3(0.0f,0.0f,0.0f); //Arreglo pos
    Vector3 pos3 = new Vector3(0.0f,0.0f,0.0f);

    // Start is called before the first frame update
    void Start()
    {
        pos1 = Particle1.transform.position;
        pos2 = Particle2.transform.position;
        if(Particle3!=null){
            pos3 = Particle3.transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        pos1 = Particle1.transform.position;
        pos2 = Particle2.transform.position;
        if(Particle3!=null){
             pos3 = Particle3.transform.position;
             force = (gravity*m) - (k1*(pos-pos1))-(k2*(pos-pos2))-(k3*(pos-pos3)) - (d*vel);
        }else{
            force = (gravity*m) - (k1*(pos-pos1))-(k2*(pos-pos2))- (d*vel);
        }
        ac = force/m;
        vel+= ac*Time.deltaTime;
        pos+= vel*Time.deltaTime;
        transform.position = pos;

        Debug.DrawLine(pos,pos1);
        Debug.DrawLine(pos,pos2);
        if(Particle3!=null){
            Debug.DrawLine(pos,pos3);
        }
        
    }
}
