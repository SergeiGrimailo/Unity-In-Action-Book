using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListViewController : MonoBehaviour {

	public ListView listView;

	private CommonListViewModel<object> _listViewModel;

	// Use this for initialization
	void Start () {
		initializeList();
	}
	
	// Update is called once per frame
	void Update () {		
	}

	public void initializeList() {
		_listViewModel = new CommonListViewModel<object>();
		_listViewModel.addItem("One");
		_listViewModel.addItem("Two");
		_listViewModel.addItem("Three");
		listView.model = _listViewModel;
	}
}
