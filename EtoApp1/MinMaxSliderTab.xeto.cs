using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Serialization.Xaml;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EtoApp1
{
    public class MinMaxSliderTab : Panel
    {
        public MinMaxSliderTab()
        {
            XamlReader.Load(this);
        }
    }

    public delegate void ValuePropertyChangedEventHandler(MinMaxSliderVM sender, double delta);

    public class MinMaxSliderVM : INotifyPropertyChanged
    {

        public string Name { get; set; } = "MinMaxSlider";

        /// <summary>
        /// Max value of slider;
        /// </summary>
        public double MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; OnPropertyChanged(nameof(SliderMaxValue)); OnPropertyChanged(); }
        }
        private double _maxValue = 100;

        /// <summary>
        /// Min value of slider
        /// </summary>
        public double MinValue
        {
            get { return _minValue; }
            set { _minValue = value; OnPropertyChanged(nameof(SliderMinValue)); OnPropertyChanged(); }
        }
        private double _minValue = 0;

        public double StepValue { get; set; } = 0.0001;
        public double Value
        {
            get { return _value_; }
            set { _value_ = value; OnPropertyChanged(nameof(SliderValue)); OnValueChanged(); OnPropertyChanged(); }
        }
        protected double _value_ = 50;

        public int SliderMaxValue { get { return (int)(MaxValue * 10000); } }
        public int SliderMinValue { get { return (int)(MinValue * 10000); } }
        public int SliderStepValue { get { return (int)(StepValue * 10000); } }
        public int SliderValue { get { return (int)(Value * 10000); } set { Value = value * 0.0001f; } }

        /// <summary>
        /// Gets / Sets whether the step/tick is enabled TODO use a 'bool?' and have off, slider, everything? 
        /// </summary>
        public bool StrictStepValue { get; set; } = true;

        /// <summary>
        /// whether the control can be locked by the user.
        /// </summary>
        public bool IsLockable { get; set; } = false;

        private bool _isLocked = false;
        /// <summary>
        /// used with IsLockable. locks the control so it can't be changed. 
        /// </summary>
        public bool IsLocked
        {
            get { return _isLocked; }
            set { _isLocked = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsUnLocked)); }
        }
        public bool IsUnLocked
        {
            get { return !_isLocked; }
        }


        private double _oldValue;
        public event ValuePropertyChangedEventHandler ValueChanged;
        public void OnValueChanged()
        {
            if (_oldValue != Value)
            {
                double delta = _oldValue - Value;
                _oldValue = Value;
                ValueChanged?.Invoke(this, delta);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
