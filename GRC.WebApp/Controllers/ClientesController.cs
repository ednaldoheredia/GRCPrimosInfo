
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GRC.WebApp.ViewModels;
using GRC.Dominio.Interfaces;
using GRC.Dominio.Model;

public class ClientesController : Controller
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IClienteService _clienteService;
    public ClientesController(IClienteRepository clienteRepository,
        IClienteService clienteService)
    {
        this._clienteRepository = clienteRepository;
        this._clienteService = clienteService;
    }

    // GET: CLIENTEVIEWMODELS
    public async Task<IActionResult> Index()    
    {
        var clientes = await _clienteRepository.ObterTodos();

        var clienteViewModel = clientes.Select(c => new ClienteViewModel
        {
            Nome = c.Nome,
            Endereco = c.Endereco,
            Numero = c.Numero
        });
        return View(clienteViewModel);
    }

    // GET: CLIENTEVIEWMODELS/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clienteviewmodel = await _clienteRepository.ObterPorId(id);

        if (clienteviewmodel == null)
        {
            return NotFound();
        }

        return View(clienteviewmodel);
    }

    // GET: CLIENTEVIEWMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CLIENTEVIEWMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClienteViewModel clienteviewmodel)
    {
        var cliente = new Cliente
        {
            Nome = clienteviewmodel.Nome,
            Endereco = clienteviewmodel.Endereco,
            Numero = clienteviewmodel.Numero
        };



        if (!ModelState.IsValid) return BadRequest(ModelState);
        {
            var resutl = await _clienteRepository.Adicionar(cliente);
            return RedirectToAction(nameof(Index));
        }
        return View(clienteviewmodel);
    }

    // GET: CLIENTEVIEWMODELS/Edit/5
    public async Task<IActionResult> Edit(Guid id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clienteviewmodel = await _clienteRepository.ObterPorId(id);
        if (clienteviewmodel == null)
        {
            return NotFound();
        }
        return View(clienteviewmodel);
    }

    // POST: CLIENTEVIEWMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
    {
        if (id != clienteViewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {

            var cliente = new Cliente
            {
                Nome = clienteViewModel.Nome,
                Endereco = clienteViewModel.Endereco,
                Numero = clienteViewModel.Numero
            };

            try
            {
                var result = _clienteRepository.Adicionar(cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
            }
            return RedirectToAction(nameof(Index));
        }
        return View(clienteViewModel);
    }

    // GET: CLIENTEVIEWMODELS/Delete/5
    public async Task<IActionResult> Delete(Guid id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clienteviewmodel = await _clienteRepository.ObterPorId(id);
        if (clienteviewmodel == null)
        {
            return NotFound();
        }

        return View(clienteviewmodel);
    }

    // POST: CLIENTEVIEWMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var clienteviewmodel = await _clienteRepository.ObterPorId(id);
        if (clienteviewmodel != null)
        {
            var result = _clienteRepository.Remover(id);
        }
        return RedirectToAction(nameof(Index));
    }

   
}
