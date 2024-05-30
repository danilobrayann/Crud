using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    private static List<FoodItem> _foodItems = new List<FoodItem>();
    private static int _nextId = 1;
    private readonly ILogger<FoodController> _logger;

    public FoodController(ILogger<FoodController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostFoodItem")]
    public IActionResult Post([FromBody] FoodItem foodItem)
    {
        if (foodItem == null)
        {
            return BadRequest("Food item is null");
        }

        // Assign an ID to the food item
        foodItem.ID = _nextId++;

        // Log the received food item for debugging purposes
        _logger.LogInformation($"Received FoodItem: ID={foodItem.ID}, Name={foodItem.Name}, Calories={foodItem.Calories}, Fat={foodItem.Fat}, Carbs={foodItem.Carbs}, Protein={foodItem.Protein}");

        // Add the food item to the list
        _foodItems.Add(foodItem);

        return Ok($"Food item received successfully with ID: {foodItem.ID}");
    }

    [HttpGet(Name = "GetAllFoodItems")]
    public IActionResult Get()
    {
        // Log the retrieval of food items for debugging purposes
        _logger.LogInformation("Retrieving all food items");

        // Return the list of food items
        return Ok(_foodItems);
    }

    [HttpDelete("{id}", Name = "DeleteFoodItem")]
    public IActionResult Delete(int id)
    {
        // Find the food item by ID
        var foodItem = _foodItems.FirstOrDefault(fi => fi.ID == id);
        if (foodItem == null)
        {
            return NotFound($"Food item with ID {id} not found");
        }

        // Remove the food item from the list
        _foodItems.Remove(foodItem);

        // Log the deletion of the food item for debugging purposes
        _logger.LogInformation($"Deleted FoodItem: ID={foodItem.ID}, Name={foodItem.Name}, Calories={foodItem.Calories}, Fat={foodItem.Fat}, Carbs={foodItem.Carbs}, Protein={foodItem.Protein}");

        return Ok($"Food item with ID {id} deleted successfully");
    }

    [HttpPut("{id}", Name = "PutFoodItem")]
    public IActionResult Put(int id, [FromBody] FoodItem updatedFoodItem)
    {
        if (updatedFoodItem == null)
        {
            return BadRequest("Updated food item is null");
        }

        // Find the food item by ID
        var foodItem = _foodItems.FirstOrDefault(fi => fi.ID == id);
        if (foodItem == null)
        {
            return NotFound($"Food item with ID {id} not found");
        }

        // Update the properties of the found food item
        foodItem.Name = updatedFoodItem.Name;
        foodItem.Calories = updatedFoodItem.Calories;
        foodItem.Fat = updatedFoodItem.Fat;
        foodItem.Carbs = updatedFoodItem.Carbs;
        foodItem.Protein = updatedFoodItem.Protein;

        // Log the update of the food item for debugging purposes
        _logger.LogInformation($"Updated FoodItem: ID={foodItem.ID}, Name={foodItem.Name}, Calories={foodItem.Calories}, Fat={foodItem.Fat}, Carbs={foodItem.Carbs}, Protein={foodItem.Protein}");

        return Ok($"Food item with ID {id} updated successfully");
    }
}
