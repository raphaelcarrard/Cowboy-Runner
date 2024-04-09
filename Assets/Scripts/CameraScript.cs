using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public PlayerMove player;

    private Vector3 lastPlayerPosition;
    private float distance;

    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        lastPlayerPosition = player.transform.position;
    }


    void Update()
    {
        distance = player.transform.position.x - lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        lastPlayerPosition = player.transform.position;
    }
}
