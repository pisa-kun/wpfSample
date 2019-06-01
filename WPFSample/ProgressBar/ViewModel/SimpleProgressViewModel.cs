using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace ProgressBar.ViewModel
{
    public class SimpleProgressViewModel : INotifyPropertyChanged
    {
        public SimpleProgressViewModel()
        {

        }

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

        private bool _isButtonEnabled = true;
        public bool IsButtonEnabled
        {
            get { return this._isButtonEnabled; }
            set
            {
                this._isButtonEnabled = value;
                this.NotifyPropertyChanged(nameof(this.IsButtonEnabled));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// インジケータのvisibilty
        /// </summary>
        public Visibility _isIndicatorVisibled = Visibility.Collapsed;

        private Visibility IsIndicatorVisibled
        {
            get { return this._isIndicatorVisibled; }
            set
            {
                this._isIndicatorVisibled = value;
                this.NotifyPropertyChanged(nameof(this._isIndicatorVisibled));

            }
        }

        // Command実装
        private HelperCommand _myCommand;

        /// <summary>
        /// Gets the Command
        ///　
        /// </summary>
        public HelperCommand MyCommand
        {
            get
            {
                return _myCommand
                    ?? (_myCommand = new HelperCommand(async () =>
                    {

                        this.IsButtonEnabled = false;
                        //this.IsIndicatorVisibled = Visibility.Hidden;

                        await Task.Run(() =>
                        {
                            // 進捗率100になるまで
                            while (this.Progress < 100)
                            {
                                this.Progress += 1;
                                // 重い処理
                                Thread.Sleep(100);
                            }
                        });
                        // Taskが終了するまでインジケータを表示
                        this.IsIndicatorVisibled = Visibility.Hidden;

                        // 終了メッセージボックスを表示
                        MessageBox.Show("タスクが完了しました");
                        this.Progress = 0;

                        // 終了後 ボタンをTrueにする
                        this.IsButtonEnabled = true;
                    }));
            }
        }
    }
}
