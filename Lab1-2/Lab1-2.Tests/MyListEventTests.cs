using Lab1_2.Tests.Abstract;
using Lab1_2.List;

namespace Lab1_2.Tests;

public class MyListEventTests : MyListTestsBase
{
    [Fact]
    public void CollectionChanged_WhenItemAdded_ShouldBeCalled()
    {
        var newItem = 100;
        TestCollectionChangedEvent(CollectionChangeType.Add,
            list => list.Add(newItem),
            eventArgs => Assert.Equal(newItem, eventArgs.NewItem));
    }

    [Fact]
    public void CollectionChanged_WhenItemInserted_ShouldBeCalled()
    {
        var newItem = 100;
        TestCollectionChangedEvent(CollectionChangeType.Add,
            list => list.Insert(1, newItem),
            eventArgs => Assert.Equal(newItem, eventArgs.NewItem));
    }

    [Fact]
    public void CollectionChanged_WhenCleared_ShouldBeCalled()
    {
        TestCollectionChangedEvent(CollectionChangeType.Clear,
            list => list.Clear(),
            eventArgs => Assert.Empty(eventArgs.NewCollection));
    }

    [Fact]
    public void CollectionChanged_WhenSetWithIndexer_ShouldBeCalled()
    {
        var oldItem = TestValues[1];
        var newItem = 100;

        TestCollectionChangedEvent(CollectionChangeType.Update,
            list => list[1] = newItem,
            eventArgs =>
            {
                Assert.Equal(oldItem, eventArgs.OldItem);
                Assert.Equal(newItem, eventArgs.NewItem);
            });
    }

    [Fact]
    public void CollectionChanged_WhenItemRemoved_ShouldBeCalled()
    {
        var oldItem = TestValues.First();
        TestCollectionChangedEvent(CollectionChangeType.Remove,
            list => list.Remove(oldItem),
            eventArgs => Assert.Equal(oldItem, eventArgs.OldItem));
    }

    [Fact]
    public void CollectionChanged_WhenItemRemoveAt_ShouldBeCalled()
    {
        var oldItem = TestValues[1];
        TestCollectionChangedEvent(CollectionChangeType.Remove, 
            list => list.RemoveAt(1),
            eventArgs => Assert.Equal(oldItem, eventArgs.OldItem));
    }

    private void TestCollectionChangedEvent(CollectionChangeType changeType,
        Action<MyList<int>> listAction,
        Action<CollectionChangedEventArgs<int>> assertAction)
    {
        //Arrange
        var list = new MyList<int>(TestValues);
        var oldList = (MyList<int>)list.Clone();
        
        CollectionChangedEventArgs<int>? eventArgs = null;

        list.CollectionChanged += args => eventArgs = args;

        //Act
        listAction(list);

        //Assert
        Assert.NotNull(eventArgs);
        Assert.Equal(eventArgs.ChangeType, changeType);
        Assert.Equal(eventArgs.OldCollection, oldList);
        Assert.Equal(eventArgs.NewCollection, list);
        assertAction(eventArgs!);
    }
}