using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class level1 : MonoBehaviour
{

    public GameObject[] prefab = new GameObject[30];
    public Texture btnretry;
    public Texture menu;
    public GUIStyle gooder;
    public int total_life = 1;
    public int victory_scene_num = 6;
    int showorder = 0;
    GameObject bulletpack;
    GameObject enemynow;
    GameObject playerpl,finder;
    GameObject[] current_enemys = new GameObject[200];
    int current_enemy_total = 0;
    int score = 0;
    int timeslope = 0;
    int sander = 0;
    int gameovers = 0;
    // Use this for initialization
    int is_space_now()
    {
        if (current_enemy_total == 0)
            return 1;
        for(int i=0;i<current_enemy_total;i++)
        {
            if (current_enemys[i] != null)
                return 1;
        }
        return 0;
    }
    void Start()
    {

    }
    void destroysmall(int news)
    {
        score += news;
    }
    // Update is called once per frame
    void Update()
    {
        timeslope++;
        playerpl = GameObject.FindGameObjectWithTag("Player");
        if (playerpl == null)
        {
            total_life--;
            if(total_life<=0)
            {
                gameovers = 1;
            }
            else
            {
            playerpl = Instantiate(prefab[20]) as GameObject;
            playerpl.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 0f, -10f);
            playerpl.GetComponent<planefiring>().allow_color_change = 0;
            playerpl.GetComponent<planefiring>().allow_angle_change = 0;
            playerpl.GetComponent<planefiring>().allow_light_change = 0;
            }

        }
        else
        {
            playerpl.GetComponent<planefiring>().lowest_weapon_update = 1;
            playerpl.GetComponent<planefiring>().score = score;
        }
        if(gameovers==0)
        sander++;
                switch (showorder)
                {
                    case 0:

                if (current_enemy_total < 10 )
                {
                    if(timeslope>30)
                    {
                    timeslope = 0;
                    current_enemys[current_enemy_total] = Instantiate(prefab[0]) as GameObject;
                    current_enemys[current_enemy_total].transform.localPosition = new Vector3(Random.Range(0, 20f) - 10f, 24f, -10f);
                    current_enemy_total++;
                    }
                }
                else
                {
                    if(current_enemy_total<13 && timeslope>10)
                    {
                    current_enemys[current_enemy_total] = Instantiate(prefab[2]) as GameObject;
                    current_enemys[current_enemy_total].transform.localPosition = new Vector3(Random.Range(0, 20f) - 10f, 24f, -10f);
                    current_enemy_total++;
                    }

                }
                if (is_space_now() ==0)
                        {
                            current_enemy_total = 0;
                            showorder++;
                        }
                        break;
                    case 1:

                if(timeslope>10&&current_enemy_total==0)
                {
                current_enemys[current_enemy_total] = Instantiate(prefab[5]) as GameObject;
                current_enemys[current_enemy_total].transform.localPosition = new Vector3(Random.Range(0, 20f) - 10f, 24f, -10f);
                current_enemy_total++;
                }


                if (current_enemy_total < 100 && timeslope > 10)
                {
                    timeslope = 0;
                    current_enemys[current_enemy_total] = Instantiate(prefab[1]) as GameObject;
                    current_enemys[current_enemy_total].transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                    current_enemy_total++;
                }

                if (is_space_now() == 0)
                {
                    current_enemy_total = 0;
                    showorder++;
                }
                break;
            case 2:
                if (current_enemy_total < 10 && timeslope > 30)
                {
                    timeslope = 0;
                    current_enemys[current_enemy_total] = Instantiate(prefab[2]) as GameObject;
                    current_enemys[current_enemy_total].transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                    current_enemy_total++;
                }

                if (is_space_now() == 0)
                {
                    current_enemy_total = 0;
                    showorder++;
                }
                break;
            case 3:
                if (current_enemy_total < 20 && timeslope > 30)
                {
                    timeslope = 0;
                    current_enemys[current_enemy_total] = Instantiate(prefab[5]) as GameObject;
                    current_enemys[current_enemy_total].transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                    current_enemy_total++;
                }

                if (is_space_now() == 0)
                {
                    current_enemy_total = 0;
                    showorder++;
                }
                break;
            case 4:
                if (current_enemy_total < 20 && timeslope > 30)
                {
                    timeslope = 0;
                    current_enemys[current_enemy_total] = Instantiate(prefab[2]) as GameObject;
                    current_enemys[current_enemy_total].transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                    current_enemy_total++;
                }

                if (is_space_now() == 0)
                {
                    current_enemy_total = 0;
                    showorder++;
                }
                break;
            case 5:
                if (current_enemy_total < 100 && timeslope > 30)
                {
                    timeslope = 0;
                    current_enemys[current_enemy_total] = Instantiate(prefab[0]) as GameObject;
                    current_enemys[current_enemy_total].transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                    current_enemy_total++;
                    current_enemys[current_enemy_total] = Instantiate(prefab[1]) as GameObject;
                    current_enemys[current_enemy_total].transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                    current_enemy_total++;
                }

                if (is_space_now() == 0)
                {
                    current_enemy_total = 0;
                    showorder++;
                }
                break;
            case 6:
                 break;

                }


            

    }
    void OnGUI()
    {
        if(showorder==0)
        {
            GUI.skin.label.fontSize = 50;
            GUI.Label(new Rect(420f, 250f, 720f, 200f), "Level 1  菜鸡总动员");
            GUI.skin.label.fontSize = 25;
            GUI.Label(new Rect(420f, 450f, 720f, 200f), "小红,小黄,小绿虽然每次都被秒\n但是他们仨对不能入选大师空战愤愤不平,于是他们仨想在这里证明自己火力比大师级还猛\n所以请见多识广的蓝球机帮他们起了个霸气的名字'菜鸡总动员'\n他们仨对这个名字非常满意");
        }
        if(showorder>=victory_scene_num)
        {
            GUI.skin.label.fontSize = 30;
            GUI.Label(new Rect(420f, 250f, 720f, 200f), "恭喜过关");
            if (GUI.Button(new Rect(600f, 700f, 200f, 100f), menu, gooder) || Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("campaign");
            }
        }
        GUI.skin.label.fontSize = 20;
        GUI.skin.label.normal.textColor = new Vector4(0.75f, 0.74f, 0.95f, 1.0f);
        GUI.Label(new Rect(5, Screen.height - 100, (Screen.width - 150) / 4, 50f), "总分   " + score);
        if (gameovers == 1)
        {

            GUI.Label(new Rect(420f, 250f, 720f, 200f), "你的飞机" + "在得了" + score + "分之后好像消失了 ");

            if (GUI.Button(new Rect(600f, 400f, 200f, 200f), btnretry, gooder) || Input.GetKeyDown(KeyCode.R))
            {
                sander = 0;
                SceneManager.LoadScene("Level1");
                //Application.LoadLevel("level1");
            }

        }
    }
}
