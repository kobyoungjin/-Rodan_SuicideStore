using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    private GameObject bar;
    private GameObject ingrePrefab;
    IngredientDatabase data;
    public int score;

    private void Start()
    {
        bar = GameObject.Find("ItemBar(Panel)");
        ingrePrefab = Resources.Load<GameObject>("SlotPrefabs/Ingredient (Image)");  // 프리탭 이미지
        data = GameObject.FindObjectOfType<IngredientDatabase>().GetComponent<IngredientDatabase>();
    }  

    //장바구니에 재료 추가하는 함수
    public void AddingSlotBar(Ingredient image)
    {
        if (bar.transform.childCount < 5)  // 장바구니에 재료가 5개 이하일때만
        {
            GameObject instance = Instantiate(ingrePrefab);
            Image prefabImage = instance.GetComponent<Image>();
            prefabImage.sprite = image.ingredientImage.sprite;  // 클릭한 재료 이미지 변환
            
            instance.transform.SetParent(bar.transform);  // 장바구니 UI에 보이게

            int value = data.GetIngredientData(image.ingredientImage.gameObject.name.ToString());  // 장바구니에 추가되면 해당 점수가 더해진다.
            score += value;
            Debug.Log(score);
        }
    }
    
    // 최종 점수 반환 함수
    public int Score()
    {
        return score;
    }
}
