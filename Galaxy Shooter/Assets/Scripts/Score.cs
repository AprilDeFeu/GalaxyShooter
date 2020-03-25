using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI _tM;
    private Player _player;
    public int _score;
    void Start()
    {
        _tM = GetComponent<TextMeshProUGUI>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (_player == null) Debug.LogError("The GameObject for \"Player\" is missing.");
    }

    // Update is called once per frame
    void Update()
    {
        _tM.text = "Score: " + _score.ToString();
    }

    public void addScore(int gain)
    {
        _score += gain;
    }
}
