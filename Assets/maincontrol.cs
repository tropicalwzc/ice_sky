using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class maincontrol : MonoBehaviour
{
    // main scene control
    int normalnum = 1;
    long sander = 0;
    int speeder = 400;
    int score = 0;
    int gameovers = 0;
    int stratplay = 0;
    public Texture btnretry;
    public AudioClip AC;
    public GUIStyle gooder;
    public GameObject[] prefab = new GameObject[30];
    GameObject fogs;
    int proper_big_button_size;
    int proper_font_size;
    int proper_bar_height;
    int one = 0;
    // Use this for initialization
    void Start()
    {

    }
    void gameover(int news)
    {
        gameovers = news;
        if (stratplay == 0)
        {
            AudioSource.PlayClipAtPoint(AC, transform.localPosition);
            stratplay = 1;
        }

    }
    void destroysmall(int news)
    {
        score += news;
    }
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
        sander++;

        fogs = GameObject.FindGameObjectWithTag("enemy");

        if (gameovers == 1)
        {
            GameObject[] allbullet = GameObject.FindGameObjectsWithTag("enemy");

            foreach (GameObject finder in allbullet)
            {
                finder.SendMessage("receivehp", 0f, SendMessageOptions.DontRequireReceiver);
                Destroy(finder.gameObject);
            }
        }

        if (gameovers == 0)
            if (fogs == null || sander % speeder == speeder - 1)
            {
                if (speeder > 100)
                    speeder -= 3;

                normalnum = 0;
                if (score > 200)
                {
                    int roll = Random.Range(0, 5);
                    if (roll == 1)
                    {
                        if (score < 50000)
                            fogs = Instantiate(prefab[1]) as GameObject;
                        else
                        {
                            int goods = Random.Range(7, 9);
                            fogs = Instantiate(prefab[goods]) as GameObject;
                        }
                        fogs.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                    }
                }
                if (score > 2000)
                {
                    int roll = Random.Range(0, 5);
                    if (roll == 1)
                    {
                        if (score < 50000)
                            fogs = Instantiate(prefab[2]) as GameObject;
                        else
                        {
                            if (score < 150000)
                            {
                                fogs = Instantiate(prefab[14]) as GameObject;
                            }
                            else
                            {
                                if (score < 300000)
                                    fogs = Instantiate(prefab[13]) as GameObject;
                                else
                                {
                                    fogs = Instantiate(prefab[15]) as GameObject;
                                }
                            }
                        }

                        if (score < 150000)
                            fogs.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                        else
                        {
                            fogs.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, Random.Range(0, 40f) - 20f, -10f);
                        }
                    }
                }
                if (score > 400000)
                {
                    int roll = Random.Range(0, 10);
                    if (roll == 1)
                    {
                        fogs = Instantiate(prefab[20]) as GameObject;
                        fogs.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                    }

                }
                if (score > 5000)
                {
                    int roll = Random.Range(0, 5);
                    if (roll == 1)
                    {
                        if (score < 30000)
                            fogs = Instantiate(prefab[3]) as GameObject;
                        else
                        {
                            if (score < 100000)
                                fogs = Instantiate(prefab[10]) as GameObject;
                            else
                            {
                                if (score < 200000)
                                {
                                    fogs = Instantiate(prefab[9]) as GameObject;
                                }
                                else
                                {
                                    fogs = Instantiate(prefab[19]) as GameObject;
                                }

                            }
                        }
                        fogs.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                    }
                }
                if (score > 20000)
                {
                    int roll = Random.Range(0, 5);
                    if (roll == 1)
                    {
                        if (score < 120000)
                            fogs = Instantiate(prefab[5]) as GameObject;
                        else
                        {
                            fogs = Instantiate(prefab[12]) as GameObject;
                        }
                        fogs.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                    }
                }
                if (score > 40000)
                {
                    int roll = Random.Range(0, 5);
                    if (roll == 1)
                    {
                        if (score < 150000)
                        {
                            fogs = Instantiate(prefab[4]) as GameObject;
                        }
                        else
                        {
                            if (score < 300000)
                            {
                                fogs = Instantiate(prefab[11]) as GameObject;
                            }
                            else
                            {
                                fogs = Instantiate(prefab[17]) as GameObject;
                            }

                        }

                        fogs.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                    }
                }

                if (score > 100000)
                {
                    int roll = Random.Range(0, 10);
                    if (roll == 1)
                    {
                        fogs = Instantiate(prefab[6]) as GameObject;
                        fogs.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                    }
                    if (roll == 2)
                    {
                        fogs = Instantiate(prefab[16]) as GameObject;
                        fogs.transform.localPosition = new Vector3(-25f, Random.Range(0, 24), -10f);
                    }
                }
                if (score < 40000)
                {
                    fogs = Instantiate(prefab[0]) as GameObject;
                }
                else
                {
                    int togos = Random.Range(0, 2);
                    if (togos == 1)
                        fogs = Instantiate(prefab[7]) as GameObject;
                    else
                    {
                        fogs = Instantiate(prefab[8]) as GameObject;
                    }
                }

                int placing = Random.Range(0, 40);
                fogs.transform.localPosition = new Vector3((float)placing - 20f, 24f, -10f);
                fogs.name = "enemyplane";
                normalnum++;
            }

    }
    void OnGUI()
    {
        GUI.skin.label.fontSize = proper_font_size;

        GUI.skin.label.normal.textColor = new Vector4(0.75f, 0.74f, 0.95f, 1.0f);
        GUI.Label(new Rect(5, Screen.height - proper_big_button_size - proper_bar_height, Screen.width / 4, proper_bar_height), "总分   " + score);
        if (gameovers == 1)
        {

            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "你的飞机" + "在得了" + score + "分之后好像消失了 ");

            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 3 * 2, proper_big_button_size * 2, proper_big_button_size * 2), btnretry, gooder) || Input.GetKeyDown(KeyCode.R))
            {
                sander = 0;
                SceneManager.LoadScene("planes");
            }

        }
    }
}
