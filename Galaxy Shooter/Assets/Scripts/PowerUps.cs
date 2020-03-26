using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
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
        if (other.tag == "Player")
        {
            if (this.tag == "TripleShot")
            {
                Destroy(this.gameObject);
                Player temp = other.transform.GetComponent<Player>();
                if (temp != null) temp.tsON();
                else Debug.LogError("\"Player\" GameObject not found. Verify Collider or Rigidbody components.");
            }
            else if (this.tag == "Health")
            {

                Destroy(this.gameObject);
                Player temp = other.transform.GetComponent<Player>();
                if (temp != null) temp.Heal();
                else Debug.LogError("\"Player\" GameObject not found. Verify Collider or Rigidbody components.");
            }
            else if (this.tag == "Speed")
            {
                Destroy(this.gameObject);
                Player temp = other.transform.GetComponent<Player>();
                if (temp != null) temp.speedON();
                else Debug.LogError("\"Player\" GameObject not found. Verify Collider or Rigidbody components.");
            }
            else if (this.tag == "Shield")
            {
                Destroy(this.gameObject);
                Player temp = other.transform.GetComponent<Player>();
                if (temp != null)  temp.shieldON();
                else Debug.LogError("\"Player\" GameObject not found. Verify Collider or Rigidbody components.");
            }
        }
    }

    void Movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -6) Destroy(this.gameObject);
    }
}
