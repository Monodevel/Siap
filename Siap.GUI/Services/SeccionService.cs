using Siap.Shared;
using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public class SeccionService:ISeccionService
    {
        private readonly HttpClient _httpClient;

        public SeccionService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<SeccionDTO> Buscar(int? id)
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<SeccionDTO>>($"api/Secciones/Buscar/{id}");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public Task<int> Editar(SeccionDTO seccionDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Guardar(SeccionDTO seccionDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Secciones/Guardar", seccionDTO);
            var response = await result.Content.ReadFromJsonAsync<responseAPI<int>>();
            if (response!.EsCorrecto)
                return response.Valor;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<List<SeccionDTO>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<List<SeccionDTO>>>("api/Secciones/Lista");
            if (result!.EsCorrecto)
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
