namespace AdventOfCode2022.Days;

public class Day01
{
    public int Day01Part01(List<Elf> input)
    {
        return input.Max(e => e.Calories.Sum());
    }
    
    public int Day01Part02(List<Elf> input)
    {
        return ParseMax(input) + ParseMax(input) + ParseMax(input);
    }

    private int ParseMax(List<Elf> input)
    {
        int maxId = -1;
        int maxCalories = 0;
        
        foreach (Elf elf in input)
        {
            var totalCals = elf.Calories.Sum();

            if (totalCals <= maxCalories)
                continue;
            
            maxCalories = totalCals;
            maxId = elf.Id;
        }
        
        input.Remove(input.Single(x => x.Id == maxId));

        return maxCalories;
    }
}

public class Elf
{
    public int Id { get; init; }
    
    public List<int>? Calories { get; init; }
}