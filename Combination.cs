public class Combination
{
    // Return all combinations that sum to the target
    // Each number can only be used once
    // Each combination must be unique

    // arr = [ 5, 4, -1, 0, 1, 2, 3 ], target = 5

    // Time Complexity O(2^n)

    List<List<int>> combinations = new List<List<int>>();

    public List<List<int>> CombinationSum(int[] arr, int target)
    {
        // Need to sort inorder to know if we have gone over the target
        List<int> nums = arr.OrderBy(p => p).ToList();

        BT(0, 0, target, new List<int>(), nums);

        Print();

        return combinations;
    }

    public void BT(int index, int sum, int target, List<int> current, List<int> arr)
    {
        // Found a combination
        if (sum == target)
        {
            combinations.Add(new List<int>(current));
            return;
        }
        // Went over target so we can abandon this combination
        else if (sum > target)
        {
            return;
        }

        for (int i = index; i < arr.Count(); i++)
        {
            // Check to make sure previous value isn't the same as current to avoid duplicates
            if (i > index && arr[i] == arr[i - 1])
            {
                continue;
            }

            // Add value to combination list
            current.Add(arr[i]);

            // Check next value in list
            BT(i + 1, sum + arr[i], target, current, arr);

            // Remove value added above
            current.RemoveAt(current.Count() - 1);
        }
    }

    public void Print()
    {
        foreach(List<int> list in combinations)
        {
            string output = "[";

            for(int i = 0; i < list.Count(); i++)
            {
                output += (list[i] + (i < list.Count() - 1 ? "," : ""));
            }

            output += "]";

            Console.WriteLine(output);
        }
    }
}