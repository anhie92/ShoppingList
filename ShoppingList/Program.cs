
using System.Diagnostics;
using System.Linq;

Dictionary<string, Double> shoppingItems = new Dictionary<string, double>
{
    { "apple",1.99 },
    {"banana", .59 },
    {"cauliflower", 1.59},
    {"dragonfruit", 2.19 },
    {"elderberry", 1.79},
    {"figs", 2.09 },
    {"grapefruit", 1.99 },
    {"honeydew", 3.49}
};

List<string> shoppingList = new List<string>();


void DisplayMenu()
{
    Console.WriteLine("The Items on the menu are");
    foreach (KeyValuePair<string,Double> item in shoppingItems)
    {
        string menu = $"{item.Key}         ${item.Value}";
        Console.WriteLine(menu);
    }
}


double ValidateInput(string order)
{
    double price = -1;
    try
    {

        price = shoppingItems[order];
    }
    catch (KeyNotFoundException)
    {
        Console.WriteLine($"sorry {order} is not on the menu");
    }

    return price;
}




while (true)
{


    DisplayMenu();
    Console.WriteLine("what would you like to order?");
    string order = Console.ReadLine().ToLower();

    double price = ValidateInput(order);

    if (shoppingItems.ContainsKey(order))
    {
        shoppingList.Add(order);
        Console.WriteLine($"you added {order} at ${price} ");
    }

    // attempt to orderby price
    List<string> orderedList = shoppingList
        .Where(x => shoppingItems.ContainsKey(x))
        .OrderByDescending(x => shoppingItems.Values)
        .Select(x => x)
        .ToList();
    

    Console.WriteLine("would you like to order anything else? (y/n)");
    string addToOrder = Console.ReadLine().ToLower();
    if(addToOrder != "y")
    {
        double sum = 0;
        double average;
        Console.WriteLine("Thanks your for your order");
        Console.WriteLine("here is what you got");
       
        foreach (string item in orderedList)
        {
            Console.WriteLine($"{item} {shoppingItems[item]}");
            sum += shoppingItems[item];
        }
        average = Math.Round(sum / orderedList.Count, 2);
        
        Console.WriteLine($"your total will be ${sum}");
        Console.WriteLine($"your average price per item is {average}");
        break;
    }
}






