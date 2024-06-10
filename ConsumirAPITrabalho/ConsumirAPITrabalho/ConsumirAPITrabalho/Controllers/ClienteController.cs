using ConsumirAPITrabalho.Service;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace ConsumirAPITrabalho.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApiService _apiService;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ApiService apiService, ILogger<ClienteController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var clientes = await _apiService.GetAllClientesAsync();
                return View(clientes);
            }
            catch (HttpRequestException httpRequestException)
            {
                _logger.LogError(httpRequestException, "Erro ao carregar a página inicial dos clientes.");
                return StatusCode(500, "Erro interno do servidor. Por favor, tente novamente mais tarde.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar a página inicial dos clientes.");
                return StatusCode(500, "Erro interno do servidor. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Cliente cliente)
        {
            _apiService.PostClienteAsync(cliente);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _apiService.GetClienteAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutClienteAsync(id, cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _apiService.GetClienteAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _apiService.GetClienteAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteClienteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

