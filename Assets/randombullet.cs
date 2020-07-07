using UnityEngine;
using System.Collections;
// random bullet control
public class randombullet : MonoBehaviour
{

    GameObject mission;
    GameObject obj, controler;
    Vector3 futureposition;
    public float directy = -400f;
    public float speed;
    // Use this for initialization
    void Start()
    {
        this.name = "smallbullet";
        futureposition = new Vector3(transform.localPosition.x + Random.Range(-400f, 400f), transform.localPosition.y + directy, transform.localPosition.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float step = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, futureposition, step);
        if (directy < 0)
            if (this.transform.localPosition.y < -30f)
            {
                Destroy(this.gameObject);
            }

        if (directy > 0)
            if (this.transform.localPosition.y > 30f)
            {
                Destroy(this.gameObject);
            }

    }
}
