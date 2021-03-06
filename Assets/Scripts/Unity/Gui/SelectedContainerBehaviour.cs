﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedContainerBehaviour : MonoBehaviour {

    public Button _buttonPrefab;

    //in case the player manipulates the selection with the GUI, the Entitas system needs to be notified:
    public delegate void ChangeSelectionRequestHandler(GameObject go);
    public event ChangeSelectionRequestHandler UnselectRequested;
    public event ChangeSelectionRequestHandler SelectRequested;

    Dictionary<Button, GameObject> reverse;
    Dictionary<GameObject, Button> forward;

    private List<Button> _buttonList;

    private void Start()
    {
        _buttonList = new List<Button>();
        _buttonPrefab.gameObject.SetActive(false);
        reverse = new Dictionary<Button, GameObject>();
        forward = new Dictionary<GameObject, Button>();
    }

    public void ClearSelection()
    {
        foreach (var icon in _buttonList.ToArray())
        {
            Destroy(icon.gameObject);
        }
        _buttonList.Clear();
    }

    public void Select(GameObject sel) 
    {

        if (forward.ContainsKey(sel))
        {
            //this can happen when a previously selected unit is also in the new selection box
            return;
        }

        HexSelectable selectable = sel.GetComponent<HexSelectable>();
        Button thumb = Instantiate<Button>(_buttonPrefab);
        thumb.GetComponent<RectTransform>().SetParent(this.GetComponent<RectTransform>());
        thumb.gameObject.SetActive(true);
        thumb.transform.GetChild(0).GetComponent<Text>().text = sel.name;
        thumb.transform.GetChild(1).GetComponent<Image>().sprite = selectable.Thumbnail;
        thumb.onClick.AddListener(() => { if (SelectRequested != null) SelectRequested.Invoke(sel); });

        forward[sel] = thumb;
        reverse[thumb] = sel;
    }

    public void UnSelect(GameObject sel)
    {
        if (!forward.ContainsKey(sel))
        {
            Debug.LogError("Object can't be unselected: " + sel.name);
            return;
        }

        Button toRemove = forward[sel];
        forward.Remove(sel);
        reverse.Remove(toRemove);

        toRemove.onClick.RemoveAllListeners();
        Destroy(toRemove.gameObject);
    }

}
