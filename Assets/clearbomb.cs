using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// clear all bullets from enemy but the small plane crash damage is still available
public class clearbomb : MonoBehaviour
{
    GameObject[] controler;
    GameObject finder;
    public AudioClip AC;
    public AudioClip BC;
    float toangle = 0;
    public int clear_all_bullet = 0;
    public int clear_all_enemy_plane = 0;
    public int clear_all_player_bullet = 0;

    public int rotate = 0;
    public float speed = 30;
    // Use this for initialization
    void Start()
    {

    }
    void bomb()
    {
        controler = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject finder in controler)
        {
            finder.SendMessage("receivehp", 0, SendMessageOptions.DontRequireReceiver);
            Destroy(finder.gameObject);
        }
    }
    void total_clear_bullets()
    {
        GameObject[] allbullet;
        if (clear_all_player_bullet == 0)
            allbullet = GameObject.FindGameObjectsWithTag("enemybullet");
        else
        {
            allbullet = GameObject.FindGameObjectsWithTag("playerbullet");
        }
        foreach (GameObject finder in allbullet)
        {
            finder.SendMessage("receivehp", 0, SendMessageOptions.DontRequireReceiver);
            Destroy(finder.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (rotate != 0)
        {
            Vector3 futureposition = new Vector3(this.transform.position.x, 300f, -9f);
            float step = speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, futureposition, step);

            float rotatechange = (rotate / 1.6f + 1f) * 90f;
            toangle += rotatechange;
            this.transform.localEulerAngles = new Vector3(0f, 0f, toangle);

            if (this.transform.position.y > 50f)
            {
                Destroy(this.gameObject);
            }

        }
        if (clear_all_enemy_plane == 1)
            bomb();
        if (clear_all_bullet == 1)
            total_clear_bullets();
    }



}
