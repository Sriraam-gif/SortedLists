
using Xunit;
using SortingLists;
public class testclass
{

    [Theory]
    [MemberData(nameof(Data1))]
    public void sortingLists_normalCases_GeneratingASortedList(List<List<int>> listOfLists, List<int> expectedList)
    {
        List<int> actualList = Program.sortingLists(listOfLists);

        Assert.Equal(actualList, expectedList);
    }

    public static IEnumerable<object[]> Data1()
    {
        yield return new object[] { new List<List<int>>() { new List<int>() { 39, 55, 10000 }, new List<int>() { 10, 101, 200, 250 }, new List<int>() { 1000 } }, new List<int>() { 10, 39, 55, 101, 200, 250, 1000, 10000 } };
        yield return new object[] { new List<List<int>>() { new List<int>() { }, new List<int>() { 10 }, new List<int>() { 33 }, new List<int>() { 2 }, new List<int>() { 5 } }, new List<int>() { 2, 5, 10, 33 } };
        yield return new object[] { new List<List<int>>() { new List<int>() { 1, 1 }, new List<int>() { 3, 3, 3 }, new List<int>() { 2, 2, 2, 2 } }, new List<int>() { 1, 1, 2, 2, 2, 2, 3, 3, 3 } };
    }

    [Theory]
    [MemberData(nameof(Data2))]
    public void sortingLists_whenAllListsAreEmpty_ThrowsAnException(List<List<int>> listOfLists)
    {
        AllListsAreEmpty exception = new AllListsAreEmpty("User needs to enter at least one value onto one of the lists");
        Assert.Throws<AllListsAreEmpty>(() => Program.sortingLists(listOfLists));

    }

    public static IEnumerable<object[]> Data2()
    {
        yield return new object[] { new List<List<int>>() { new List<int>() { }, new List<int>() { }, new List<int>() { } } };
        yield return new object[] { new List<List<int>>() { new List<int>() { }, new List<int>() { } } };
        yield return new object[] { new List<List<int>>() { new List<int>() { } } };
        yield return new object[] { new List<List<int>>() { new List<int>() { }, new List<int>() { }, new List<int>() { }, new List<int>() { }, new List<int>() { }, new List<int>() { } } };
    }
}