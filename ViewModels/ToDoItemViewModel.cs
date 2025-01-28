using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WewilTimer.Core.Models;

namespace WewilTimer.ViewModels
{
    //Здесь будет реализация визуального ф-ла для разных меню приложения связанных с задачей
    public class ToDoItemViewModel : ViewModelBase 
    {
        public ToDoItemViewModel()
        {

        }

        public ToDoItemViewModel(ToDoItem item) 
        {
            IsChecked = item.IsChecked;
            MainText = item.MainText;
            Date = item.Date;
            Description = item.Description;
            Project = item.Project;
        }

        public bool IsChecked 
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }
        public string MainText
        {
            get { return _mainText; }
            set { _mainText = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Project
        {
            get { return _project; }
            set { _project = value; }
        }

        //[ObservableProperty]
        private bool _isChecked
        { get; set; }

        //[ObservableProperty]
        private string _mainText { get; set; }
        private DateTime _date { get; set; }
        private string _description { get; set; }
        private string _project { get; set; }
        public ToDoItem GetToDoItem()
        {
            return new ToDoItem
            {
                IsChecked = this.IsChecked,
                MainText = this.MainText,
                Date = this.Date,
                Description = this.Description,
                Project = this.Project
            };
        }

    }
}
