using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {
    
    public GameObject customer_prefab;
    public float spawnTime = 5f;
    public Transform spawnPoints;
    public float countdown = 200.0f;
    int i = 0;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        
    }
    void Update()
	{
			
        //spawn customer with time constraint
        if (countdown <= 0.0f)
        {
            //after time runs out , we cancel spawn function
            CancelInvoke();
        }
    }
	
	// Update is called once per frame
	void Spawn () {
        
			customer_prefab.name = "Customer " + i;
			i++;

			// Create an instance of the enemy prefab at spawn point's position and rotation.
			GameObject customer_instantiate=Instantiate (customer_prefab, spawnPoints.position, spawnPoints.rotation);
			customer_instantiate.transform.SetParent (this.transform, true);
		
    }
   
}
