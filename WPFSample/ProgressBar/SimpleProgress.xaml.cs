using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProgressBar.ViewModel;
using System.Threading;

namespace ProgressBar
{
    /// <summary>
    /// SimpleProgress.xaml の相互作用ロジック
    /// </summary>
    public partial class SimpleProgress : Window
    {
        public SimpleProgress()
        {
            InitializeComponent();
            this.DataContext = new SimpleProgressViewModel();
        }

        // コマンドとして再定義
        //実行ボタン
        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var vm = this.DataContext as SimpleProgressViewModel;
        //    vm.IsButtonEnabled = false;
        //    await Task.Run(() =>
        //    {
        //        // 進捗率100になるまで
        //        while (vm.Progress < 100)
        //        {
        //            vm.Progress += 1;
        //            // 重い処理
        //            Thread.Sleep(100);
        //        }
        //    });

        //    //終了メッセージボックスを表示
        //    MessageBox.Show("タスクが完了しました");
        //    vm.Progress = 0;

        //    //終了後 ボタンをTrueにする
        //    vm.IsButtonEnabled = true;
        //}

        private void Indicator_Loaded(object sender, RoutedEventArgs e)
        {
            var host = (System.Windows.Forms.Integration.WindowsFormsHost)sender;
            var pbox = (System.Windows.Forms.PictureBox)host.Child;
            //loading.gifのビルドアクションをResourcesに
            //参考サイトはパスを"Resources/"にしているがSystem.IO.Exceptionが返ってくるので"/Resources/"が正解
            pbox.Image = System.Drawing.Image.FromStream(Application.GetResourceStream(new Uri("/Resources/loading.gif", UriKind.Relative)).Stream);
        }
    }
}
