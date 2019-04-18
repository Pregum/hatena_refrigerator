using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Wpf_FoodManager.Model
{
    /// <summary>
    /// Foodコンテナクラスに対してCURD処理を公開します
    /// </summary>
    public interface IFoodContainer : INotifyCollectionChanged
    {
        /// <summary>
        /// Foodオブジェクトを追加します。
        /// </summary>
        /// <param name="food"> 追加されるオブジェクト </param>
        /// <exception cref="System.ArgumentNullException">引数がnullです。</exception>
        /// <returns></returns>
        void Create(Food food);
        /// <summary>
        /// 全てのFoodオブジェクトを取得します。
        /// </summary>
        /// <returns></returns>
        IEnumerable<Food> ReadAll();
        /// <summary>
        /// 指定したIDのFoodオブジェクトを取得します。
        /// </summary>
        /// <param name="guid">取得対象のID</param>
        /// <returns></returns>
        Food ReadOne(Guid guid);
        /// <summary>
        /// 指定した食材を更新します。
        /// </summary>
        /// <param name="food">更新対象のFoodオブジェクト</param>
        void Update(Food food);
        /// <summary>
        /// 指定されたIDのFoodオブジェクトを削除します。
        /// </summary>
        /// <param name="guid"> 削除対象のID </param>
        /// <exception cref="System.ArgumentOutOfRangeException" >引数のidが負の数かuindのサイズを超えています。</exception>
        /// <returns></returns>
        void Delete(Guid guid);
    }
}
