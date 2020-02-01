using System.Collections;
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


    // Start is called before the first frame update
    void Start()
    {
        panelR.SetActive(false);
        panelSR.SetActive(false);
        panelUR.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGachaSequence(BasePart.RARITY rarity)
    {
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
        Vector3 startPos = initialBackground.transform.position;
        Vector3 targetPos = zoomPoint.position;
        Image image = initialBackground.GetComponent<Image>();

        // zoom
        while (time <= 0.8f)
        {
            time += Time.deltaTime;
            // move
            initialBackground.transform.position = Vector3.Lerp(startPos, targetPos, time * moveSpeed);
            // scale
            initialBackground.transform.localScale += Time.deltaTime * zoomInSpeed * new Vector3(1, 1, 1);
            // fade
            image.color = new Color(1f, 1f, 1f, 1f - (0.8f * time));
            yield return null;
        }
        transform.position = targetPos;

        // load the corresponding rarity
        Transform panelToShow = panelR.transform;
        switch (rarity)
        {
            case BasePart.RARITY.RARITY_RARE:
                panelToShow = panelR.transform;
                panelR.SetActive(true);
                break;
            case BasePart.RARITY.RARITY_SUPER_RARE:
                panelToShow = panelSR.transform;
                panelSR.SetActive(true);
                break;
            case BasePart.RARITY.RARITY_ULTRA_RARE:
                panelToShow = panelUR.transform;
                panelUR.SetActive(true);
                break;
        }

        float panelScale = panelToShow.localScale.x;
        while (panelScale > 1f)
        {
            panelScale -= Time.deltaTime * 0.5f * zoomOutSpeed;
            if (panelScale < 1f)
                panelScale = 1f;
            panelToShow.localScale = new Vector3(panelScale, panelScale, panelScale);
            yield return null;
        }
    }
}
