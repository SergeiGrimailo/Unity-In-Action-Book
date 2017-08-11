using System.Collections;
using System;

public class CommonListViewModel<T>: ListViewModel<T> where T: class {

	public event EventHandler<ListEventArgs<T>> ListChanged;

	private IList internalList = new ArrayList();

	public void addItem(T item) {
		int position = internalList.Add(item);
		if (position > -1) {
			if (ListChanged != null)
				ListChanged(this, new ListEventArgs<T>(ListEventArgs<T>.Action.ItemAdded, -1, item));
		}
	}

	public int getCount() {
		return internalList.Count;
	}

	public T getItemAt(int index) {
		return (T) internalList[index];
	}

	public void removeItem(T item) {
		int position = internalList.IndexOf(item);
		if (position > -1) {
			internalList.Remove(item);
			if (ListChanged != null)
				ListChanged(this, new ListEventArgs<T>(ListEventArgs<T>.Action.ItemRemoved, position, item));
		}
	}
}
