using Prism.Mvvm;
using System;
using System.Windows.Media.Imaging;

namespace Wpf_FoodManager.Model
{
    /// <summary>
    /// 食材を表すクラス
    /// </summary>
    public class Food : BindableBase
    {
        /// <summary>
        /// ID
        /// </summary>
        private Guid _id;
        public Guid ID
        {
            get { return _id; }
            set { this.SetProperty(ref _id, value); }
            // 上記と同じ記述(INotifyPropertyChanged実装前提)
            // set {
            //       this._id = value;
            //       this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Id)));
        }

        /// <summary>
        /// 名前
        /// </summary>
        private string _name;
        public string Name
        {
            get { return _name; }
            set { this.SetProperty(ref _name, value); }
        }

        /// <summary>
        /// 賞味期限
        /// </summary>
        private DateTime _limitDate;
        public DateTime LimitDate
        {
            get { return _limitDate; }
            set { this.SetProperty(ref _limitDate, value); }
        }

        /// <summary>
        /// 購入日
        /// </summary>
        private DateTime _boughtDate;
        public DateTime BoughtDate
        {
            get { return _boughtDate; }
            set { this.SetProperty(ref _boughtDate, value); }
        }

        /// <summary>
        /// 画像
        /// </summary>
        private BitmapImage _image;
        public BitmapImage Image
        {
            get { return _image; }
            set { this.SetProperty(ref _image, value); }
        }


        /// <summary>
        /// デザイナ用コンストラクタ
        /// </summary>
        [Obsolete("デザイナ用です。代わりにFood(string, DateTime, DateTime, BitmapImage)を使用してください。")]
        public Food()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">食材名</param>
        /// <param name="limitDate">賞味期限</param>
        /// <param name="boughtDate">購入日</param>
        /// <param name="image">画像</param>
        public Food(string name, DateTime limitDate, DateTime boughtDate, BitmapImage image)
        {
            this._id = Guid.NewGuid();
            this._name = name;
            this._limitDate = limitDate;
            this._boughtDate = boughtDate;
            this._image = image;
        }
    }
}
