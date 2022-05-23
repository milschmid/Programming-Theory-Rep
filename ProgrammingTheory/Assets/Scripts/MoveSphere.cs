using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class MoveSphere : MoveObject 
{   
    private Rigidbody rB;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    // Override MakeMove, Forces only allowed on diagonals
    public override void MakeMove(){ // POLYMORPHISM
         rB.AddForce(0.5f*forceStrength*RandomVectorAlongDiags(), ForceMode.Impulse);
    }

    // Random Rotation (not needed now)
    public Quaternion RandomRotaion(float angle){ // ABSTRACTION
        return Quaternion.AngleAxis(angle, Random.insideUnitCircle);
    }

     // random vector only along the z or x direction
    public Vector3 RandomVectorAlongDiags(){ // ABSTRACTION
        int sgn1 = Random.Range(0,2); 
        int sgn2 = Random.Range(0,2); 
        float x = Mathf.Pow(-1.0f, sgn1);
        float z = Mathf.Pow(-1.0f, sgn2);
        return new Vector3(x, 0.0f, z)/Mathf.Sqrt(2);
    }
}
