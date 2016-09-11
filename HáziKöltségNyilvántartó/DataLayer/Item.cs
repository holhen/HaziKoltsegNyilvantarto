using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HáziKöltségNyilvántartó
{
    public class Item: INotifyPropertyChanged
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { OnPropertyChanged(ref _id, value); }
        }

        public int? csvId { get; set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }
        }

        private int _categoryId;

        public int CategoryId
        {
            get { return _categoryId; }
            set { OnPropertyChanged(ref _categoryId, value); }
        }

        private int _lastValue;

        public int LastValue
        {
            get { return _lastValue; }
            set { OnPropertyChanged(ref _lastValue, value); }
        }

        private bool _isIncome;

        public bool IsIncome
        {
            get { return _isIncome; }
            set { OnPropertyChanged(ref _isIncome, value); }
        }

        public List<Category> Category { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool OnPropertyChanged<T>(
            ref T valueRef, T newValue,
            [CallerMemberName] string propertyName = null)
        {
            if (Equals(valueRef, newValue)) return false;
            valueRef = newValue;
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
            return true;
        }

        public override bool Equals(object obj)
        {
            Item item;
            if (obj is Item)
                item = obj as Item;
            else return false;
            if (item.Id == this.Id && item.Name == this.Name && item.LastValue == this.LastValue && item.IsIncome == this.IsIncome && item.CategoryId == this.CategoryId)
                return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
