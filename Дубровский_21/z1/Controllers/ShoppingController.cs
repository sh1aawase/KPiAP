using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using z1.Data;
using z1.Models;

namespace z1.Controllers;

public class ShoppingController : Controller
{
    private readonly ShoppingContext _context;

    public ShoppingController(ShoppingContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var viewModel = new ShoppingListViewModel
        {
            Items = await _context.ShoppingItems
                .OrderBy(i => i.IsBought)
                .ThenBy(i => i.Name)
                .ToListAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(string name, int quantity)
    {
        if (!string.IsNullOrWhiteSpace(name) && quantity > 0)
        {
            _context.ShoppingItems.Add(new ShoppingItem
            {
                Name = name.Trim(),
                Quantity = quantity,
                IsBought = false
            });
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost("Shopping/Mark/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Mark(int id, bool isBought = true)
    {
        var item = await _context.ShoppingItems.FirstOrDefaultAsync(i => i.Id == id);
        if (item is not null)
        {
            item.IsBought = isBought;
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.ShoppingItems.FirstOrDefaultAsync(i => i.Id == id);
        if (item is not null)
        {
            _context.ShoppingItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
