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
        public ReactiveProperty<uint> Id { get; }
        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<DateTime> LimitDate { get; }
        public ReactiveProperty<DateTime> BoughtDate { get; }
        public ReactiveProperty<BitmapImage> Image { get; }

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        // test用
        public FoodViewModel() : this(new Food("test1", new DateTime(2018, 10,17), new DateTime(2018, 10,19), new BitmapImage(new Uri("nothing", UriKind.RelativeOrAbsolute))))
        {
        }

        public FoodViewModel(Food food)
        {
            this.Id = food.ObserveProperty(x => x.Id).ToReactiveProperty().AddTo(this.Disposable);
            this.Name = food.ObserveProperty(x => x.Name).ToReactiveProperty().AddTo(this.Disposable);
            this.LimitDate = food.ObserveProperty(x => x.LimitDate).ToReactiveProperty().AddTo(this.Disposable);
            this.BoughtDate = food.ObserveProperty(x => x.BoughtDate).ToReactiveProperty().AddTo(this.Disposable);
            this.Image = food.ObserveProperty(x => x.Image).ToReactiveProperty().AddTo(this.Disposable);
        }

        public void Dispose()
        {
            this.Disposable.Dispose();
        }
    }
}
