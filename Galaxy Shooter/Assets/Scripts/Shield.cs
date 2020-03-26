﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private int _protectionLevel=10;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    public void updateShield()
    {
        _protectionLevel = 10;
    }

    public void Damage(int dam)
    {
        _protectionLevel -= dam;
        if (_protectionLevel <= 0) Destroy(this.gameObject);
        
    }

}
