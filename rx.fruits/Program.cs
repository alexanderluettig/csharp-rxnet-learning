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

#region Level 8: SelectMany



#endregion