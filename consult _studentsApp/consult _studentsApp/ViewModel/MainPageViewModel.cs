using consult__studentsApp.Model;
using consult__studentsApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace consult__studentsApp.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        #region
        public ObservableCollection<AsignacionEstudiante> AsignacionEstudiante { get; set; }
        private ICommand BuscarCommand { get; set; }
        public ICommand AwaitSearchingCommand { get; set; }
        public string SearchParam { get; set; }
        private AsignacionService Service { get; set; }
        #endregion

        public MainPageViewModel()
        {
            Title = Resources.AppResources.consulta;
            Service = new AsignacionService();
            AsignacionEstudiante = new ObservableCollection<AsignacionEstudiante>();
            AwaitSearchingCommand = new Command(async () => { await DelayedQueryForKeyboardTypingSearches(); });
            BuscarCommand = new Command(Buscar);

        }

        private async void Buscar()
        {
            try
            {
                if (!string.IsNullOrEmpty(SearchParam))
                    using (Acr.UserDialogs.UserDialogs.Instance.Loading(Resources.AppResources.cargando))
                    {
                        AsignacionEstudiante = new ObservableCollection<AsignacionEstudiante>(await Service.Get(SearchParam));
                    }
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
            }
        }

        private CancellationTokenSource throttleCts = new CancellationTokenSource();
        private async Task DelayedQueryForKeyboardTypingSearches()
        {
            try
            {
                float second = 1.2f;
                Interlocked.Exchange(ref this.throttleCts, new CancellationTokenSource()).Cancel();
                await Task.Delay(TimeSpan.FromSeconds(second), this.throttleCts.Token)
              .ContinueWith(task => BuscarCommand.Execute(null),
                            CancellationToken.None,
                            TaskContinuationOptions.OnlyOnRanToCompletion,
                            TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                //IgnorarErrores
            }
        }
    }
}
