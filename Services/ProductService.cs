using System.Net.Http.Json;
using System.Net;
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
        public async Task<(List<Product>? productos, HttpStatusCode codigo)> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            var productos = await response.Content.ReadFromJsonAsync<List<Product>>();
            return (productos, response.StatusCode);
        }

        // GET - Obtener un producto por ID
        public async Task<(Product? producto, HttpStatusCode codigo)> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            var producto = await response.Content.ReadFromJsonAsync<Product>();
            return (producto, response.StatusCode);
        }

        // POST - Crear un producto
        public async Task<(Product? producto, HttpStatusCode codigo)> CreateProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, product);
            var producto = await response.Content.ReadFromJsonAsync<Product>();
            return (producto, response.StatusCode);
        }

        // PUT - Actualizar un producto
        public async Task<(Product? producto, HttpStatusCode codigo)> UpdateProductAsync(int id, Product product)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", product);
            var producto = await response.Content.ReadFromJsonAsync<Product>();
            return (producto, response.StatusCode);
        }

        // DELETE - Eliminar un producto
        public async Task<(bool exito, HttpStatusCode codigo)> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return (response.IsSuccessStatusCode, response.StatusCode);
        }
    }
}