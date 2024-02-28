using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraspin : MonoBehaviour
{
    public float rotationSpeed = 2.0f;

    void Update()
    {
        // カメラを自動で回転させる
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
