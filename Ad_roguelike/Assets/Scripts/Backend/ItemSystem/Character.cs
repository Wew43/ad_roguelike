using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{
    public Item.Rarity TestRarity;
    public List<Item> items = new List<Item>();
    public float TesttimeMultiplier = 1;
    public float sliderPos = 1;
    public int Health = 50, MaxHealth = 50;
    public float MultLeft = 1f, MultRight = 1f;
    void Start()
    {
        RecreateItems();
        FirstTimeForItems();
        StartCoroutine(DamageTimer());
    }
    public void PlusMults(float left, float right)
    {
        MultLeft += left;
        MultRight += right;

        if(MultLeft <= 0)
        {
            MultLeft = 0.000001f;
        }
        if (MultRight <= 0)
        {
            MultRight = 0.000001f;
        }
    }
    void RecreateItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null)
            {
                Item.Rarity r = TestRarity;
                if (items[i].ItemType != null)
                {
                    r = items[i].ItemType.GetRarity();
                }
                items[i] = Instantiate(items[i]);
                items[i].SetInventory(this);
                items[i].SetFunctional(r);
            }
        }
    }
    void FirstTimeForItems()
    {
        foreach (Item item in items)
        {
            OnFirstTime(item);
        }
    }
    void Update()
    {
        if (Health > MaxHealth) Health = MaxHealth;
        if (ad != null)
        {
            ad.TimerSecondsText.text = time.ToString("0");
            ad.Duration.value = time;
            ad.Duration.maxValue = endTime;
            ad.M1Text.text = MultLeft.ToString("0.00");
            ad.M2Text.text = MultRight.ToString("0.00");
            ad.hp.value = Health;
            ad.hp.maxValue = MaxHealth;
            ad.MaxHp.text = MaxHealth.ToString();
            ad.DurationTime.text = endTime.ToString();
            
        }


        foreach (Item item in items)
        {
            item.ItemType.OnEachFrame();
        }

    }



    float time = 0, endTime = 0;
    Ad ad = null;



    bool canBeDamaged = true;
    bool endlessTimer = true;
    public void StartTimer(Ad _ad, float Duration)
    {
        if (ad == null)
        {
            ad = _ad;
            endTime = Duration;
            StartCoroutine(Timer());
        }
    }

    public void AddItem(Item item, Item.Rarity rarity)
    {
        items.Add(Instantiate(item));
        items[items.Count - 1].SetInventory(this);
        items[items.Count - 1].SetFunctional(rarity);
        OnFirstTime(item);
    }

    public void SkipTimeByDurationAndPlace(float duration, string place)
    {
        if(place == "start")
        {
            time += duration;
        }
        else if(place == "end")
        {
            endTime -= duration; 
        }
        else
        {

        }
    }
    public void SkipTimeByPercentAndPlace(float percent, string place)
    {
        if (place == "start")
        {
            time += endTime * percent;
        }
        else if (place == "end")
        {
            endTime -= endTime * percent;
        }
        else
        {

        }
    }
    IEnumerator Timer()
    {
        canBeDamaged = true;
        OnAdStarts();
        while (time < endTime)
        {
            if (time < endTime / 2)
            {
                yield return new WaitForSeconds(1f * TesttimeMultiplier / MultLeft);
                time += 1f * TesttimeMultiplier;
            }
            else
            {
                yield return new WaitForSeconds(1f * TesttimeMultiplier / MultRight);
                time += 1f * TesttimeMultiplier;
            }
            OnEachSec();
        }
        canBeDamaged = false;
        OnFightEnd();
        time = 0;
        ad.transform.parent.parent.GetComponent<Window>().CloseWindow();
        ad = null;
    }


    IEnumerator DamageTimer()
    {
        while (endlessTimer)
        {
            if (canBeDamaged)
            {
                yield return new WaitForSeconds(1);
                Health -= 1;
            }
            else
            {
                yield return null;
            }
        }
        
    }









    public void OnEachSec()
    {
        foreach (Item item in items) 
        {
            item.ItemType.OnEachSec();
        }
    }
    public void OnFightEnd()
    {
        foreach (Item item in items)
        {
            item.ItemType.OnFightEnd();
        }
    }
    public void OnFirstTime(Item item)
    {
        item.ItemType.Init();
    }
    public void OnRoomEnter()
    {
        foreach (Item item in items)
        {
            item.ItemType.OnRoomEntry();
        }
    }
    public void OnAdStarts()
    {
        foreach (Item item in items)
        {
            item.ItemType.OnAdStart();
        }
    }

    
}
