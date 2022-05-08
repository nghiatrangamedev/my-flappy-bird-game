using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Tạo ra 1 để chứa Prefab
    [SerializeField] private GameObject waterPilePrefab;
    

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Bird").GetComponent<PlayerController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
