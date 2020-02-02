using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerSpawner : MonoBehaviour
{
    public GameObject adventurerPF;
    public int numSpawns = 10;
    public float spawnCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
        }
        else if(spawnCooldown < 0)
        {
            spawnCooldown = 0;
        }
        else if(spawnCooldown == 0 && numSpawns > 0)
        {
            Spawn();
            spawnCooldown = (float) Random.Range(1, 11);
        }
    }
    void Spawn()
    {
        Instantiate(adventurerPF, gameObject.transform, true);
        numSpawns--;
    }
}
