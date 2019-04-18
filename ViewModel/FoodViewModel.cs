using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Disposables;
using System.Windows.Media.Imaging;
using Wpf_FoodManager.Model;

namespace Wpf_FoodManager.ViewModel
{
    public class FoodViewModel : BindableBase, IDisposable
    {
        // ReactiveProperty<T>にすることでTの型のデータの通知受け取り、通知発行の役割を持ったプロパティになります。
        public ReactiveProperty<Guid> ID { get; }
        /// <summary>
        /// 食材の名前
        /// </summary>
        public ReactiveProperty<string> Name { get; }
        /// <summary>
        /// 賞味期限
        /// </summary>
        public ReactiveProperty<DateTime> LimitDate { get; }
        /// <summary>
        /// 購入日
        /// </summary>
        public ReactiveProperty<DateTime> BoughtDate { get; }
        /// <summary>
        /// 表示するアイコン画像
        /// </summary>
        public ReactiveProperty<BitmapImage> Image { get; }

        /// <summary>
        /// 購読解除を一度に行う為のプロパティ
        /// </summary>
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        // test用
        [Obsolete("デザイン用です。FoodViewModel(Food food)を使用してください。", true)]
        public FoodViewModel()
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="food">食材</param>
        public FoodViewModel(Food food)
        {
            this.ID = food.ObserveProperty(x => x.ID).ToReactiveProperty().AddTo(this.Disposable);
            this.Name = food.ObserveProperty(x => x.Name).ToReactiveProperty().AddTo(this.Disposable);
            this.LimitDate = food.ObserveProperty(x => x.LimitDate).ToReactiveProperty().AddTo(this.Disposable);
            this.BoughtDate = food.ObserveProperty(x => x.BoughtDate).ToReactiveProperty().AddTo(this.Disposable);
            this.Image = food.ObserveProperty(x => x.Image).ToReactiveProperty().AddTo(this.Disposable);
        }

        /// <summary>
        /// 購読解除用
        /// </summary>
        public void Dispose()
        {
            this.Disposable.Dispose();
        }
    }
}
