using System;
using System.Collections.Generic;

namespace Core.MVVM.Home
{
    public class ObservableList<T> : List<T>
    {
        public delegate void InsertItem(T type, int index);
        public event InsertItem OnInsert;

        public delegate void RemoveItem(T type);
        public event RemoveItem OnRemove;

        public delegate void CollectionModify(ObservableList<T> type);
        public event CollectionModify OnCollectionModify;

        public new void Add(T item)
        {
            int index = Count;
            base.Add(item);
            OnInsert?.Invoke(item, index);
            OnCollectionModify?.Invoke(this);
        }

        public new void AddRange(IEnumerable<T> items)
        {
            base.AddRange(items);
            OnCollectionModify?.Invoke(this);
        }

        public new void Insert(int index, T item)
        {
            base.Insert(index, item);
            OnInsert?.Invoke(item, index);
            OnCollectionModify?.Invoke(this);
        }

        public new void Remove(T item)
        {
            base.Remove(item);
            OnRemove?.Invoke(item);
            OnCollectionModify?.Invoke(this);
        }

        public new void RemoveAt(int index)
        {
            if (index<0)
            {
                return;
            }
            
            var deleteItem = this[index];
            base.RemoveAt(index);
            OnRemove?.Invoke(deleteItem);
            OnCollectionModify?.Invoke(this);
        }
        public new void RemoveRange(int index,int count)
        {
            base.RemoveRange(index,count);
            OnCollectionModify?.Invoke(this);
        }

        public ObservableList()
        {
        }

        public ObservableList(List<T> newList)
        {
            AddRange(newList);
        }
    }
}