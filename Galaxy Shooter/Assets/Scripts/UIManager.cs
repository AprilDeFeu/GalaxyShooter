using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    int counter = 0;
    private TextMeshProUGUI _tM;
    private float time;
    private float seconds;
    private float minutes;
    private float mili;
    public int _score;
    private Player player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _tM = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player == null) Debug.LogError("The GameObject for \"Player\" is missing.");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "Time")
        {
            gameTime();
            if (player.getLives() < 1) anim.Play("Time_final");
        }
        if (this.tag == "Score") 
        {
            score();
            if (player.getLives() < 1) anim.Play("Score_final");
        }
        if (this.tag == "Lives")
        {
            Health();
            if (player.getLives() < 1) anim.Play("Lives_fade");
        }
        if (this.tag == "GameOver" && player.getLives() < 1)
        {
            anim.Play("GameOver_fadein 0");
        }
        if (this.tag == "Retry" && player.getLives() < 1)
        {
            anim.Play("Retry_fadein");
        }
    }

    void gameTime()
    {
        time = Time.time;
        minutes = (int)(time / 60);
        seconds = time % 60;
        if (player.getLives() > 0)
        {
            _tM.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00.000");
        }
    }

    void score()
    {
        _tM.text = "Score: " + _score.ToString();
    }

    public void addScore(int gain)
    {
        _score += gain;
    }

    void Health()
    {
        _tM.text = "Lives: " + player.getLives().ToString();
    }



}
