using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ListView : MonoBehaviour {

	private GameObject listItemPrefab;
	private GameObject selected;

	private int newItemIndex = 0;

	private ListViewModel<object> _model;

	public ListViewModel<object> model {
		set {
			_model = value;
			clearList();
			buildList();
		}
	}

	[SerializeField]
	private Color selectionColor;

	private void Awake() {
		//
	}

	// Use this for initialization
	void Start () {
		initilizaeListItemPrefab();
	}

	private void initilizaeListItemPrefab() {
		if (listItemPrefab == null) {
			Transform listItem = transform.Find("ListItem");
			if (listItem != null) {
				listItemPrefab = listItem.gameObject;
				listItem.SetParent(null);
			} else {
				// script is not ready for such case (error?)
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void buildList() {
		if (_model != null) {
			int itemCount = _model.getCount();
			for (int i = 0; i < itemCount; i++) {
				object item = _model.getItemAt(i);
				addListItem(item.ToString());
			}
		}
	}

	private void clearList() {
		int childCount = transform.childCount;
		for (int i = 0; i < childCount; i++) {
			Transform child = transform.GetChild(i);
			Destroy(child.gameObject);
		}
	}

	private void addListItem(string text) {
		initilizaeListItemPrefab();
		GameObject newListItem = Instantiate(listItemPrefab);
		Text textView = newListItem.GetComponentInChildren<Text>();
		if (textView != null) {
			textView.text = text;
		}

		newListItem.transform.SetParent(transform);

		StartCoroutine(forceRebuildLayout());
	}

	public IEnumerator forceRebuildLayout() {
		yield return null;
		LayoutRebuilder.MarkLayoutForRebuild((RectTransform)transform);
	}

	public void removeListItem() {
		if (selected != null) {
			Destroy(selected);
			selected = null;
		}
	}

	public void onPointerDown(BaseEventData eventData) {
		//Debug.Log(eventData.selectedObject);
		PointerEventData pEventData = (PointerEventData) eventData;
		if (selected != null) {
			Image listItemImage = selected.GetComponent<Image>();
			listItemImage.color = listItemPrefab.GetComponent<Image>().color;
		}
		selected = pEventData.pointerPress;
		if (selected.name.Contains("ListItem")) {
			selected.GetComponent<Image>().color = selectionColor;			
		} else {
			selected = null;
		}
	}
}
