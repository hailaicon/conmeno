using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private bool jump;
    public GameObject really;
    public int speed = 5;
    public Animator NamSan;
    // Start is called before the first frame update
    void Start()
    {
         NamSan = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(really, 4f);
        //tiến về phía trước.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //nhấn đẻ qua trái và qua phải theo horizontal.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
        }

        //nhấn phím để nhảy theo vertical và điều kiện jump bằng true.
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && jump)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 6.5f,ForceMode.Impulse);
        }
    }

    //xét va chạm điều kiện jump giữa người chơi và mặt đất có tag tên là Ground.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("vatcan"))
        {
            Debug.Log("Nhan vat da thua");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            NamSan.SetTrigger("Te");
            transform.Translate(Vector3.forward * 0 * Time.deltaTime);
            //_GameOverPanel.SetActive(true);
        }
    }
}
