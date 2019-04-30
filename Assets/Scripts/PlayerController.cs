using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    Rigidbody rb;
    int count;
    GameObject[] getCount;
    int pickUpCount;

    void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "You Win!";
        winText.gameObject.SetActive(false);
        getCount = GameObject.FindGameObjectsWithTag("Pick Up");
        pickUpCount = getCount.Length;
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Crazy Pick Up")) {
            other.gameObject.transform.localScale += new Vector3(5, 0, 0);
            count += 1;
            SetCountText();
        }

        if (count == pickUpCount) {
            winText.gameObject.SetActive(true);
            rb.isKinematic = true;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();
    }
}
