using UnityEngine;
using System.Collections;
//This is the healthbar which exists in every plane in ice sky
public class healthbar : MonoBehaviour
{
    public GameObject[] prefab = new GameObject[2];
    GameObject HPTexture;//下图红色部分  
    GameObject backgroundOfHPTexture;//下图白色部分  
    public float percentOfHP = 1f;//血量百分比  
    public float healthbarlenth = 3f;
    public float bary = 2f;
    public float barx = -0.01f;
    public float barwidth = 0.1f;
    public int players_bar = 0;
    // Use this for initialization
    void Start()
    {

    }
    void receivehp(float news)
    {
        percentOfHP = news;
        if (news <= 0f)
        {
            if (HPTexture != null)
                Destroy(HPTexture.gameObject);
        }
        change_color(news);
    }
    void change_color(float percent)
    {
        if (percent > 0.5f)
        {
            if (HPTexture != null)
                HPTexture.GetComponent<Renderer>().material.color = new Vector4(86f / 255f, 140f / 255f, 59f / 255f, 1f);
        }
        if (percent > 0.25f && percentOfHP < 0.5f)
        {
            if (HPTexture != null)
                HPTexture.GetComponent<Renderer>().material.color = new Vector4(243f / 255f, 232f / 255f, 78f / 255f, 1f);
        }
        if (percent < 0.25f)
        {
            if (HPTexture != null)
                HPTexture.GetComponent<Renderer>().material.color = new Vector4(221f / 255f, 21f / 255f, 50f / 255f, 1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (percentOfHP > 0f)
        {

            if (HPTexture != null)
            {
                HPTexture.transform.localPosition = new Vector3(this.transform.localPosition.x + barx, this.transform.localPosition.y + bary, this.transform.localPosition.z + 0.4f);
                HPTexture.transform.localScale = new Vector3(healthbarlenth * percentOfHP, barwidth, 0.1f);
            }
            else
            {
                HPTexture = Instantiate(prefab[1]) as GameObject;
            }


            if (players_bar == 0)
                if (this.transform.position.y < -27 || this.transform.position.y > 40)
                    if (HPTexture != null)
                        Destroy(HPTexture.gameObject);

        }
        else
        {
            if (HPTexture != null)
                Destroy(HPTexture.gameObject);
        }



    }
}
