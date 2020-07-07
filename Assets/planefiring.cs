using UnityEngine;
using System.Collections;
// the important controller for player firing
public class planefiring : MonoBehaviour
{
    public GameObject[] prefab = new GameObject[10];
    public AudioClip AC, BC, CC, DC, EC;
    public int allow_color_change = 1;
    public int allow_angle_change = 1;
    public int allow_light_change = 1;
    public int score_decide_weapon_level = 1;
    public int damage_mission_number = 0;
    public int flee_mission_number = 0;
    public int light_mode = 0;
    public int update_mission_supply = 1;
    GameObject fire, obj, finder, enemyshocker;
    int sander;
    int heat;
    int upaim = 2000;
    public int lowest_weapon_update = 1;
    int air_weapon_update = 1;

    public int weaponlevel = 0;
    public int armon = 0;
    int max_armon = 1;
    int weaponupdate = 1;
    public int score = 0;
    int temp;
    int proper_big_button_size;
    int proper_font_size;
    int proper_bar_height;
    int one = 0;
    // Use this for initialization
    void Start()
    {
        if (lowest_weapon_update > air_weapon_update)
            air_weapon_update = lowest_weapon_update;

        sander = 0;
        heat = 5;
    }
    void destroysmall(int news)
    {
        score += news;
    }
    void Supply(int news)
    {
        if (weaponlevel == -1)
            return;

        if (news >= 1 && news <= 4)
        {
            if (weaponlevel == news)
            {
                if (weaponupdate < 6)
                    weaponupdate++;
            }
            else
            {
                weaponupdate = lowest_weapon_update;
            }
        }
        switch (news)
        {
            case 1:
                armon = 400 + weaponupdate * (200 + weaponupdate * 20);
                break;
            case 2:
                armon = 500 + weaponupdate * (250 + weaponupdate * 25);
                break;
            case 3:
                armon = 1000 + weaponupdate * (500 + weaponupdate * 50);
                break;
            case 4:
                armon = 300 + weaponupdate * (150 + weaponupdate * 15);
                break;
            case 5:
                damage_mission_number += 3;
                break;
            case 6:
                flee_mission_number++;
                break;
        }
        if (news >= 1 && news <= 4)
        {
            weaponlevel = news;
            max_armon = armon;
        }
    }
    char classer(int checknum)
    {
        switch (checknum)
        {
            case 1: return 'E';
            case 2: return 'D';
            case 3: return 'C';
            case 4: return 'B';
            case 5: return 'A';
            case 6: return 'S';
        }
        return 'N';
    }
    int last_weapon_level;
    int being_robbed = 0;
    // Update is called once per frame
    void Update()
    {

        if (one == 0)
        {
            proper_font_size = this.GetComponent<proper_ui>().proper_font_size;
            proper_big_button_size = this.GetComponent<proper_ui>().proper_big_button;
            proper_bar_height = this.GetComponent<proper_ui>().proper_bar_height;
            one = 1;
        }

        if (lowest_weapon_update > weaponupdate)
            weaponupdate = lowest_weapon_update;
        if (lowest_weapon_update > air_weapon_update)
            air_weapon_update = lowest_weapon_update;

        enemyshocker = GameObject.FindWithTag("weapon_n_bullet");
        if (enemyshocker != null)
        {
            if (being_robbed == 0)
            {
                last_weapon_level = weaponlevel;
                weaponlevel = -1;
                being_robbed = 1;
            }
        }
        else
        {
            if (being_robbed == 1)
            {
                being_robbed = 0;
                weaponlevel = last_weapon_level;
            }
        }
        sander++;
        if (score > upaim - 1)
        {
            if (score_decide_weapon_level == 1)
                lowest_weapon_update++;
            GameObject backing = GameObject.FindGameObjectWithTag("background_c");
            if (backing != null)
            {
                if (allow_color_change == 1)
                {
                    float goof_a = Random.Range(1f, 255f);
                    float goof_b = Random.Range(1f, 255f);
                    float goof_c = Random.Range(1f, 255f);
                    float goof_d = Random.Range(220f, 245f);
                    backing.GetComponent<Renderer>().material.color = new Vector4(goof_a / 255f, goof_b / 255f, goof_c / 255f, goof_d / 255f);
                }
            }

            if (allow_angle_change == 1)
            {
                GameObject backer_rotate = GameObject.FindGameObjectWithTag("background");
                if (backer_rotate != null)
                {
                    Vector3 fromrotate = new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), Random.Range(0, 180));
                    backer_rotate.transform.localEulerAngles = fromrotate;
                }
            }

            finder = GameObject.Find("Directional Light");
            if (finder != null && allow_light_change == 1)
            {
                //print("find directional light");
                Vector3 fromrotate = new Vector3(Random.Range(190f, 350f), -30f, 0);
                finder.transform.localEulerAngles = fromrotate;
            }
            if (lowest_weapon_update <= 3)
                upaim *= 5;
            if (lowest_weapon_update >= 4)
                upaim += 100000;

            if (lowest_weapon_update > 4)
            {
                if (score < 250000)
                    lowest_weapon_update = 4;
                else
                {
                    if (lowest_weapon_update > 5)
                        lowest_weapon_update = 5;
                }
                air_weapon_update++;
                if (air_weapon_update > 6)
                    air_weapon_update = 6;
            }
            else
            {
                air_weapon_update = lowest_weapon_update;
            }

        }
        if (armon <= 0 && weaponlevel != -1)
            weaponlevel = 0;
    }
    void OnGUI()
    {
        Rect weapontext_pos = new Rect(5, Screen.height - proper_bar_height * 2 - proper_big_button_size, Screen.width / 4, proper_bar_height);
        Rect mission_text_pos = new Rect(5, Screen.height - proper_bar_height * 5 - proper_big_button_size, Screen.width / 4, proper_bar_height);

        GUI.skin.label.fontSize = proper_font_size;
        GUI.skin.label.normal.textColor = new Vector4(0.8f, 0.4f, 0.3f, 1.0f);

        if (weaponlevel >= 0)
        {
            if (light_mode == 0)
                GUI.Label(mission_text_pos, "导弹 " + damage_mission_number + "  脉冲弹 " + flee_mission_number + "");
            else
            {
                GUI.Label(mission_text_pos, "照明弹 无限");
            }
        }
        else
        {
            GUI.Label(mission_text_pos, "导弹系统连接失败");
        }


        switch (weaponlevel)
        {
            case 0:
                GUI.skin.label.normal.textColor = new Vector4(0.5f, 0.5f, 0.5f, 1.0f);
                GUI.Label(weapontext_pos, "" + classer(air_weapon_update) + "级空气弹  ");
                break;
            case 1:
                GUI.skin.label.normal.textColor = new Vector4(68f / 255f, 121f / 255f, 223f / 255f, 1.0f);
                GUI.Label(weapontext_pos, "" + classer(weaponupdate) + "级分叉弹   " + 100 * armon / max_armon + "%");
                break;
            case 2:
                GUI.skin.label.normal.textColor = new Vector4(121f / 255f, 151f / 255f, 185f / 255f, 1f);
                GUI.Label(weapontext_pos, "" + classer(weaponupdate) + "级随机弹   " + 100 * armon / max_armon + "%");
                break;
            case 3:
                GUI.skin.label.normal.textColor = new Vector4(174f / 255f, 223f / 255f, 159f / 255f, 1.0f);
                GUI.Label(weapontext_pos, "" + classer(weaponupdate) + "级疾速弹   " + 100 * armon / max_armon + "%");
                break;
            case 4:
                GUI.skin.label.normal.textColor = new Vector4(1f, 191f / 255f, 76f / 255f, 1.0f);
                GUI.Label(weapontext_pos, "" + classer(weaponupdate) + "级跟踪弹   " + 100 * armon / max_armon + "%");
                break;
            default:
                GUI.Label(weapontext_pos, "火控系统连接失败");
                break;
        }
        if (((Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.D)) && sander > 20 && (damage_mission_number > 0 || light_mode == 1)) && weaponlevel != -1)
        {
            damage_mission_number--;
            sander = 0;
            obj = Instantiate(prefab[9]) as GameObject;
            obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
        }
        if (((Input.GetMouseButton(2) || Input.GetKeyDown(KeyCode.C)) && sander > 20 && flee_mission_number > 0 && light_mode == 0) && weaponlevel != -1)
        {
            flee_mission_number--;
            sander = 0;
            obj = Instantiate(prefab[8]) as GameObject;
            obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
        }
        if ((Input.GetMouseButton(0) && sander > heat || Input.GetButtonDown("Fire1") && sander > heat) && weaponlevel != -1)
        {

            sander = 0;
            switch (weaponlevel)
            {
                case 0://空气弹设置
                    heat = 5;

                    AudioSource.PlayClipAtPoint(BC, transform.localPosition);
                    switch (air_weapon_update)
                    {
                        case 1:
                            heat = 5;
                            obj = Instantiate(prefab[0]) as GameObject;
                            obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            break;
                        case 2:
                            heat = 4;
                            obj = Instantiate(prefab[0]) as GameObject;
                            obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            break;
                        case 3:
                            heat = 4;
                            obj = Instantiate(prefab[0]) as GameObject;
                            obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 1f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            obj = Instantiate(prefab[0]) as GameObject;
                            obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 1f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            break;
                        case 4:
                            heat = 3;
                            for (int i = 0; i < 3; i++)
                            {
                                obj = Instantiate(prefab[0]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 1f + (float)i, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 5:
                            heat = 2;
                            for (int i = 0; i < 3; i++)
                            {
                                obj = Instantiate(prefab[0]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 0.6f + 0.6f * (float)i, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 6:
                            heat = 0;
                            for (int i = 0; i < 2; i++)
                            {
                                obj = Instantiate(prefab[0]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 0.1f + 0.2f * (float)i, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                    }

                    break;

                case 1://分叉弹设置
                    heat = 5;
                    AudioSource.PlayClipAtPoint(DC, transform.localPosition);

                    switch (weaponupdate)
                    {
                        case 1:
                            heat = 5;
                            armon -= 3;
                            for (int i = 0; i < 3; i++)
                            {
                                obj = Instantiate(prefab[i]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 2:
                            heat = 4;
                            armon -= 3;
                            for (int i = 0; i < 3; i++)
                            {
                                obj = Instantiate(prefab[i]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 3:
                            heat = 4;
                            armon -= 5;
                            for (int i = 0; i < 2; i++)
                            {
                                if (i == 0)
                                {
                                    obj = Instantiate(prefab[0]) as GameObject;
                                    obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                                }

                                for (int j = 0; j < 2; j++)
                                {
                                    obj = Instantiate(prefab[1 + i + j * 5]) as GameObject;
                                    obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                                }
                            }
                            break;
                        case 4:
                            heat = 3;
                            armon -= 6;
                            for (int i = 0; i < 2; i++)
                            {
                                obj = Instantiate(prefab[0]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                                for (int j = 0; j < 2; j++)
                                {
                                    obj = Instantiate(prefab[1 + i + j * 5]) as GameObject;
                                    obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                                }
                            }

                            break;
                        case 5:
                            heat = 2;
                            armon -= 10;
                            for (int i = 0; i < 2; i++)
                            {
                                obj = Instantiate(prefab[0]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 0.3f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                                obj = Instantiate(prefab[6]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 0.6f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                                obj = Instantiate(prefab[7]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 0.6f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                                obj = Instantiate(prefab[1]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 0.8f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                                obj = Instantiate(prefab[2]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 0.8f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 6:
                            heat = 2;
                            armon -= 15;
                            for (int i = 0; i < 3; i++)
                            {
                                obj = Instantiate(prefab[0]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 0.3f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                                obj = Instantiate(prefab[6]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 0.6f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                                obj = Instantiate(prefab[7]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 0.6f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                                obj = Instantiate(prefab[1]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 0.8f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                                obj = Instantiate(prefab[2]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 0.8f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                    }
                    break;

                case 2://随机弹设置
                    heat = 5;

                    AudioSource.PlayClipAtPoint(CC, transform.localPosition);
                    switch (weaponupdate)
                    {
                        case 1:
                            heat = 5;
                            armon -= 3;
                            for (int i = 0; i < 3; i++)
                            {
                                obj = Instantiate(prefab[3]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 2:
                            heat = 4;
                            armon -= 3;
                            for (int i = 0; i < 3; i++)
                            {
                                obj = Instantiate(prefab[3]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 3:
                            heat = 3;
                            armon -= 5;
                            for (int i = 0; i < 5; i++)
                            {
                                obj = Instantiate(prefab[3]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 4:
                            heat = 3;
                            armon -= 7;
                            for (int i = 0; i < 7; i++)
                            {
                                obj = Instantiate(prefab[3]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 5:
                            heat = 2;
                            armon -= 7;
                            for (int i = 0; i < 7; i++)
                            {
                                obj = Instantiate(prefab[3]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 6:
                            heat = 2;
                            armon -= 10;
                            for (int i = 0; i < 10; i++)
                            {
                                obj = Instantiate(prefab[3]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                    }
                    break;

                case 3://疾速弹设置
                    heat = 2;
                    armon--;
                    AudioSource.PlayClipAtPoint(EC, transform.localPosition);
                    switch (weaponupdate)
                    {
                        case 1:
                            obj = Instantiate(prefab[4]) as GameObject;
                            obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            break;
                        case 2:
                            obj = Instantiate(prefab[4]) as GameObject;
                            heat = 1;
                            obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            break;
                        case 3:
                            armon -= 2;
                            heat = 1;
                            obj = Instantiate(prefab[4]) as GameObject;
                            obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 0.5f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            obj = Instantiate(prefab[4]) as GameObject;
                            obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 0.5f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            break;
                        case 4:
                            armon -= 3;
                            heat = 1;
                            for (int i = 0; i < 3; i++)
                            {
                                obj = Instantiate(prefab[4]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + (1 - (float)i), this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 5:
                            armon -= 3;
                            heat = 0;
                            for (int i = 0; i < 3; i++)
                            {
                                obj = Instantiate(prefab[4]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + (1 - (float)i), this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 6:
                            armon -= 5;
                            heat = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                obj = Instantiate(prefab[4]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + (2 - (float)i) * 0.5f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                    }
                    break;
                case 4://跟踪弹设置
                    heat = 5;

                    AudioSource.PlayClipAtPoint(AC, transform.localPosition);
                    switch (weaponupdate)
                    {
                        case 1:
                            armon--;
                            obj = Instantiate(prefab[5]) as GameObject;
                            obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            break;
                        case 2:
                            obj = Instantiate(prefab[5]) as GameObject;
                            heat = 3;
                            armon--;
                            obj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            break;
                        case 3:

                            heat = 3;
                            armon -= 2;
                            obj = Instantiate(prefab[5]) as GameObject;
                            obj.transform.localPosition = new Vector3(this.transform.localPosition.x - 1f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            obj = Instantiate(prefab[5]) as GameObject;
                            obj.transform.localPosition = new Vector3(this.transform.localPosition.x + 1f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            break;
                        case 4:
                            armon -= 3;
                            heat = 3;
                            for (int i = 0; i < 3; i++)
                            {
                                obj = Instantiate(prefab[5]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + (1 - (float)i), this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                        case 5:
                            armon -= 3;
                            heat = 2;
                            for (int i = 0; i < 3; i++)
                            {
                                obj = Instantiate(prefab[5]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + (1 - (float)i), this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;

                        case 6:
                            armon -= 5;
                            heat = 2;
                            for (int i = 0; i < 5; i++)
                            {
                                obj = Instantiate(prefab[5]) as GameObject;
                                obj.transform.localPosition = new Vector3(this.transform.localPosition.x + (2 - (float)i) * 0.5f, this.transform.localPosition.y + 2f, this.transform.localPosition.z);
                            }
                            break;
                    }

                    break;
            }


        }

    }
}
