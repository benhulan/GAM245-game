using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class PointsAwarded : MonoBehaviour {

	public PointAwardedScreen[] m_possiblePoints = null;
    public CardManager cm;
    
    public void Start(){
        
        GameObject pointsAwardedManager = GameObject.FindWithTag("circle");
        CardManager cm = pointsAwardedManager.GetComponent<CardManager>();
        
        // PointAwardedScreen points = m_possiblePoits;
        
        GameObject.Find("Points Awarded Text Box").GetComponent<Text>().text = cm.pointsAwarded.ToString();
        Debug.Log(cm.pointsAwarded);
    }
}
