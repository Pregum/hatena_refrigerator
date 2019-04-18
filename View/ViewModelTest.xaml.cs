using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Wpf_FoodManager.Model;

namespace Wpf_FoodManager.View
{
    /// <summary>
    /// ViewModelTest.xaml の相互作用ロジック
    /// </summary>
    public partial class ViewModelTest : Window
    {
#if _Single

        /// <summary>
        /// Model
        /// </summary>
        //private Model.Food _foodModel;
        /// <summary>
        /// ViewModel
        /// </summary>
        //public ViewModel.FoodViewModel FoodViewModel { get; set; }
#endif

        private FoodCollection _foodModelCollection;

        public ViewModel.FoodViewModelCollection FoodViewModelCollection { get; set; }

        public ViewModelTest()
        {
            InitializeComponent();

            var ram = new Random();
#if _Single
            _foodModel = new Model.Food("秋刀魚", new DateTime(2019, 4, 20), new DateTime(2019, 4, 27), new BitmapImage());
            FoodViewModel = new ViewModel.FoodViewModel(_foodModel);
            this.DataContext = FoodViewModel;
#endif
            var foodModels = Enumerable.Range(1, 10).Select(x => new Food("秋刀魚" + x, new DateTime(2019, 2, ram.Next(1, 10)), new DateTime(2019, 2, ram.Next(10, 20)), new BitmapImage()));
            IFoodContainer foodContainer = new FileFoodContainer(foodModels);
            this._foodModelCollection = new FoodCollection(foodContainer);
            this.FoodViewModelCollection = new ViewModel.FoodViewModelCollection(this._foodModelCollection);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this._foodModel.Name = "変更しました！";
        }
    }
}
