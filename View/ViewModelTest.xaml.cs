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
        /// <summary>
        /// Model
        /// </summary>
        private Model.Food _foodModel;
        /// <summary>
        /// ViewModel
        /// </summary>
        public ViewModel.FoodViewModel FoodViewModel { get; set; }

        private FoodCollection _foodModelCollection;

        public ViewModel.FoodViewModelCollection FoodViewModelCollection { get; set; }

        public ViewModelTest()
        {
            InitializeComponent();

            var ram = new Random();
            _foodModel = new Model.Food("秋刀魚", new DateTime(2019, 4, 20), new DateTime(2019, 4, 27), new BitmapImage());
            FoodViewModel = new ViewModel.FoodViewModel(_foodModel);
            this.DataContext = FoodViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this._foodModel.Name = "変更しました！";
        }
    }
}
