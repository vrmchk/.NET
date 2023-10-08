using Lab1_2.List;
using Lab1_2.Tests.Abstract;

namespace Lab1_2.Tests;

public class NodeEnumeratorTests : MyListTestsBase
{
    [Fact]
    public void MoveNext_ShouldEnumerateItemsInOrder()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act
        using var enumerator = list.GetEnumerator();
        var items = new List<int>();
        while (enumerator.MoveNext())
        {
            items.Add(enumerator.Current);
        }

        // Assert
        Assert.Equal(TestValues, items);
    }

    [Fact]
    public void MoveNext_WhenEmptyList_ShouldReturnFalse()
    {
        // Arrange
        var list = new MyList<int>();

        // Act
        using var enumerator = list.GetEnumerator();

        // Assert
        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void Reset_ShouldResetToStart()
    {
        // Arrange
        var list = new MyList<int>(TestValues);
        using var enumerator = list.GetEnumerator();

        // Act
        enumerator.MoveNext();
        enumerator.Reset();
        enumerator.MoveNext();

        // Assert
        Assert.Equal(TestValues.First(), enumerator.Current);
    }
}