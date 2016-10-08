﻿using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EtoApp1
{
    public class SliderTab : Panel
    {
        public SliderTab()
        {
            XamlReader.Load(this);
        }
    }


    public class SliderVM : INotifyPropertyChanged
    {
        public int MaxValue { get; set; } = 100;
        public int MinValue { get; set; } = 0;
        private double _value = 50;
        public double Value { get { return _value; } set { _value = value; OnPropertyChanged(); } }
        public int Increment { get; set; } = 1;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}