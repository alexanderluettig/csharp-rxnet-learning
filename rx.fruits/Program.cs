using System.Reactive.Linq;

// https://RxJs-fruits.com in C#

#region Level 5: Filtering
// var fruits = new[] { "apple", "apple", "old-apple", "apple", "old-apple", "banana", "old-banana", "old-banana", "banana", "banana" }.ToObservable();

// fruits
//     .Where(fruit => !fruit.Contains("old-"))
//     .Subscribe(Console.WriteLine);
#endregion

#region Level 6: Select

// var fruits = new[] { "dirty-apple", "apple", "dirty-banana", "banana" }.ToObservable();

// fruits
//     .Select(fruit => fruit.Replace("dirty-", ""))
//     .Subscribe(Console.WriteLine);

#endregion

#region Level 7: Select, Where and Take

// var fruits = new[] { "old-banana", "apple", "dirty-banana", "apple" }.ToObservable();

// fruits
//     .Where(fruit => !fruit.Contains("old-"))
//     .Select(fruit => fruit.Replace("dirty-", ""))
//     .Take(2)
//     //.Distinct() (?)
//     .Subscribe(Console.WriteLine);

#endregion

#region Level 8: DistinctUntilChanged

// var fruits = new[] { "banana", "apple", "apple", "banana", "banana" }.ToObservable();
// fruits.DistinctUntilChanged().Subscribe(Console.WriteLine);

#endregion

#region Level 9: Skip

// var fruits = new[] { "apple", "apple", "banana", "apple" }.ToObservable();
// fruits.Skip(2).Subscribe(Console.WriteLine);

#endregion

#region Level 10: skip take select

// var fruits = new[] { "dirty-apple", "apple", "dirty-banana", "dirty-banana", "apple" }.ToObservable();
// fruits
//     .Skip(2)
//     .Take(1)
//     .Select(fruit => fruit.Replace("dirty-", ""))
//     .Subscribe(Console.WriteLine);

#endregion

#region Level 11: concat

// var apples = new[] { "apple", "apple", "old-apple", "apple", "old-apple" }.ToObservable();
// var bananas = new[] { "banana", "old-banana", "old-banana", "banana", "banana" }.ToObservable();

// var fruits = apples.Concat(bananas);
// fruits.Where(x => !x.Contains("old")).Subscribe(Console.WriteLine);

#endregion

#region Level 12: takeLast

// var fruits = new[] { "apple", "apple", "banana", "apple", "banana" }.ToObservable();
// fruits.TakeLast(3).Subscribe(Console.WriteLine);

#endregion

#region Level 13: skipLast

// var fruits = new[] { "apple", "apple", "banana", "apple", "banana" }.ToObservable();
// fruits.SkipLast(3).Subscribe(Console.WriteLine);

#endregion

#region Level 14: skipLast, skip and concat

// var apples = new[] { "apple", "dirty-apple", "apple", "old-apple", "old-apple" }.ToObservable();
// var bananas = new[] { "old-banana", "old-banana", "dirty-banana", "dirty-banana", "dirty-banana" }.ToObservable();

// apples.SkipLast(2)
//     .Concat(bananas.Skip(2))
//     .Select(e => e.Replace("dirty-", ""))
//     .Subscribe(Console.WriteLine);

#endregion

#region Level 15: zip and selectMany

// var apples = new[] { "apple", "apple" }.ToObservable();
// var bananas = new[] { "banana", "banana" }.ToObservable();

// apples.Zip(bananas).SelectMany((fruits) => new string[] { fruits.First, fruits.Second }).Subscribe(Console.WriteLine);

#endregion

#region Level 16: repeat

var fruits = new[] { "apple" }.ToObservable();
fruits.Repeat(3).Subscribe(Console.WriteLine);

#endregion