using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI fruitText;
    public TextMeshProUGUI pointsText;

    // Update is called once per frame
    void Update()
    {
        moneyText.SetText(PlayerController.instance.money + "");
        fruitText.SetText(PlayerController.instance.fruit + "");
        pointsText.SetText((int)GameManager.instance.points + "");
    }
}
