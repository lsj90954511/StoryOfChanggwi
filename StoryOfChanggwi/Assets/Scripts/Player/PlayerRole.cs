using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRole : MonoBehaviour
{
    public enum Role
    {
        changgui,
        woodman,
        bobusang,
        seonbi,
        monk,
        anagne
    }

    public Role role;
    private int roleNum;
    private string[] roleName = { "changgui", "woodman", "bobusang", "seonbi", "monk", "anagne" };



    [SerializeField] private Sprite[] rSprite;
    [SerializeField] private Animator[] rAnimator;
    [SerializeField] private SpriteRenderer sRenderer;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if((int)role != roleNum)
        {
            RoleSetting();
        }
    }

    public void ChangeRole(int _rNum)
    {
        role = (Role)_rNum;
        RoleSetting();
    }
    public void ChangeRole(Role _role)
    {
        role = _role;
        RoleSetting();
    }
    public void RoleSetting()
    {
        roleNum = (int)role;
        sRenderer.sprite = rSprite[roleNum];
        
        //var resourceName = "img/player motion/" + roleName[roleNum];
        //animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(resourceName);

    }
}
