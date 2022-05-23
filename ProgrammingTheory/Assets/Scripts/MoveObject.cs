using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{   
    [SerializeField] public float forceStrength = 2.0f;
    private Rigidbody rB;
    public float pendingTime = 0.0f;
    public float period = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > pendingTime){ 
            MakeMove();
            pendingTime = Time.time + period; 
        }
    }

    // Add random force of strength forceStrength
    public virtual void MakeMove(){ 
        rB.AddForce(forceStrength*RandomVectorAlongAxis(), ForceMode.Impulse);
    }


    // random vector only along the z or x direction
    public Vector3 RandomVectorAlongAxis(){ // ABSTRACTION
        float x = Random.Range(-1.0f,1.0f);
        int idx = Random.Range(0,2);
        Vector3 vec = new Vector3();
        vec[idx == 0 ? 0 : 2] = x; 
        return vec;
    }

    // Generate a random unit vector in plane
    public Vector3 RandomVector(){ // ABSTRACTION
        // Random numbers for x-z plane
        float x = Random.Range(-1.0f,1.0f);
        float z = Random.Range(-1.0f,1.0f);
        return new Vector3(x, 0.0f, z)/Mathf.Sqrt(x*x + z*z);
    }

}
