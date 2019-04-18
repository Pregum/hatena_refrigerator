using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Wpf_FoodManager.Model
{
    /// <summary>
    /// ファイルを使用してFoodコレクションの管理をします。
    /// </summary>
    public class FoodCollection : BindableBase, INotifyCollectionChanged
    {
        /// <summary>
        /// Crud処理を実装しているインターフェース
        /// </summary>
        private IFoodContainer _foodContainer;

        /// <summary>
        /// コレクションの変更を通知するイベント
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="foodContainer">Foodコンテナクラス</param>
        public FoodCollection(IFoodContainer foodContainer)
        {
            this._foodContainer = foodContainer;
            this._foodContainer.CollectionChanged += this._foodContainer_CollectionChanged1;
        }

        /// <summary>
        /// Foodコンテナクラスの変更通知を受け取って外部に通知します。
        /// </summary>
        /// <param name="sender">通知元のクラス</param>
        /// <param name="e">変更情報</param>
        private void _foodContainer_CollectionChanged1(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.CollectionChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// 全てのFoodオブジェクトを読み込みます。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Food> ReadAll()
        {
            return this._foodContainer.ReadAll();
        }

        /// <summary>
        /// 指定したguidのFoodオブジェクトを読み込みます。
        /// </summary>
        /// <param name="guid">読み込み対象のguid</param>
        /// <returns></returns>
        public Food ReadOne(Guid guid)
        {
            return this._foodContainer.ReadOne(guid);
        }

        /// <summary>
        /// 引数のFoodオブジェクトをコンテナクラスに追加します。
        /// </summary>
        /// <exception cref="ArgumentNullException">引数がnullです。</exception>
        /// <param name="food"></param>
        public void Create(Food food)
        {
            if (food == null)
            {
                throw new ArgumentNullException($"Create時の{nameof(Food)}がnullです。");
            }
            this._foodContainer.Create(food);
        }

        /// <summary>
        /// 引数のFoodオブジェクトを更新します。
        /// </summary>
        /// <exception cref="ArgumentNullException">引数がnullです。</exception>
        /// <param name="food"></param>
        public void Update(Food food)
        {
            if (food == null)
            {
                throw new ArgumentNullException($"Update時の{nameof(Food)}がnullです。");
            }
            this._foodContainer.Update(food);
        }

        /// <summary>
        /// 指定したIDのFoodオブジェクトを削除します。
        /// </summary>
        /// <param name="guid">削除対象のID</param>
        public void Delete(Guid guid)
        {
            this._foodContainer.Delete(guid);
        }
    }
}
