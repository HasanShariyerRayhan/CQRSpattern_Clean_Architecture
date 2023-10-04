using Employee.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Employee.Frontend.Controllers;

public class CountryController : Controller
{
    private readonly HttpClient _httpClient;

    public CountryController(IHttpClientFactory httpClientFactory) => _httpClient = httpClientFactory.CreateClient("EmployeeApiBase");

    public async Task<IActionResult> Index() => View(await GetAllCountry());

    public async Task<List<Country>> GetAllCountry()
    {
        var respopnse = await _httpClient.GetFromJsonAsync<List<Country>>("Country");
        return respopnse is null? new List<Country>(): respopnse;
    }


    public async Task<IActionResult> AddorEdit(int Id)
    {

    
        if (Id == 0)
        {
            return View(new Country());

        }
        else
        {
            //api/Country?id

            var data = await _httpClient.GetAsync($"Country/{Id}");
            if (data.IsSuccessStatusCode)
            {
                var result = await data.Content.ReadFromJsonAsync<Country>();
                return View(result);
            }
        }
        return View(new Country());
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> AddorEdit(int Id, Country  country)
    {
        if (ModelState.IsValid)
        {
            if (Id == 0)
            {
                var result = await _httpClient.PostAsJsonAsync("Country", country);
                if (result.IsSuccessStatusCode) return RedirectToAction("Index");

            }
            else
            {
                var result = await _httpClient.PutAsJsonAsync($"Country/{Id}", country);
                if (result.IsSuccessStatusCode) return RedirectToAction("Index");
            }

        }
        return View (new Country());
    }
    //api/Country?id=
    public async Task<IActionResult> Delete(int Id)
    {
        var data = await _httpClient.DeleteAsync($"Country/{Id}");
        if (data.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }



}
