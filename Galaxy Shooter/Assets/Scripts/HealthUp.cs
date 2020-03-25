using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }



    private void OnTriggerEnter(Collider other)
    {
        string player = "Player";
        if (other.tag == player)
        {
            Player temp = other.transform.GetComponent<Player>();
            Destroy(this.gameObject);
            if (temp != null) temp.Heal();
            Debug.Log("Player Lives: " + temp.getLives());
        }
    }

    void Movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -6) Destroy(this.gameObject);
    }


}
