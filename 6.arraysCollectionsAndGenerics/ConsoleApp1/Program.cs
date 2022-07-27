using ConsoleApp1;

try
{
    var stringArray = new GenericCollection<string>();

    stringArray.SetItemAtIndex("aa", 0);
    stringArray.SetItemAtIndex("bb", 1);
    stringArray.SetItemAtIndex("cc", 9);
    var item1 = stringArray.GetItemAtIndex(0);
    var item2 = stringArray.GetItemAtIndex(9);
    Console.WriteLine("Before swap");
    Console.WriteLine(item1);
    Console.WriteLine(item2);

    //item swap
    stringArray.Swap(ref item1, ref item2);
    Console.WriteLine("After index swap");
    Console.WriteLine(item1);
    Console.WriteLine(item2);


    //index swap
    item1 = stringArray.GetItemAtIndex(0);
    item2 = stringArray.GetItemAtIndex(9);
    stringArray.Swap(0, 9);
    Console.WriteLine("After item swap");
    Console.WriteLine(item1);
    Console.WriteLine(item2);

    //index and item swap
    item1 = stringArray.GetItemAtIndex(0);
    item2 = stringArray.GetItemAtIndex(9);
    stringArray.Swap(0, ref item2);
    Console.WriteLine("After index and item swap");
    Console.WriteLine(item1);
    Console.WriteLine(item2);
}
catch (InvalidOperationException e)
{
    Console.WriteLine(e.Message);
}