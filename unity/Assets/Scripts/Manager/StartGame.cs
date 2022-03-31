using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameObject go = Resources.Load<GameObject>("Prefabs/GameManager");
            Instantiate(go, transform.position, transform.rotation);
        }
    }
}