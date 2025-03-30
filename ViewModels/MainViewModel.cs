using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using Newtonsoft.Json;
using WewilTimer.Core.Models;
using WewilTimer.ViewModels;
using WewilTimer.Views;
using Xamarin.Essentials;

namespace WewilTimer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        
        private const string FileName = "usersLocalToDoItemSaveFile.json"; //TODO: перенести путь в конфиг-файл;
        
        private string FilePath;

        public MainView view;
        public ReactiveCommand<string, Unit> AddItemCommand { get; }
        public ReactiveCommand<ToDoItemViewModel, Unit> DeleteItemCommand { get; }
        public ObservableCollection<ToDoItemViewModel> ToDoItems { get; } = new ObservableCollection<ToDoItemViewModel>();

        public MainViewModel(MainView mainView)
        {
            this.view = mainView;
            AddItemCommand = ReactiveCommand.Create<string>(AddToDoItem);
            DeleteItemCommand = ReactiveCommand.Create<ToDoItemViewModel>(DeleteToDoItem);
            
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                FilePath = Path.Combine(FileSystem.AppDataDirectory, FileName);
            }
            else
            {
                FilePath = "usersLocalToDoItemSaveFile.json";
            }
            
            
            LoadToDoItemsFromUserSaveFile();
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
            UpdateToDoItemsInUserSaveFile();
        }

        public void DeleteToDoItem(ToDoItemViewModel item)
        {
            ToDoItems.Remove(item);
            UpdateToDoItemsInUserSaveFile();
        }
        
        private void UpdateToDoItemsInUserSaveFile()
        {
            var items = ToDoItems.Select(item => new
            {
                item.IsChecked,
                item.MainText,
                item.Date,
                item.Description,
                item.Project
            }).ToList();

            var json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
        
        private void LoadToDoItemsFromUserSaveFile()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                var items = JsonConvert.DeserializeObject<List<dynamic>>(json);
                if (items != null)
                {
                    ToDoItems.Clear();
                    foreach (var item in items)
                    {
                        ToDoItems.Add(new ToDoItemViewModel(new ToDoItem
                        {
                            IsChecked = item.IsChecked,
                            MainText = item.MainText,
                            Date = item.Date,
                            Description = item.Description,
                            Project = item.Project
                        }));
                    }
                }
            }
        }
        

        public void ClearNewTaskTextBox()
        {
            TextBox newTaskTextBox = view.FindControl<TextBox>("NewToDoItemTextBox");
            newTaskTextBox.Text = "";
        }
    }
}