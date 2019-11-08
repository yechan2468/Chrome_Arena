using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Chrome 
public class Chrome
{
    private string chrome_Name;
    private int max_HP;

    private int [] feature = new int [5]; //레벨업 이후 캐릭터 특성을 선택할 때 사용


    public string name
    {
        get
        {
            return chrome_Name;
        }
        set
        {
            chrome_Name = name;
        }
    }


    //private로 감쌀 몇 개를 이런 식으로 넣어놓자

    public int HP { get; set; }
    public int level { get; set; }
    public int defend;
    public int jump_power;

    public string weapon;

    public Chrome()
    {
        max_HP = 100;
        defend = 0;
        jump_power = 10;
    }
    
}

public class Skill
{
    public int skill_Num;
    public int HP_damage;


    public Skill()
    {
        skill_Num = 0;
        HP_damage = 0;
    }
    
    protected virtual void effect()
    {
        //스킬마다 각자 다른 효과를 넣기
    }

}

public class Item
{
    public int battery_Num;
    public string battery_Type;
    public int HP_heal;

    public void get_Item(int battery_Num, string battery_Type, string chrome)
    {
        //배터리 소멸
        //캐릭터 스프라이트 호출
        //이펙트 호출

        if(battery_Type == "common")
        {
            //타이머 호출
        }

        else if(battery_Type == "special")
        {
            //캐릭터 능력치 업
        }
    }
}

public class Basic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
