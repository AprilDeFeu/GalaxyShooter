using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI _tM;
    private float time;
    private float seconds;
    private float minutes;
    private float mili;
    private Player player;

    
    void Start()
    {
        
        _tM = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player == null) Debug.LogError("The GameObject for \"Player\" is missing.");
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        minutes = (int)(time / 60);
        seconds = time % 60;
        if (player.getLives() > 0)
        {
            _tM.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00.000");
        }
           
    }



    
}
