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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;

namespace rx.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MovieRepository _movieRepository = new MovieRepository();
        public MainWindow()
        {
            InitializeComponent();
            moviesListView.ItemsSource = _movieRepository.Find(null);

            Observable.FromEventPattern(searchTextBox, "TextChanged")
                .Select(eventArgs => ((TextBox)eventArgs.Sender).Text)
                .Where(text => text.Length > 2)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .DistinctUntilChanged()
                .ObserveOn(SynchronizationContext.Current)
                .Select(text => _movieRepository.Find(text))
                .Subscribe(movies =>
                {
                    moviesListView.ItemsSource = movies;
                });

        }
    }
}
