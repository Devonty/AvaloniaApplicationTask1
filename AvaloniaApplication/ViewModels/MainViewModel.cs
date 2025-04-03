using CommunityToolkit.Mvvm.ComponentModel;
using AvaloniaApplication.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AvaloniaApplication.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly MyDictionary _dictionary = new();

        [ObservableProperty] private string _keyInput = "";
        [ObservableProperty] private string _valueInput = "";
        [ObservableProperty] private string _messages = "";

        public ObservableCollection<DictionaryItem> DictionaryItems { get; } = new();

        public MainViewModel()
        {
            RefreshDictionaryItems();
        }

        [RelayCommand]
        private void Add()
        {
            try
            {
                _dictionary.Add(KeyInput, ValueInput);
                RefreshDictionaryItems();
                Messages = "Item added successfully.";
            }
            catch (System.ArgumentException ex)
            {
                Messages = ex.Message;
            }
        }

        [RelayCommand]
        private void Remove()
        {
            if (_dictionary.Remove(KeyInput))
            {
                RefreshDictionaryItems();
                Messages = "Item removed successfully.";
            }
            else
            {
                Messages = "Key not found.";
            }
        }

        [RelayCommand]
        private void Clear()
        {
            _dictionary.Clear();
            RefreshDictionaryItems();
            Messages = "Dictionary cleared.";
        }

        private void RefreshDictionaryItems()
        {
            DictionaryItems.Clear();
            foreach (var item in _dictionary.Items)
            {
                DictionaryItems.Add(item);
            }
        }
    }
}