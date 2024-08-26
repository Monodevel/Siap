using Siap.Shared;
using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly HttpClient _httpClient;

        public CategoriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<CategoriaDTO> Buscar(int? id)
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<CategoriaDTO>>($"api/Categorias/Buscar/{id}");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Guardar(CategoriaDTO categoriaDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Categorias/Guardar",categoriaDTO);
            var response = await result.Content.ReadFromJsonAsync<responseAPI<int>>();
            if (response!.EsCorrecto)
                return response.Valor;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<List<CategoriaDTO>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<List<CategoriaDTO>>>("api/Categorias/Lista");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<List<CategoriaDTO>> CategoriaInstitucion(int? idInstitucion)
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<List<CategoriaDTO>>>($"api/Categorias/CategoriaInstitucion/{idInstitucion}");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }
    }
}