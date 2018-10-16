using Prism.Mvvm;
using System;
using System.Windows.Media.Imaging;

namespace Wpf_FoodManager.Model
{
    public class Food : BindableBase
    {
        /// <summary>
        /// Id
        /// </summary>
        private uint _id;
        public uint Id
        {
            get { return _id; }
            set { this.SetProperty(ref _id, value); }
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

        private static uint _countId = 1;

        public Food()
        {
        }

        public Food(string name, DateTime limitDate, DateTime boughtDate, BitmapImage image)
        {
            this._id = Food._countId++;
            this._name = name;
            this._limitDate = limitDate;
            this._boughtDate = boughtDate;
            this._image = image;
        }
    }
}
