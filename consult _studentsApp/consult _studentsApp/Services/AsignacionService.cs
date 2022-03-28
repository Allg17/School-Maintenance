using consult__studentsApp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace consult__studentsApp.Services
{
    public class AsignacionService
    {
        public async Task<List<AsignacionEstudiante>> Get(string param)
        {
            HttpResponseMessage respose = new HttpResponseMessage();
            System.Threading.CancellationTokenSource cancellationToken = new System.Threading.CancellationTokenSource(new TimeSpan(0, 3, 0));
            try
            {
                string url = $"api/Asignacion/{param}";
                using (respose = await ApiHelper.ApiClient.GetAsync(url, cancellationToken.Token))
                {
                    if (respose.IsSuccessStatusCode)
                    {
                        List<AsignacionEstudiante> autorizaciones = await respose.Content.ReadAsAsync<List<AsignacionEstudiante>>();
                        return autorizaciones;
                    }
                    else
                    {
                        if (respose.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            Acr.UserDialogs.UserDialogs.Instance.Alert("Servidor no encontrado", "Atención!", "Ok");
                        }
                        else
                            Acr.UserDialogs.UserDialogs.Instance.Alert(respose.ReasonPhrase, "Atención!", "Ok");

                        return new List<AsignacionEstudiante>();
                    }
                }
            }
            catch (Exception eex)
            {
                throw eex;
            }
        }
    }
}
