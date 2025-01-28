﻿using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using WewilTimer.Core.Models;
using WewilTimer.ViewModels;
using WewilTimer.Views;

namespace WewilTimer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainView view;
        public ReactiveCommand<string, Unit> AddItemCommand { get; }
        public ReactiveCommand<ToDoItemViewModel, Unit> DeleteItemCommand { get; }
        public ObservableCollection<ToDoItemViewModel> ToDoItems { get; } = new ObservableCollection<ToDoItemViewModel>();

        public MainViewModel(MainView mainView)
        {
            this.view = mainView;
            AddItemCommand = ReactiveCommand.Create<string>(AddToDoItem);
            DeleteItemCommand = ReactiveCommand.Create<ToDoItemViewModel>(DeleteToDoItem);
        }

        public void AddToDoItem(string _mainText)
        {
            ToDoItems.Add(new ToDoItemViewModel(new ToDoItem()
            {
                IsChecked = false,
                MainText = _mainText,
                Date = DateTime.Now,
                Description = "",
                Project = ""
            }));
            ClearNewTaskTextBox();
        }

        public void DeleteToDoItem(ToDoItemViewModel item)
        {
            ToDoItems.Remove(item);
        }

        public void ClearNewTaskTextBox()
        {
            TextBox newTaskTextBox = view.FindControl<TextBox>("NewToDoItemTextBox");
            newTaskTextBox.Text = "";
        }
    }
}