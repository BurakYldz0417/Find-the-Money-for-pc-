using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class game : MonoBehaviour
{
    public GameObject player, gold;
    public float speed = 0.05f, returnspeed = 0.4f;
    public AudioClip sensorsound;
    AudioSource source;
    public int goldcounter=0;
    public int maxgoldcounter;
    int zpos, xpos;
    public int score=0;
    int income;
    public TextMeshProUGUI scoretext;
    public GameObject UpgradePanleobject,menupanelobject;
    public int upgradecounterprice=50, upgradegoldtypeprice =50;

    void Start()
    {
        source = GetComponent<AudioSource>();
        UpgradePanleobject.SetActive(false);
        menupanelobject.SetActive(false);
        goldcupnterfonk();
        maxgoldcounter = 5;
        income = 10;
        scoretext.text = score + " $";


    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(0, 0, 1 * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(0, 0, -1 * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(Vector3.down * returnspeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(Vector3.up * returnspeed);
        }

      


    }
    public void goldcupnterfonk()
    {
        while (goldcounter <= maxgoldcounter)
        {
            goldcounter++;
            zpos = Random.Range(-40, 35);
            xpos = Random.Range(-40, 40);

            goldcreat();
        }
    }
    void goldcreat()
    {
        Instantiate(gold, new Vector3(xpos, 0, zpos), Quaternion.identity);
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "gold")
        {
            source.Play();
            score += income;
            scoretext.text = score+" $";
            goldcounter -= 1;
            goldcupnterfonk();


        }
        if (collision.gameObject.tag == "rerty")
        {
            player.transform.position = new Vector3(0, 0, 0);
            score -= 20;
            scoretext.text = score + " $";
        }
    }
    public void upgradePanle()
    {
        UpgradePanleobject.SetActive(true);
        speed = 0;
        returnspeed = 0;
    }
    public void menupanel()
    {
        menupanelobject.SetActive(true);
        speed = 0;
        returnspeed = 0;
    }
    public void upgradecounter()
    {
        if(score>=upgradecounterprice)
        {
            maxgoldcounter +=1;
            upgradecounterprice += 50;
        }
    }
    public void upgradegoldtype()
    {
        if(score>=upgradegoldtypeprice)
        {
            income += 10;
            upgradegoldtypeprice += 50;
        }

    }
    public void upgradeclose()
    {
        UpgradePanleobject.SetActive(false);
        speed = 0.02f;
        returnspeed = 0.2f;
    }
    public void menuquit()
    {
        Application.Quit();
    }
    public void menurerty()
    {
        SceneManager.LoadScene(0);
    }
    public void menuclose()
    {
        menupanelobject.SetActive(false);
        speed = 0.02f;
        returnspeed = 0.2f;
    }
   
    
}


