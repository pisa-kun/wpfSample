using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProgressBar.ViewModel
{
    public class SimpleProgressViewModel : INotifyPropertyChanged
    {
        private int _progress;
        public int Progress
        {
            get { return this._progress;}
            set
            {
                this._progress = value;
                this.NotifyPropertyChanged(nameof(this.Progress));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(name));
        }
    }
}
