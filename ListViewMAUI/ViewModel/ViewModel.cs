﻿using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ListViewMAUI
{
    public class PagingViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PlaceInfoRepository placeInfoRepository;

        public ObservableCollection<PlaceInfo>? places { get; set; }

        #endregion

        #region Constructor

        public PagingViewModel()
        {
            placeInfoRepository = new PlaceInfoRepository();
            places = new ObservableCollection<PlaceInfo>();
            GenerateSource();
        }

        #endregion

        #region Methods

        private void GenerateSource()
        {
            for (int i = 0; i < placeInfoRepository.Place.Length; i++)
            {
                var p = new PlaceInfo()
                {
                    Name = placeInfoRepository.Place[i],
                    Description = placeInfoRepository.PlaceDescription[i],
                    Image = placeInfoRepository.Image[i],
                };
                places!.Add(p);
            }
        }
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
