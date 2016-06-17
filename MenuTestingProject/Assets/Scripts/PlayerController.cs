using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public AudioClip pickUpSound;
    public AudioClip VictoryJingle;
    public GameObject quitButton;

    private Rigidbody rb;
    private int count;

	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
	
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVericatl = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVericatl);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pick Up")
        {
            other.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 13)
        {
            winText.text = "You Win!";
            AudioSource.PlayClipAtPoint(VictoryJingle, transform.position);
            quitButton.SetActive(true);
        }
    }
}
