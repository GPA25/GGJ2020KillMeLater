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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGachaSequence()
    {
        initialBackground.GetComponent<MoveBackground>().StopMove();
        StartCoroutine(Zoom());
    }

    private IEnumerator Zoom()
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
        panelR.SetActive(true);
        float panelScale = panelR.transform.localScale.x;
        while (panelScale > 1f)
        {
            panelScale -= Time.deltaTime * 0.5f * zoomOutSpeed;
            if (panelScale < 1f)
                panelScale = 1f;
            panelR.transform.localScale = new Vector3(panelScale, panelScale, panelScale);
            yield return null;
        }
    }
}
