using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject[] bodyObjects;
    public Color32[] colors;

    Material[] carMats;

    // Start is called before the first frame update
    void Start()
    {
        // carMats 배열을 초기화한다.
        carMats = new Material[bodyObjects.Length];

        // 색상 담당 오브젝트에서 매터리얼을 carMats 배열에 등록한다.
        for (int i = 0; i < carMats.Length; i++)
        {
            carMats[i] = bodyObjects[i].GetComponent<MeshRenderer>().material;
        }

        // 색상 배열 0번에 자동차의 기본 색상을 저장한다.
        colors[0] = carMats[0].color;
    }

    public void ChangeColor(int num)
    {
        for(int i = 0; i<carMats.Length; i++)
        {
            carMats[i].color = colors[num];
            Debug.LogError("=========================================");
        }
    }
}
