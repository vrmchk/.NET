using Lab1_2.List;
using Lab1_2.Tests.Abstract;

namespace Lab1_2.Tests;

public class MyListTests : MyListTestsBase
{
    [Fact]
    public void Add_ShouldAddItemToList()
    {
        // Arrange
        var list = new MyList<int>();

        // Act
        list.Add(1);

        // Assert
        Assert.Contains(1, list);
    }

    [Fact]
    public void Clear_ShouldClearTheList()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act
        list.Clear();

        // Assert
        Assert.Empty(list);
    }

    [Fact]
    public void Contains_WhenItemInTheList_ShouldReturnTrue()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        //Act
        var contains = list.Contains(TestValues.First());

        // Assert
        Assert.True(contains);
    }

    [Fact]
    public void Contains_WhenItemNotInTheList_ShouldReturnFalse()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        //Act
        var contains = list.Contains(TestValues.Length + 1);

        // Assert
        Assert.False(contains);
    }

    [Fact]
    public void CopyTo_ShouldCopyItemsToArray()
    {
        // Arrange
        var list = new MyList<int>(TestValues);
        var array = new int[list.Count];

        // Act
        list.CopyTo(array, 0);

        // Assert
        Assert.Equal(TestValues, array);
    }

    [Fact]
    public void CopyTo_WhenNotEnoughSpaceInArray_ShouldThrowException()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        var array = new int[list.Count - 1];

        // Act & Assert
        Assert.Throws<ArgumentException>(() => list.CopyTo(array, 0));
    }
    
    [Fact]
    public void CopyTo_WhenArrayIsNull_ShouldThrowException()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => list.CopyTo(null!, 0));
    }
    
    [Fact]
    public void CopyTo_WhenNegativeIndex_ShouldThrowException()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        var array = new int[list.Count];

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, -1));
    }

    [Fact]
    public void Indexer_ShouldReturnItemAtIndex()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act & Assert
        for (int i = 0; i < list.Count; i++)
        {
            Assert.Equal(TestValues[i], list[i]);
        }
    }

    [Fact]
    public void Indexer_ShouldSetItemAtIndex()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act
        list[1] = 100;

        // Assert
        Assert.Equal(100, list[1]);
    }

    [Fact]
    public void Indexer_WhenInvalidIndex_ShouldThrowException()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => list[-1]);
        Assert.Throws<IndexOutOfRangeException>(() => list[TestValues.Length] = 1);
    }

    [Fact]
    public void Remove_ShouldRemoveItemFromList()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act
        var result = list.Remove(TestValues.First());

        // Assert
        Assert.True(result);
        Assert.Equal(TestValues.Length - 1, list.Count);
        Assert.DoesNotContain(TestValues.First(), list);
    }

    [Fact]
    public void Remove_WhenItemNotInList_ShouldReturnFalse()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act
        var result = list.Remove(TestValues.Length + 1);

        // Assert
        Assert.False(result);
        Assert.Equal(TestValues.Length, list.Count);
    }

    [Fact]
    public void GetEnumerator_ShouldReturnEnumerator()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act
        var enumerator = list.GetEnumerator();

        // Assert
        Assert.NotNull(enumerator);
    }

    [Fact]
    public void IndexOf_WhenItemInList_ShouldReturnIndexOfItem()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act
        int index = list.IndexOf(TestValues[1]);

        // Assert
        Assert.Equal(1, index);
    }

    [Fact]
    public void IndexOf_WhenItemNotInList_ShouldReturnNegativeOne()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act
        int index = list.IndexOf(TestValues.Length + 1);

        // Assert
        Assert.Equal(-1, index);
    }

    [Fact]
    public void RemoveAt_WhenValidIndex_ShouldRemoveItemAtIndex()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act
        list.RemoveAt(1);

        // Assert
        Assert.Equal(TestValues.Length - 1, list.Count);
        Assert.DoesNotContain(TestValues[1], list);
    }

    [Fact]
    public void RemoveAt_WhenInvalidIndex_ShouldThrowException()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(-1));
        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(TestValues.Length));
    }

    [Fact]
    public void Insert_WhenValidIndex_ShouldInsertItemAtIndex()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act
        list.Insert(1, 100);

        // Assert
        Assert.Equal(TestValues.Length + 1, list.Count);
        Assert.Contains(100, list);
    }

    [Fact]
    public void Insert_WhenEmptyList_ShouldInsertItemAtStart()
    {
        // Arrange
        var list = new MyList<int>();

        // Act
        list.Insert(0, 100);

        // Assert
        Assert.Single(list);
        Assert.Contains(100, list);
    }

    [Fact]
    public void Insert_WhenInsertingToEnd_ShouldInsertItemAtEnd()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act
        list.Insert(TestValues.Length, 100);

        // Assert
        Assert.Equal(TestValues.Length + 1, list.Count);
        Assert.Contains(100, list);
    }

    [Fact]
    public void Insert_WhenInvalidIndex_ShouldThrowException()
    {
        // Arrange
        var list = new MyList<int>(TestValues);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => list.Insert(-1, 1));
        Assert.Throws<IndexOutOfRangeException>(() => list.Insert(TestValues.Length + 1, 1));
    }
}