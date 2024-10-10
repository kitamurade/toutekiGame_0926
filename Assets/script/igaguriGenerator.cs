using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class igaguriGenerator : MonoBehaviour
{
    public GameObject igaguriPrefab;

    private void Start()
    {
        int scoreDefult = 0;
        scoreScript.instance.ScoreManeger(scoreDefult);
    }
    // Update is called once per frame
    void Update()
    {
        int scoreDefult = 0;
        if(Input.GetMouseButtonDown(0))
        {
            GameObject igaguri=Instantiate(igaguriPrefab);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            //igaguri.GetComponent<igaguriController>().Shoot(new Vector3(0, 200, 2000));
            igaguri.GetComponent<igaguriController>().Shoot(worldDir.normalized*2000);
        }
        scoreScript.instance.ScoreManeger(scoreDefult);
    }
}
