using UnityEngine;
using System.Collections;
// enemy damage system control
public class catchbullet : MonoBehaviour
{

    public int lifeall;
    public int maxlife;
    public int supplypossible;
    public int totalsupply = 3;
    public int defeatscore = 50;
    public float catchrange = 7f;

    GameObject senders, supplys;
    public GameObject[] prefab = new GameObject[10];
    // Use this for initialization
    void Start()
    {
        maxlife = lifeall;
    }
    float totaldistancex;
    float totaldistancey;
    int cutout = 0;
    void extra_damage(int damage)
    {
        lifeall -= damage;
    }
    public void release_supply()
    {
        if (totalsupply >= 8)
        {

            int extra_d_mission = Random.Range(0, (supplypossible * 2));
            int extra_flee_mission = Random.Range(0, (supplypossible * 2));

            if (extra_d_mission == 1)
            {
                supplys = Instantiate(prefab[6]) as GameObject;
                supplys.transform.localPosition = this.transform.localPosition;
            }

            if (extra_flee_mission == 1)
            {
                supplys = Instantiate(prefab[7]) as GameObject;
                supplys.transform.localPosition = this.transform.localPosition;
            }

        }


        int poss = Random.Range(0, supplypossible);
        if (totalsupply >= 4)
        {
            if (poss == 2)
            {
                int mega_pack = Random.Range(0, 5);
                if (totalsupply >= 9 && mega_pack == 1)
                {
                    supplys = Instantiate(prefab[8]) as GameObject;
                }
                else
                {
                    supplys = Instantiate(prefab[3]) as GameObject;
                }

                supplys.transform.localPosition = this.transform.localPosition;
            }
        }
        if (totalsupply >= 5)
        {
            if (poss == 3)
            {
                supplys = Instantiate(prefab[4]) as GameObject;
                supplys.transform.localPosition = this.transform.localPosition;
            }
        }

        if (poss == 1)
        {
            int all = Random.Range(0, 3);
            int poschange = Random.Range(0, 3);
            if (totalsupply <= 5)
            {
                supplys = Instantiate(prefab[all]) as GameObject;
                supplys.transform.localPosition = this.transform.localPosition;
            }
            if (totalsupply >= 6)
            {
                if (poschange == 1)
                {
                    supplys = Instantiate(prefab[5]) as GameObject;
                    supplys.transform.localPosition = this.transform.localPosition;
                }
                else
                {
                    supplys = Instantiate(prefab[all]) as GameObject;
                    supplys.transform.localPosition = this.transform.localPosition;
                }
            }

        }

        senders = GameObject.FindGameObjectWithTag("MainCamera");
        senders.SendMessage("destroysmall", defeatscore, SendMessageOptions.DontRequireReceiver);
        senders = GameObject.FindGameObjectWithTag("Player");
        if (senders != null)
            senders.SendMessage("destroysmall", defeatscore, SendMessageOptions.DontRequireReceiver);
        Destroy(this.gameObject);
        lifeall = 10;
    }
    // Update is called once per frame
    void Update()
    {

        if (lifeall < maxlife / 3 && cutout == 0)
        {
            int firerate = this.GetComponent<enemyfiring>().firerate;
            this.GetComponent<enemyfiring>().firerate = firerate / 2;
            cutout = 1;
        }
        GameObject[] allbullet = GameObject.FindGameObjectsWithTag("playerbullet");

        foreach (GameObject finder in allbullet)
        {
            totaldistancex = finder.transform.localPosition.x - this.transform.localPosition.x;
            totaldistancey = finder.transform.localPosition.y - this.transform.localPosition.y;
            float total = totaldistancex * totaldistancex + totaldistancey * totaldistancey;
            if (total < catchrange)
            {
                Destroy(finder.gameObject);
                lifeall--;
                this.SendMessage("receivehp", (float)lifeall / (float)maxlife, SendMessageOptions.DontRequireReceiver);
            }
            if (lifeall < 1)
            {
                release_supply();
            }
        }

    }
}
