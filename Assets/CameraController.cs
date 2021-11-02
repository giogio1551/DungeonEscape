using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerController.self.transform.position.x + offset.x, PlayerController.self.transform.position.y + offset.y, PlayerController.self.transform.position.z + offset.z);

    }
}
