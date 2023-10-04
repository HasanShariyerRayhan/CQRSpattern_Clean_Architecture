using Employee.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Employee.Frontend.Controllers;

public class EmployeeController : Controller
{
    private readonly HttpClient _httpClient;

    public EmployeeController(IHttpClientFactory httpClientFactory) => _httpClient = httpClientFactory.CreateClient("EmployeeApiBase");

    public async Task<IActionResult> Index() => View(await GetAllEmployee());

    public async Task<List<Emplyees>> GetAllEmployee()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Emplyees>>("Employee");
        return response is null ? new List<Emplyees>() : response;
    }

    public async Task<IActionResult>AddorEdit(int Id)
    {

        var response = await _httpClient.GetAsync("Country");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var countryList = JsonConvert.DeserializeObject<List<Country>>(content);
            ViewData["countryId"] = new SelectList(countryList, "Id", "CountryName");
        }



        if (Id == 0)
        {
            return View(new Emplyees());

        }
    else
        {
            var data = await _httpClient.GetAsync($"Emloyee/{Id}");
            if (data.IsSuccessStatusCode)
            {
                var result = await data.Content.ReadFromJsonAsync<Emplyees>();
                return View(result);
            }
        }
        return View(new Emplyees());
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult>AddorEdit(int Id, Emplyees employee)
    {
        if (ModelState.IsValid)
        {
            if (Id == 0)
            {
                var result = await _httpClient.PostAsJsonAsync("Employee", employee);
                if (result.IsSuccessStatusCode) return RedirectToAction("Index");

            }
            else
            {
                var result = await _httpClient.PutAsJsonAsync($"Employee/{Id}", employee);
                if (result.IsSuccessStatusCode) return RedirectToAction("Index");
            }
            
        }
        return View (new Emplyees());
    }

    public async Task<IActionResult>Delete(int Id)
    {
        var data = await _httpClient.DeleteAsync($"Employee/{Id}");
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
