using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace ProgressBar
{
    public class HelperCommand : ICommand
    {
        //Command実行時に実行するアクション
        private Action _action;

        public HelperCommand(Action action)
        {
            //コンストラクタでActionを登録
            _action = action;

        }
        #region インターフェースの実装
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object sender)
        {
            return _action != null;
        }

        public void Execute(object parameter)
        {
            //今回は引数を使わずActionを実行
            _action?.Invoke();
        }
        #endregion
    }
}
