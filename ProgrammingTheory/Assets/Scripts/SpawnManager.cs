using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> prefabs;

    public int numPrefab1 = 2;
    public int numPrefab2 = 2;


    // Start is called before the first frame update
    void Start()
    {   
        // Calculate possible start points and shuffket their position 
        List<Vector3> possiblePositions = PossibleStartPositions();
        SattoCycle(ref possiblePositions);
    
        // Spawn Objects according to their assigne numbers
        int tmp = 0;
        List<int> tmpList = new List<int> {numPrefab1, numPrefab2};
        for (int i = 0; i < prefabs.Count; i++){
            // Spawn first object tmpList[i] times
            for(int j=0; j < tmpList[i]; j++){
                if (tmp < possiblePositions.Count){ 
                    SpawnObject(prefabs[i], possiblePositions[tmp]);
                    tmp += 1;
                } else { // make sure that only 25 objects are maximally spawned
                    break;
                }
            }
        }
    }

    // Spawn a given object at a given position
    public void SpawnObject(GameObject prefab, Vector3 position){
        Instantiate(prefab, 
                position,
                Quaternion.identity);
    }

    // Calculate possible initial position in x-z plane
    public List<Vector3> PossibleStartPositions(){
        List<Vector3> posList = new List<Vector3>();
        for (int x=0;x<5;x++){
            for (int z=0;z<5;z++){
                posList.Add(new Vector3(-4+2*x,0.5f,-4+2*z));
                }
        }

        return posList;
    }

    // Sattos algorithm for shufflin a list
    public void SattoCycle(ref List<Vector3> myList){
        int i = myList.Count;
        while (i>1){
            i -= 1;
            int j = Random.Range(0,i+1);
            var ji = myList[i];
            var ij = myList[j];

            myList[j] = ji;
            myList[i] = ij;
        }
    }
}
