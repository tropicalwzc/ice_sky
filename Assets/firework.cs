using UnityEngine;
using System.Collections;
// player normal fire
public class firework : MonoBehaviour
{
    GameObject mission;
    GameObject obj, controler;
    Vector3 futureposition;
    public float directy, directx;
    public float speed = 50f;
    float step = 0;
    // Use this for initialization
    void Start()
    {
        this.name = "playerbullet";
        futureposition = new Vector3(transform.localPosition.x + directx, transform.localPosition.y + directy, transform.localPosition.z);
        step = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, futureposition, step);
        if (this.transform.position.y >= 30f || this.transform.position.y < -30f)
        {
            Destroy(this.gameObject);
        }

    }

}
