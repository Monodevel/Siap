using Siap.Shared;
using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public class InstitucionService : IInstitucionService
    {
        private readonly HttpClient _httpClient;

        public InstitucionService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<InstitucionDTO> Buscar(int? id)
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<InstitucionDTO>>($"api/Instituciones/Buscar/{id}");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public Task<int> Editar(InstitucionDTO institucionDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Guardar(InstitucionDTO institucionDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Instituciones/Guardar", institucionDTO);
            var response = await result.Content.ReadFromJsonAsync<responseAPI<int>>();
            if (response!.EsCorrecto)
                return response.Valor;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<List<InstitucionDTO>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<List<InstitucionDTO>>>("api/Instituciones/Lista");
            if(result!.EsCorrecto)
            {
                return result.Valor;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }
    }
}
