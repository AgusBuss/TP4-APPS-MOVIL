using System.Net.Http.Json;
using TP4___TRANI.Models;

namespace TP4___TRANI.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://fakestoreapi.com/products";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET - Obtener todos los productos
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>(BaseUrl)
                   ?? new List<Product>();
        }

        // GET - Obtener un producto por ID
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"{BaseUrl}/{id}");
        }

        // POST - Crear un producto
        public async Task<Product?> CreateProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, product);
            return await response.Content.ReadFromJsonAsync<Product>();
        }

        // PUT - Actualizar un producto
        public async Task<Product?> UpdateProductAsync(int id, Product product)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", product);
            return await response.Content.ReadFromJsonAsync<Product>();
        }

        // DELETE - Eliminar un producto
        public async Task<bool> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}