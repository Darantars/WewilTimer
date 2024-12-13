using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Input;
using ReactiveUI;
using WewilTimer_Desctop.Models;

namespace WewilTimer_Desctop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ReactiveCommand<string, Unit> AddItemCommand { get; }
        public ReactiveCommand<ToDoItemViewModel, Unit> DeleteItemCommand { get; }
        public ObservableCollection<ToDoItemViewModel> ToDoItems { get; } = new ObservableCollection<ToDoItemViewModel>();

        public MainViewModel()
        {
            AddItemCommand = ReactiveCommand.Create<string>(AddToDoItem);
            DeleteItemCommand = ReactiveCommand.Create<ToDoItemViewModel>(DeleteToDoItem);
        }

        public void AddToDoItem(string _content)
        {
            ToDoItems.Add(new ToDoItemViewModel(new ToDoItem()
            {
                IsChecked = false,
                Content = _content
            }));
        }

        public void DeleteToDoItem(ToDoItemViewModel item)
        {
            ToDoItems.Remove(item);
        }
    }
}