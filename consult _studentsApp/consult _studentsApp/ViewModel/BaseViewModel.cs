using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace consult__studentsApp.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public int IsBusy { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnpropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
