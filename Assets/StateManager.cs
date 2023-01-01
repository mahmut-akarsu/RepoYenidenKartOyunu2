using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public bool isPlayerTurn = true;

    public TextMeshProUGUI playerGold;

    public void EndPlayerTurn()
    {
        if (isPlayerTurn) { isPlayerTurn = false; }
        else { return; }
        playerGold.text = (int.Parse(playerGold.text) + 4 ).ToString();
    }
    public void EndEnemyTurn()
    {
        if (isPlayerTurn) { return; }
        else { isPlayerTurn = true; }
        //playerGold.text = (int.Parse(playerGold.text) + 4).ToString();
    }

    public bool Attack(Interactive attacker)
    {
        if (attacker.range + attacker.CardLine <= 0) { print("menzil yetersiz"); return false; }
        if (attacker.CompareTag("Enemy")) { return true; }
        if (int.Parse(playerGold.text) < int.Parse(attacker.cost.text)) 
        {
            //TODO : Saldırmak için yeterli cephane yok uyarısı
            print("cephane yetersiz");
            return false;
        }
        playerGold.text = (int.Parse(playerGold.text) - int.Parse(attacker.cost.text)).ToString();
        return true;
    }

    
    public bool PlayCard(Interactive playedCard)
    {
        if (isPlayerTurn && !playedCard.isPlayed)
        {
            //Kartın ücretinin oynamasına engel olup olmadığını kontrol eder

            {
                if (int.Parse(playerGold.text) < int.Parse(playedCard.cost.text))
                {
                    //TODO : Hareket etmek için yeterli cephane yok uyarısı
                    return false;
                }
                playedCard.isPlayed= true;
                playerGold.text = (int.Parse(playerGold.text) - int.Parse(playedCard.cost.text)).ToString();
                return true;
            }
        }
        return false;
    }
    public bool MoveCard(Interactive movedCard)
    {
        if (movedCard.tag == "Enemy") { return true; }
        if (int.Parse(playerGold.text) < int.Parse(movedCard.cost.text)) { return false; }
        playerGold.text = (int.Parse(playerGold.text) - int.Parse(movedCard.cost.text)).ToString();
        return true;

    }

    private void Start()
    {
        
    }
}
