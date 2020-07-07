using UnityEngine;
using System.Collections;
// the bullet will automatically follow enemy
// we need calculate the angle of bullet carefully since the enemy is moving as well
public class followbullet : MonoBehaviour
{

    GameObject mission;
    GameObject obj;
    GameObject[] controler;
    Vector3 futureposition;
    float totaldistancex, totaldistancey;
    public float speed = 50f;
    float minimum_distance;
    GameObject minumum_enemy;
    public int extra_damage_point = 0;
    // Use this for initialization
    void Start()
    {
        controler = GameObject.FindGameObjectsWithTag("enemy");
        futureposition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 100f, this.transform.localPosition.z);
    }
    void angle_move_to(float going_to_x, float going_to_y)
    {
        change_angle(going_to_x, going_to_y);
        futureposition = new Vector3(going_to_x, going_to_y, this.transform.localPosition.z);
        float step = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, futureposition, step);
    }
    void change_angle(float going_to_x, float going_to_y)
    {
        float angle = Mathf.Atan2(this.transform.localPosition.y - going_to_y, this.transform.localPosition.x - going_to_x);
        float rotatechange = (angle / 1.6f + 1f) * 90f;
        this.transform.localEulerAngles = new Vector3(this.transform.localRotation.x, this.transform.localRotation.y, this.transform.localRotation.z + rotatechange);
    }
    float calculate_distance(float going_to_x, float going_to_y)
    {
        float totaldistancex = going_to_x - this.transform.localPosition.x;
        float totaldistancey = going_to_y - this.transform.localPosition.y;
        return totaldistancex * totaldistancex + totaldistancey * totaldistancey;
    }
    // Update is called once per frame
    void Update()
    {

        int findornot = 0;
        minimum_distance = 2500f;
        foreach (GameObject finder in controler)
        {
            if (finder == null)
                continue;

            totaldistancex = finder.transform.localPosition.x - this.transform.localPosition.x;
            totaldistancey = finder.transform.localPosition.y - this.transform.localPosition.y;
            float total = totaldistancex * totaldistancex + totaldistancey * totaldistancey;

            if (total < 25f && extra_damage_point != 0)
            {
                finder.GetComponent<catchbullet>().lifeall -= extra_damage_point;
                float radio = finder.GetComponent<catchbullet>().lifeall / finder.GetComponent<catchbullet>().maxlife;
                //    print("this radio " + radio);
                if (radio <= 0)
                {
                    finder.GetComponent<catchbullet>().release_supply();
                }
                finder.SendMessage("receivehp", radio, SendMessageOptions.DontRequireReceiver);
                if (finder != null)
                    Destroy(finder.gameObject);

                Destroy(this.gameObject);
            }

            if (total < minimum_distance)
            {
                minimum_distance = total;
                minumum_enemy = finder;
                findornot = 1;
            }
        }
        if (findornot == 1)
            futureposition = minumum_enemy.transform.position;
        float speed;
        if (findornot == 1)
            speed = 50f;
        else
        {
            speed = 50f;
            futureposition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 100f, this.transform.localPosition.z);
        }

        float step = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, futureposition, step);
        change_angle(futureposition.x, futureposition.y);

        if (this.transform.localPosition.y > 30f || this.transform.localPosition.y < -30f)
        {
            Destroy(this.gameObject);
        }

    }
}
