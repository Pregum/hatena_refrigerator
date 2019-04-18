using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Wpf_FoodManager.Model;

namespace Wpf_FoodManager.ViewModel
{
    /// <summary>
    /// FoodViewModelのコレクションクラス
    /// コレクションの変更通知をViewに反映します。
    /// </summary>
    public class FoodViewModelCollection : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// Modelのコレクションクラス
        /// </summary>
        FoodCollection _foodCollection { get; }
        /// <summary>
        /// ViewModelのコレクションクラス
        /// </summary>
        public ReadOnlyReactiveCollection<FoodViewModel> FoodViewModels { get; }

        /// <summary>
        /// 一度に購読解除を行う為の登録先
        /// </summary>
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public FoodViewModelCollection(FoodCollection foodCollection)
        {
            this._foodCollection = foodCollection;

            // 1つ目のObservableは FoodCollectionに最初に追加されている各オブジェクト(IEnumerable<Food>)をIObservableに変換しています。
            // 2～4つ目のObservableは FoodCollectionから受け取ったFoodオブジェクト追加通知を受け取った時にViewModelに変換してFoodViewModelsに追加しています。
            this.FoodViewModels =
                Observable.Merge(
                    foodCollection.ReadAll().ToObservable().Select((x, i) => CollectionChanged<FoodViewModel>.Add(i, new FoodViewModel(x)))
                    , foodCollection.ToCollectionChanged<Food>().Where(x => x.Action == NotifyCollectionChangedAction.Add)
                        .Select(x =>  CollectionChanged<FoodViewModel>.Add(x.Index, new FoodViewModel(x.Value)))
                    , foodCollection.ToCollectionChanged<Food>().Where(x => x.Action == NotifyCollectionChangedAction.Remove)
                        .Select(x => CollectionChanged<FoodViewModel>.Remove(x.Index, new FoodViewModel(x.Value)))
                    , foodCollection.ToCollectionChanged<Food>().Where(x => x.Action == NotifyCollectionChangedAction.Reset)
                        .Select(_ => CollectionChanged<FoodViewModel>.Reset)
                ).ToReadOnlyReactiveCollection(true).AddTo(this.Disposable);

            // デバッグ用
            var debug_log = foodCollection.CollectionChangedAsObservable()
                .Subscribe(x =>
                {
                    Debug.WriteLine($"{x.Action}が呼ばれました。");
                    foreach (Food food in x.NewItems)
                    {
                        Debug.WriteLine($"名前 : {food.Name}");
                    }
                }).AddTo(this.Disposable);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        ///// <summary>
        ///// メモリリーク防止の為に実装しています。
        ///// </summary>
        //public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// 購読解除を行います。
        /// </summary>
        public void Dispose()
        {
            this.Disposable.Dispose();
        }
    }
}
