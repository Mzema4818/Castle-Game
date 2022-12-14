using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Axe : MonoBehaviour
{
    public float time = 5;
    private float initalTime;
    private float timeStore;
    private bool canClick;
    private float halfTime;
    public GameObject merchant;
    public GameObject builder;
    public GameObject menu;
    public GameObject secondCam;
    public GameObject inventory;
    public GameObject pauseMenu;
    public GameObject tool;
    public GameObject getTownName;
    public Animator animator;

    public GameObject wood;
    private TMP_Text woodText;
    private string woodValue;
    private int woodCalc;
    private int newWoodValue;

    private bool canHit;
    public GameObject particles;

    void Start()
    {
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;    //Get Animator controller
        for (int i = 0; i < ac.animationClips.Length; i++)                 //For all animations
        {
            if (ac.animationClips[i].name == "swing")        //If it has the same name as your clip
            {
                time = ac.animationClips[i].length;
            }
        }
        initalTime = time;
        timeStore = time;
        canClick = true;
        canHit = true;
    }

    private void Update()
    {
        woodText = wood.GetComponent<TMP_Text>();
        woodValue = woodText.text;
        woodCalc = int.Parse(woodValue);

        //clicking cooldown and animation
        if (Input.GetMouseButtonDown(0) && canClick && merchant.activeSelf == false && builder.activeSelf == false && menu.activeSelf == false && inventory.activeSelf == false && secondCam.activeSelf == false && pauseMenu.activeSelf == false && getTownName.activeSelf == false)
        {
            canClick = false;
        }
        if (!canClick)
        {
            time -= Time.deltaTime;
        }
        if (time < 0)
        {
            time = initalTime;
            canClick = true;
            canHit = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider myCollider = collision.GetContact(0).thisCollider;

        if(myCollider.name == "Cube" && canHit)
        {
            if (animator.GetCurrentAnimatorStateInfo(1).IsName("swing"))
            {
                if (collision.collider.gameObject.name.Contains("branch") || collision.collider.gameObject.name.Contains("leave"))
                {
                    canHit = false;
                    collision.transform.SendMessage("HitByRay");
                    newWoodValue = woodCalc + 1;
                    woodText.text = newWoodValue.ToString();

                    GameObject onHit = Instantiate(particles, collision.contacts[0].point, Quaternion.identity);
                    //onHit.transform.LookAt(gameObject.transform);
                    //ParticleSystem.MainModule settings = onHit.GetComponent<ParticleSystem>().main;
                    Renderer renderer = collision.collider.gameObject.GetComponent<Renderer>();

                    Renderer render = collision.collider.gameObject.GetComponent<Renderer>();
                    render.material.color = renderer.material.GetColor("_Tint");

                    //ParticleSystem newTmp = onHit.transform.GetChild(0).GetComponent<ParticleSystem>();
                    ParticleSystemRenderer rend = onHit.GetComponent<ParticleSystemRenderer>();
                    rend.material = render.material;

                    //settings.startColor = new ParticleSystem.MinMaxGradient(renderer.material.GetColor("_Tint"));
                    onHit.AddComponent<ParticalDestroy>();
                    onHit.GetComponent<ParticleSystem>().Play();
                }
            }
        }
    }
}