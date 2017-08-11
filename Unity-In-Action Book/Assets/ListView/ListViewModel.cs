using System;

public class ListEventArgs<T> : EventArgs where T: class {

	public enum Action { ItemAdded, ItemRemoved, ListChanged };

	public readonly Action action;

	public readonly T item = null;
	public readonly int position;

	public ListEventArgs(Action action): this (action, -1, null) {
	}

	public ListEventArgs(Action action, int position, T item) {
		this.action = action;
		this.position = position;
		this.item = item;
	}

}

public interface ListViewModel<T> where T: class {

	event EventHandler<ListEventArgs<T>> ListChanged;

	void addItem(T item);
	void removeItem(T item);

	int getCount();
	T getItemAt(int index);

}