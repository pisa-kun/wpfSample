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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Indicator
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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
