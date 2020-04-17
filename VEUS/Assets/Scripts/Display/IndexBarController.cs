using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndexBarController : MonoBehaviour
{
    int id;
    Index myIndex;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI idText;
    public Scrollbar scrollbar;
    public TextMeshProUGUI valueText;

    public Color minColor;
    public Color veryLowColor;
    public Color lowColor;
    public Color mediumColor;
    public Color highColor;
    public Color veryHighColor;
    public Color maxColor;


    public int IndexID 
    {
        get { return id; }
        set
        {
            id = value;
            myIndex = FlowChart.GetIndexFromID(value);
            SetBarData();
        }
    }
    
    void SetBarData()
    {
        scrollbar.GetComponent<Scrollbar>().interactable = false;
        float iValue = myIndex.Value;
        nameText.text = myIndex.Name;
        idText.text = myIndex.ID.ToString();
        valueText.text = iValue.ToString();
        scrollbar.GetComponent<Scrollbar>().size = iValue;
        ColorBlock cb = scrollbar.GetComponent<Scrollbar>().colors;
        switch (myIndex.GetIndexState())
        {
            case Index.STATE.MIN:
                cb.disabledColor = minColor;
                break;
            case Index.STATE.VERY_LOW:
                cb.disabledColor = veryLowColor;
                break;
            case Index.STATE.LOW:
                cb.disabledColor = lowColor;
                break;
            case Index.STATE.MEDIUM:
                cb.disabledColor = mediumColor;
                break;
            case Index.STATE.HIGH:
                cb.disabledColor = highColor;
                break;
            case Index.STATE.VERY_HIGH:
                cb.disabledColor = veryHighColor;
                break;
            default:
            case Index.STATE.MAX:
                cb.disabledColor = maxColor ;
                break;
        }
        scrollbar.GetComponent<Scrollbar>().colors = cb;
    }

    public void ClickedAction()
    {
        Debug.Log(myIndex);
    }
}
