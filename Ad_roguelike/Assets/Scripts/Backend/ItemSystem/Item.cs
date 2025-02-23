using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "baseItem")]
public class Item : ScriptableObject
{
    public Character character;
    public string itemName;
    public Sprite icon, largeIcon;
    public string[] descriptions;
    public Functional functional;
    public Item ItemType;


    public enum Rarity
    {
        common,
        uncommon,
        rare,
        special
    }
    public enum Functional //Добавлять для каждого предмета!!!!!
    {
        Cuprum,
        Pen
    }
    public void SetFunctional(Rarity r) //Добавлять для каждого предмета!!!!!
    {
        switch (functional)
        {
            case Functional.Cuprum:
                ItemType = Item.CreateInstance<Cuprum>();
                ItemType.SetRarity(r);
                break;
            case Functional.Pen:
                ItemType = Item.CreateInstance<Pen>();
                ItemType.SetRarity(r);
                break;
        }
    }
    public void SetCharacter()
    {
        character = Camera.main.GetComponent<Character>();
    }
    public void SetInventory(Character _inventory)
    {
        character = _inventory;
    }
    public virtual void SetRarity(Rarity r) { }
    public virtual Rarity GetRarity() { return 0; }
    public virtual void OnActiveArtUsed() { Debug.LogWarning("Non-realised"); } //нет инструментов для реализации
    public virtual void Init() { } //реализовано
    public virtual void OnAdStart() {  } //реализовано
    public virtual void OnEachSec() {  } //реализовано
    public virtual void OnRoomEntry() {  } //реализовано
    public virtual void OnFightEnd() {  } //реализовано
    public virtual void OnEachFrame() {  } //реализовано
    //Debug.LogWarning("You're trying to use empty method, or there's no override");
}
