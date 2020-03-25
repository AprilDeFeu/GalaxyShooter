using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI _tM;
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
        _tM.text = "Lives: " + player.getLives().ToString();
    }
}
