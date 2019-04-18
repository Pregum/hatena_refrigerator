using Reactive.Bindings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FoodManager.Model
{
    /// <summary>
    /// ファイルでFoodオブジェクトを管理するクラス
    /// </summary>
    public class FileFoodContainer : IFoodContainer
    {
        /// <summary>
        /// Foodコレクションの変更通知を発行するイベント
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// Foodコレクション
        /// </summary>
        private ObservableCollection<Food> _foodModelCollection;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="foods">Foodコレクション</param>
        public FileFoodContainer(IEnumerable<Food> foods)
        {
            this._foodModelCollection = new ObservableCollection<Food>(foods);
            this._foodModelCollection.CollectionChanged += this._foodModelCollection_CollectionChanged;
        }

        public void Create(Food food)
        {
            this._foodModelCollection.Add(food);
        }

        public void Delete(Guid guid)
        {
            var food = this._foodModelCollection.FirstOrDefault(x => x.ID == guid);
            if (food != null)
            {
                var index = this._foodModelCollection.IndexOf(food);
                this._foodModelCollection.Remove(food);
                this.OnCollectionChanged(NotifyCollectionChangedAction.Remove, food, index);
            }
        }

        /// <summary>
        /// ObservableCollectionのデフォルトの通知以外の通知を発行します
        /// </summary>
        /// <param name="act"></param>
        /// <param name="obj"></param>
        /// <param name="index"></param>
        private void OnCollectionChanged(NotifyCollectionChangedAction act, object obj, int index)
        {
            this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(act, obj, index));
        }

        /// <summary>
        /// ObservableCollectionから受け取った通知をそのまま流します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _foodModelCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.CollectionChanged?.Invoke(this, e);
        }

        public IEnumerable<Food> ReadAll()
        {
            // todo: ファイルのReaderクラスに読取処理を委譲する。

            return this._foodModelCollection;
        }

        public Food ReadOne(Guid guid)
        {
            return this._foodModelCollection.FirstOrDefault(x => x.ID == guid);
        }

        public void Update(Food food)
        {
            var target = this._foodModelCollection.FirstOrDefault(x => x == food);
            Debug.Assert(target == this._foodModelCollection.FirstOrDefault(x => x == food));

            //todo: ファイル等のWriterクラスに更新処理を委譲する。
        }
    }
}
