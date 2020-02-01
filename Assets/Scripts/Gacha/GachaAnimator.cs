﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaAnimator : MonoBehaviour
{
    [SerializeField]
    private Transform initialBackground;

    [SerializeField]
    private GameObject panelR;
    [SerializeField]
    private GameObject panelSR;
    [SerializeField]
    private GameObject panelUR;

    [SerializeField]
    private float moveSpeedInitial = 50f;
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float zoomInSpeed = 30f;
    [SerializeField]
    private float zoomOutSpeed = 20f;
    [SerializeField]
    private Transform zoomPoint;

    [SerializeField]
    private GameObject gachaButton;

    private Vector3 initialPanelScale;
    private Transform currentPanel;

    // Start is called before the first frame update
    void Start()
    {
        panelR.SetActive(false);
        panelSR.SetActive(false);
        panelUR.SetActive(false);
        gachaButton.SetActive(false);

        currentPanel = initialBackground.transform;
        initialPanelScale = panelR.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGachaSequence(BasePart.RARITY rarity)
    {
        gachaButton.SetActive(false);
        initialBackground.GetComponent<MoveBackground>().StopMove();
        StartCoroutine(AnimSequence(rarity));
    }

    private IEnumerator AnimSequence(BasePart.RARITY rarity)
    {
        /*float panTime = 0f;
        while (panTime <= 1.5f)
        {
            panTime += Time.deltaTime;
            // move
            initialBackground.transform.position -= new Vector3(moveSpeedInitial * Time.deltaTime, 0f, 0f);
            yield return null;
        }*/


        yield return new WaitForSeconds(0.8f);

        float time = 0f;
        Vector3 startPos = currentPanel.transform.position;
        Vector3 targetPos = zoomPoint.position;
        Image image = currentPanel.GetComponent<Image>();

        // zoom
        while (time <= 0.8f)
        {
            time += Time.deltaTime;
            // move
            //initialBackground.transform.position = Vector3.Lerp(startPos, targetPos, time * moveSpeed);
            // scale
            currentPanel.transform.localScale += Time.deltaTime * zoomInSpeed * new Vector3(1, 1, 1);
            // fade
            image.color = new Color(1f, 1f, 1f, 1f - (0.8f * time));
            yield return null;
        }
        //transform.position = targetPos;

        // set initial scale and colour values
        panelR.transform.localScale = initialPanelScale;
        panelSR.transform.localScale = initialPanelScale;
        panelUR.transform.localScale = initialPanelScale;
        image.color = new Color(1f, 1f, 1f, 1f);

        // load the corresponding rarity
        currentPanel.gameObject.SetActive(false);
        currentPanel = panelR.transform;
        switch (rarity)
        {
            case BasePart.RARITY.RARITY_RARE:
                currentPanel = panelR.transform;
                panelR.SetActive(true);
                break;
            case BasePart.RARITY.RARITY_SUPER_RARE:
                currentPanel = panelSR.transform;
                panelSR.SetActive(true);
                break;
            case BasePart.RARITY.RARITY_ULTRA_RARE:
                currentPanel = panelUR.transform;
                panelUR.SetActive(true);
                break;
        }

        float panelScale = currentPanel.localScale.x;
        while (panelScale > 1f)
        {
            panelScale -= Time.deltaTime * 0.5f * zoomOutSpeed;
            if (panelScale < 1f)
                panelScale = 1f;
            currentPanel.localScale = new Vector3(panelScale, panelScale, panelScale);
            yield return null;
        }

        gachaButton.SetActive(true);
    }
}
