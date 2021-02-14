using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 800.0f;
    public Text scoreText;
    private int count = 0;
    public Text winText;
    public Button toCredit;
    public Toggle ballSize;

    private void Start()
    {
        ballSize.GetComponent<Toggle>().isOn = false;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            scoreText.text = "Score: " + count;
        }

        if (count >= 12)
        {
            winText.gameObject.SetActive(true);
            toCredit.gameObject.SetActive(true);
        }
    }
    public void BallResize()
    {
        if (ballSize.isOn)
        {
            transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    public void AdjustSpeed(float newSpeed)
    {
        Time.timeScale = newSpeed;
    }

}
