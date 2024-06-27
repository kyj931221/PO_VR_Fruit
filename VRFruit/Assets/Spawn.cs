using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] prefab;
    public Transform[] pos;

    AudioSource audio;
   
    void Start()
    {
        audio = GetComponent<AudioSource>();
        InvokeRepeating("CreateFruit", 2, 2); // 2초가 지난 뒤에 2초마다 불러 반복.
    }

    void CreateFruit()
    {
        for (int i = 0; i < 2; i++)
        {
            int iFruit = Random.Range(0, prefab.Length);
            int iPos = Random.Range(0, pos.Length);

            GameObject obj = Instantiate(prefab[iFruit], pos[iPos].position, Quaternion.identity);
            Destroy(obj, 5f);

            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * Random.Range(10f, 15.0f), ForceMode.VelocityChange);
        }
        audio.Play();
    }
    
    void Update()
    {
        
    }
}
