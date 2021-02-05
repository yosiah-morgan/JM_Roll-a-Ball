using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    //public float deathSize = 0.2f;
    [Range(0.0f, 1.0f)] public float shrinkSpeed = 0.01f; 
    [Range(0.0f, 10.0f)] public float growAmount = 1f;

    private Rigidbody rb;
    private int count;
    private bool wonGame;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);

        // Make player smaller over time
        /*if (!wonGame)
        {
            transform.localScale -= Vector3.one * shrinkSpeed;
            if (transform.localScale.x <= deathSize)
            {
                // kill player
                winText.text = "You died :(";
                Destroy(gameObject);
            }    
        }*/
    }
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();

            transform.localScale += Vector3.one * growAmount; // scale the player up when they get a pickup
        }
    }
    
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 9)
        {
            winText.text = "You Win!";
            wonGame = true;
        }
    }
}