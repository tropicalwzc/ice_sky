using UnityEngine;
using System.Collections;
// This is a fast speed bullet
public class laser : MonoBehaviour
{

    GameObject mission;
    GameObject obj, controler;
    Vector3 futureposition;
    public float directy, directx;
    // Use this for initialization
    void Start()
    {
        this.name = "playerbullet";
        futureposition = new Vector3(transform.localPosition.x + directx, transform.localPosition.y + directy, transform.localPosition.z);

    }

    // Update is called once per frame
    void Update()
    {

        float speed = 60f;
        float step = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, futureposition, step);
        if (this.transform.localPosition.y >= 30f)
        {
            Destroy(this.gameObject);
        }

    }
}
