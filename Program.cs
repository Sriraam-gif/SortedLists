using System;

class Program
{

    public static void Main(string[] args)
    {
        List<List<int>> list = new List<List<int>>();
        List<int> one = new List<int>() {};
        List<int> two = new List<int>() {};
        List<int> three = new List<int>() {};

        list.Add(one);
        list.Add(two);
        list.Add(three);

        List<int> sortedList = sortingLists(list);

        foreach (int val in sortedList)
        {
            Console.Write(val + " ");
        }
    }

    // Pre-Condition: The list within the lists are pre sorted in ascending order
    //Post-Condition: The function will return a single list of numbers(from the list of list) with ascending order


    public static List<int> sortingLists(List<List<int>> listOfLists)
    {
        List<int> sortedList = new List<int>();
        List<int> indexes = new List<int>(); // This will hold the index of the lists with the list

        for (int i = 0; i < listOfLists.Count; i++) //The list "indexes" will have 0s in the list that will represent the initial indexes of the lists within the list
        {
            indexes.Add(0);
        }

        bool condition = false;

        while (condition == false)
        {

            int min = int.MaxValue;
            int index = 0;

            for (int i = 0; i < listOfLists.Count; i++)
            {
                if (indexes[i] < listOfLists[i].Count)
                {
                    if (min > listOfLists[i][indexes[i]])
                    {
                        min = listOfLists[i][indexes[i]];
                        index = i;
                    }
                }
            }
            sortedList.Add(min);
            indexes[index] = indexes[index] + 1;

            condition = true;

            for (int i = 0; i < indexes.Count; i++) //checking for whether we need to repeat this process again
            {
                if (indexes[i] < listOfLists[i].Count)
                {
                    condition = false;
                    break;
                }
            }
        }

        return sortedList;

    }
}

