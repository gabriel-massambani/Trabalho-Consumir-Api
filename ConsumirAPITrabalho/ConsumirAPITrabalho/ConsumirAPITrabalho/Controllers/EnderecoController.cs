using ConsumirAPITrabalho.Service;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace ConsumirAPITrabalho.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly ApiService _apiService;

        public EnderecoController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var enderecos = await _apiService.GetAllEnderecosAsync();
            return View(enderecos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Endereco endereco)
        {
            _apiService.PostEnderecoAsync(endereco);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var endereco = await _apiService.GetEnderecoAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return View(endereco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Endereco endereco)
        {
            if (id != endereco.EnderecoId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutEnderecoAsync(id, endereco);
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var endereco = await _apiService.GetEnderecoAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return View(endereco);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var endereco = await _apiService.GetEnderecoAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return View(endereco);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteEnderecoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
