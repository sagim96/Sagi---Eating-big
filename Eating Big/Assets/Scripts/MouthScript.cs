using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouthScript : MonoBehaviour
{
    public bool gameOver = false;
    static public int score = 0;
    public Text ScoreText;
    public AudioSource appleSound;
    public AudioSource iceCreamSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float mouseX = mousePos.x;
            mouseX = Mathf.Clamp(mouseX, -7.5f, 7.5f);
            transform.position = new Vector3(mouseX, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameOver)
        {
            int appleValue = collision.GetComponent<Apple>().value;
            score += appleValue;
            score = Mathf.Clamp(score, 0, int.MaxValue);
            ScoreText.text = "Score: " + score;
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag=="Apple")
        {
            appleSound.Play();
        }

        if (collision.transform.tag== "IceCream")
        {
            iceCreamSound.Play();
        }


    }


}
