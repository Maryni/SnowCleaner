using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeaps : MonoBehaviour
{
    [SerializeField] private SnowBrush snowBrush;
    [SerializeField] private List<GameObject> heaps;
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private GameObject car;
    [SerializeField] private bool needSpawn;
    [SerializeField] private float timer = 0f
        ;
    private void FixedUpdate()
    {
        if(snowBrush.GetOnSnow())
        {
            timer -= 0.1f;
            
            if(needSpawn && timer<0f)
            {
                int a = Random.Range(0, 3);
                for (int i = 0; i < spawnPoints.Count; i++)
                {
                    GameObject temp;
                    Instantiate(heaps[a], spawnPoints[i].transform);
                    temp = spawnPoints[i].transform.GetChild(0).gameObject;
                    temp.transform.localPosition = new Vector3(0f, 0f, 0f);
                    temp.transform.parent = null;
                }
            }
            if (timer < 0f) { needSpawn = true; timer = 5f; }
        }
    }
}
