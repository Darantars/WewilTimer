using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WewilTimer.Core.Models;

namespace WewilTimer.ViewModels
{
    public class ToDoItemViewModel : ViewModelBase
    {
        public ToDoItemViewModel()
        {

        }

        public ToDoItemViewModel(ToDoItem item) 
        {
            IsChecked = item.IsChecked;
            Content = item.Content;
        }

        public bool IsChecked 
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        //[ObservableProperty]
        private bool _isChecked
        { get; set; }

        //[ObservableProperty]
        private string _content { get; set; }

        public ToDoItem GetToDoItem()
        {
            return new ToDoItem
            {
                IsChecked = this.IsChecked,
                Content = this.Content
            };
        }

    }
}
