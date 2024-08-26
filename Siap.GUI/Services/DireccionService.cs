using Siap.Shared;
using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public class DireccionService : IDireccionService
    {
        private readonly HttpClient _httpClient;
        public DireccionService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }
        public async Task<DireccionDTO> Buscar(int? id)
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<DireccionDTO>>($"api/Direcciones/Buscar/{id}");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public Task<int> Editar(DireccionDTO direccionDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Guardar(DireccionDTO direccionDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Direcciones/Guardar", direccionDTO);
            var response = await result.Content.ReadFromJsonAsync<responseAPI<int>>();
            if(response!.EsCorrecto)
                return response.Valor;
            throw new Exception(response.Mensaje);
        }

        public async Task<List<DireccionDTO>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<List<DireccionDTO>>>("api/Direcciones/Lista");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
