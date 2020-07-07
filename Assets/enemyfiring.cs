using UnityEngine;
using System.Collections;
// different enemy plane fire type controller
public class enemyfiring : MonoBehaviour
{

    public GameObject[] prefab = new GameObject[5];
    public int firenum = 1;
    public AudioClip AC;
    public int firerate = 40;
    public int randomfourorfive = 0;
    public int cannonmode = 0;
    public int cannon_distance = 0;
    GameObject fire, obj, playerpl;
    int sander;
    int heat;
    // Use this for initialization
    void Start()
    {
        playerpl = GameObject.FindGameObjectWithTag("Player");
        sander = 0;
    }
    float calculate_distance(float going_to_x, float going_to_y)
    {
        float totaldistancex = going_to_x - this.transform.position.x;
        float totaldistancey = going_to_y - this.transform.position.y;
        return totaldistancex * totaldistancex + totaldistancey * totaldistancey;
    }
    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.y < -30f)
            Destroy(this.gameObject);

        if (playerpl != null)
            sander++;

        if (randomfourorfive == 1)
        {
            firenum = Random.Range(4, 6);
        }
        if (sander > firerate && cannonmode == 0 && this.transform.position.y < 50f)
        {
            sander = 0;
            AudioSource.PlayClipAtPoint(AC, transform.localPosition);
            if (firenum == 1)
            {
                obj = Instantiate(prefab[0]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
            }

            if (firenum == 2)
            {
                obj = Instantiate(prefab[0]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 1f, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
                obj = Instantiate(prefab[1]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 1f, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
            }
            if (firenum == 3)
            {
                obj = Instantiate(prefab[0]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
                obj = Instantiate(prefab[1]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 1f, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
                obj = Instantiate(prefab[2]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 1f, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
            }
            if (firenum == 4)
            {
                obj = Instantiate(prefab[0]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 3f, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
                obj = Instantiate(prefab[0]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 3f, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
                obj = Instantiate(prefab[0]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 0.5f, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
                obj = Instantiate(prefab[0]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 0.5f, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
            }
            if (firenum == 5)
            {
                obj = Instantiate(prefab[0]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
                obj = Instantiate(prefab[1]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 1f, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
                obj = Instantiate(prefab[2]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 1f, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
                obj = Instantiate(prefab[3]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 0.5f, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
                obj = Instantiate(prefab[4]) as GameObject;
                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 0.5f, this.transform.localPosition.y - 2f, this.transform.localPosition.z);
            }
        }
    }

}
