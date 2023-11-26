﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace EQTool
{
    public class UpdateMessageData : INotifyPropertyChanged
    {
        public string Date { get { return DateTime.ToShortDateString(); } }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

    public partial class UpdateMessagesWindow : Window
    {
        public ObservableCollection<UpdateMessageData> UpdateMessages { get; set; } = new ObservableCollection<UpdateMessageData>();
        public UpdateMessagesWindow()
        {
            this.Topmost = true;
            this.DataContext = this;
            InitializeComponent();
            var view = (ListCollectionView)CollectionViewSource.GetDefaultView(Messages.ItemsSource);
            view.GroupDescriptions.Add(new PropertyGroupDescription(nameof(UpdateMessageData.Date)));
            view.LiveGroupingProperties.Add(nameof(UpdateMessageData.Message));
            view.IsLiveGrouping = true;
            view.SortDescriptions.Add(new SortDescription(nameof(UpdateMessageData.DateTime), ListSortDirection.Ascending));
            view.IsLiveSorting = true;
            UpdateMessages.Add(new UpdateMessageData
            {
                DateTime = new DateTime(2023, 11, 25),
                Message = "If kael faction pulls are happening, a timer will be added to let you know when the next will be regardless of whether you are in the zone"
            });
            UpdateMessages.Add(new UpdateMessageData
            {
                DateTime = new DateTime(2023, 11, 25),
                Message = "Fixed various map issues"
            });
            UpdateMessages.Add(new UpdateMessageData
            {
                DateTime = new DateTime(2023, 11, 25),
                Message = "Added ability to remove individual items from the Triggers window"
            });
            UpdateMessages.Add(new UpdateMessageData
            {
                DateTime = new DateTime(2023, 11, 25),
                Message = "Change Auto Update to only occur if you have been idle for 2 or more minutes!"
            });
        }
    }
}