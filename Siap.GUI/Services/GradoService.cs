using Siap.Shared;
using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public class GradoService : IGradoService
    {
        private readonly HttpClient _httpClient;

        public GradoService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<GradoDTO> Buscar(int? id)
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<GradoDTO>>($"api/Grados/Buscar/{id}");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public Task<int> Editar(GradoDTO gradoDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Guardar(GradoDTO gradoDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Grados/Guardar", gradoDTO);
            var response = await result.Content.ReadFromJsonAsync<responseAPI<int>>();
            if(response!.EsCorrecto)
                return response.Valor;
            throw new Exception(response.Mensaje);
        }

        public async Task<List<GradoDTO>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<List<GradoDTO>>>("api/Grados/Lista");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

    }
}
