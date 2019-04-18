using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf_FoodManager.Model;
using Wpf_FoodManager.ViewModel;

namespace Wpf_FoodManager.View
{
    /// <summary>
    /// VMCollectionTest.xaml の相互作用ロジック
    /// </summary>
    public partial class VMCollectionTest : Window
    {

        private FoodCollection _foodModelCollection;
        public FoodViewModelCollection FoodViewModelCollection { get; set; }

        private Random ram = new Random();

        public VMCollectionTest()
        {
            InitializeComponent();

            var foodModels = Enumerable.Range(1, 10).Select(x => new Food("秋刀魚" + x, new DateTime(2019, 2, ram.Next(1, 10)), new DateTime(2019, 2, ram.Next(10, 20)), new BitmapImage()));
            IFoodContainer foodContainer = new FileFoodContainer(foodModels);
            this._foodModelCollection = new FoodCollection(foodContainer);
            this.FoodViewModelCollection = new ViewModel.FoodViewModelCollection(this._foodModelCollection);

            this.DataContext = this.FoodViewModelCollection;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this._foodModelCollection.Create(new Food("秋刀魚" + ram.Next(0,5), new DateTime(2019, 2, ram.Next(1, 10)), new DateTime(2019, 2, ram.Next(10, 20)), new BitmapImage()));
        }
    }
}
