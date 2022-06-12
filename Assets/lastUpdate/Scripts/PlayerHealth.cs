
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer healthBar;
    public float health = 100f;
    public float repeatDamagePeriod = 2f;//无敌时间
    public float hurtForce = 10f;
    public float damageAmount = 10f;
    public AudioClip[] ouches;
    public AudioSource audioSource;
    private float lastHitTime;
    private Vector3 healthScale;
    private HeroController playerControl;
    private Animator anim;
    void Awake()
    {
        playerControl = GetComponent<HeroController>();
        healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        healthScale = healthBar.transform.localScale;
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //可以再次减血
            if (Time.time > lastHitTime + repeatDamagePeriod)
            {
                if (health > 0f)
                {
                    TakeDamage(col.transform);
                    lastHitTime = Time.time;
                }
               
            }
        }
    }
    public void death()
    {
        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }

        SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in spr)
        {
            s.sortingLayerName = "UI";
        }

        //GetComponent<PlayerCtrl>().enabled = false;
        playerControl.enabled = false;//不能再向角色输入指令
        GetComponentInChildren<Gun>().enabled = false;
        anim.SetTrigger("Die");

        //销毁血条
        GameObject go = GameObject.Find("Blood");
        Destroy(go);
        StartCoroutine("ReloadGame");
    }
    void TakeDamage(Transform enemy)
    {
        
        int i = Random.Range(0, ouches.Length);
        audioSource.PlayOneShot(ouches[i]);
        playerControl.bJump = false;
        Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 10f;
        GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);
        health -= damageAmount;
        if (health <= 0)
        {
            death();
            return;//死亡之后不必再更新血条
        }
           
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1.5f, 1);
    }
    IEnumerator ReloadGame()
    {
        // ... pause briefly
        yield return new WaitForSeconds(2);
        // ... and then reload the level.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
