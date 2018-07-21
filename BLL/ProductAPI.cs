using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http;
using DAL;


namespace BLL
{
    public class ProductAPI
    {

        //System.Net.Http.Formatting.Extension

        /// <summary>
        /// 한번 인스턴스화되고 응용프로그램 수명동안 재사용됨
        /// </summary>
        /// <remarks>
        /// System.Net.Http.HttpClient
        /// </remarks>
        private static HttpClient m_Client = new HttpClient();


        /// <summary>
        /// 
        /// </summary>
        /// <example>
        /// RunAsync().GetAwaiter().GetResult();
        /// </example>
        /// <returns></returns>
        static async Task RunAsync()
        {
            m_Client.BaseAddress = new Uri("http://localhost:64195/");// HTTP요청에 대한 기본 URI 설정

            m_Client.DefaultRequestHeaders.Accept.Clear();
            m_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // JSON 형식 데이터를 보내도록 해더설정

            try
            {
                Product product = new Product { Name = "Gizmo", Price = 100, Category = "Widgets" };

                var url = await CreateProductAsync(product);
                Console.WriteLine($"Created at {url}");

                product = await GetProductAsync(url.PathAndQuery);
                ShowProduct(product);

                Console.WriteLine("updating price ...");
                product.Price = 80;
                await UpdateProductAsync(product);

                product = await GetProductAsync(url.PathAndQuery);
                ShowProduct(product);

                var statusCode = await DeleteProductAsync(product.Id);
                Console.WriteLine($"Deleted (HTTP status = {(int)statusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// 정보를 출력하는 메서드
        /// </summary>
        /// <param name="product"></param>
        static void ShowProduct(Product product)
        {
            Console.WriteLine($"Name: {product.Name}\tPrice: {product.Price}\tCategory: {product.Category}");
        }

        /// <summary>
        /// [ C ] Uri 타입의 값을 반환하는 비동기 POST 메서드 : 새 제품정보 추가생성
        /// </summary>
        /// <param name="product"></param>
        /// <remarks>
        /// Json 개체를 serialize 하여 JSON 형태의 데이터를 보냄
        /// 201 응답을 받으면 리소스의 Uri 반환
        /// </remarks>
        /// <returns>URI of the created resource</returns>
        static async Task<Uri> CreateProductAsync(Product product)
        {
            HttpResponseMessage response = await m_Client.PostAsJsonAsync("api/products"
                                                                        , product);//System.Net.Http.Formatting.Extension
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        /// <summary>
        /// [ R ] Product 타입의 값을 반환하는 비동기 GET 메서드 : Uri 정보를 이용해 제품정보 가져오기
        /// </summary>
        /// <remarks>
        ///   HTTP GET 요청을 보내면 HTTP 응답을 포함하는 HttpResponseMessage 반환
        ///   IsSuccessStatusCode = true 성공 / false : 오류
        ///   deserialize 시 Product형 인스턴스 사용
        /// </remarks>
        /// <param name="path">response.Headers.Location으로 받은 Uri정보</param>
        /// <returns></returns>
        static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;

            HttpResponseMessage response = await m_Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>(); // deserialize 시 Product형 인스턴스 사용
            }

            return product;
        }

        /// <summary>
        /// [ U ] Product 타입의 값을 반환하는 비동기 PUT 메서드 : 해당하는 ID의 제품정보 업데이트 및 요청
        /// </summary>
        /// <param name="product"></param>
        /// <remarks>
        /// PUT 요청을 하는 점만 제외하면 PostAsJsonAsync와 같은 동작
        /// Json 개체를 serialize 하여 JSON 형태의 데이터를 보냄
        /// 201 응답을 받으면 리소스의 Uri 반환
        /// </remarks>
        /// <returns></returns>
        static async Task<Product> UpdateProductAsync(Product product)
        {
            HttpResponseMessage response = await m_Client.PutAsJsonAsync($"api/products/{product.Id}"
                                                                        , product);
            response.EnsureSuccessStatusCode();

            product = await response.Content.ReadAsAsync<Product>();
            return product;
        }

        /// <summary>
        /// [ D ] 상태코드를 반환하는 비동기 DELETE 메서드 : 해당하는 ID의 제품정보 삭제요청
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await m_Client.DeleteAsync($"api/product/{id}");

            return response.StatusCode;
        }
    }
}
