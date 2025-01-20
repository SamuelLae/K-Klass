public class InputException : Exception{
  string message = "Faulty input";
    public override string ToString()
    {
        return message;
    }
}

public class ContinueStopper{
  public void continueMessage(){
    Console.WriteLine("Press any button to continue");
    Console.ReadKey();
    Console.Clear();
  }
}

public class Queue<T> : IComparable<Queue<T>> where T : IComparable<T>{
  /// <summary>
  /// Check the last items index
  /// </summary>
  public int last;

  /// <summary>
  /// Length of the list
  /// </summary>
  public int len;

  /// <summary>
  /// The queues content
  /// </summary>
  public T[] items;

  public Queue(int Len){
    last = -1;
    len = Len;
    items = new T[len];
  }

  /// <summary>
  /// Compares two instances of the queue
  /// </summary>
  /// <param name="x"></param>
  /// <returns></returns>
  public int CompareTo(Queue<T> x){
       for (int i = 0; i <= last && i <= x.last; i++)
        {
            int result = items[i].CompareTo(x.items[i]);
            if (result != 0)
            {
                return result;
            }
        }
        return last.CompareTo(x.last);
  }

  /// <summary>
  /// Adds an element to the end of the queue
  /// </summary>
  /// <param name="y"></param>
  public void add(T y){
    if (last + 1 < items.Length)
    {
        last++;
        items[last] = y;
    }
    else
    {
        Console.WriteLine("Queue is full.");
    }
  }

  /// <summary>
  /// Removes an element at the given index
  /// </summary>
  /// <param name="z"></param>
  public void remove(int z){
    if (!isEmpty() && z <= last)
    {
        for (int i = z; i < last; i++)
        {
            items[i] = items[i + 1];
        }
        last--;
    }
    else
    {
        Console.WriteLine("Queue is empty or invalid index.");
    }
  }

  /// <summary>
  /// Swaps the places of two elements at given indexes
  /// </summary>
  /// <param name="n"></param>
  /// <param name="m"></param>
  public void swap(int n, int m){
    Console.WriteLine($"{n} is your first index, {m} is your second index");
    if (n >= 0 && n <= last && m >= 0 && m <= last)
    {
        T temp = items[n];
        items[n] = items[m];
        items[m] = temp;
    }
    Console.WriteLine($"{n} is now your first index, {m} is your second index");
  }

  /// <summary>
  /// Returns if the list is empty
  /// </summary>
  /// <returns></returns>
  public bool isEmpty(){
    return last == -1;
  }

  /// <summary>
  /// Returns the smallest element in the list
  /// </summary>
  /// <returns></returns>
  public T min(){
    if (isEmpty())
    {
        throw new InvalidOperationException("Queue is empty.");
    }
    T minElement = items[0];
    for (int i = 1; i <= last; i++)
    {
        if (items[i].CompareTo(minElement) < 0)
        {
            minElement = items[i];
        }
    }
    return minElement;
  }

  /// <summary>
  /// Prints a list of all the items
  /// </summary>
  public void print(){
    if (isEmpty())
    {
        Console.WriteLine("Queue is empty.");
    }
    else
    {
        for (int i = 0; i <= last; i++)
        {
            Console.WriteLine($"{items[i]} ");
        }
        Console.WriteLine();
    }
  }
}

public class Program{
  static void Main(){
    ContinueStopper stopper = new ContinueStopper();
    Queue<int> queueInt = new Queue<int>(3);
    Queue<string> queueStr = new Queue<string>(3);

    Queue<int> queueOne = new Queue<int>(2);
    Queue<int> queueTwo = new Queue<int>(3);

    bool queueRunning = true;
    Console.WriteLine("Welcome to the queue!\nPress any button to continue:");
    Console.ReadKey(true);
    while (queueRunning){
      Console.WriteLine("What do you want to do?: ");
      Console.WriteLine("1) Add\n2) Remove\n3) Compare\n4) Swap\n5) Print Queue\n6) Exit");
      switch (Console.ReadKey(true).KeyChar){
        case '1':
          Console.WriteLine("Enter the item you want to add");
          string itemAdd = Console.ReadLine();
          Console.Write("test");
          if (string.IsNullOrEmpty(itemAdd))
          {
              Console.WriteLine("Invalid input. Please enter a valid string.");
          }
          else
          {
              queueStr.add(itemAdd);
              Console.WriteLine($"{itemAdd} was added to your queue.");
          }
          stopper.continueMessage();
          break;

        case '2':
          Console.WriteLine("Enter the index to remove from the queue");
          if (int.TryParse(Console.ReadLine(), out int indexRemove) && indexRemove <= queueInt.last && indexRemove >= 0)
          {
              queueInt.remove(indexRemove);
              Console.WriteLine($"Index {indexRemove} was removed.");
          }
          else
          {
              Console.WriteLine("Invalid input or index out of bounds.");
          }
          stopper.continueMessage();
          break;

        case '3':
          Console.WriteLine(queueOne.CompareTo(queueTwo));
          stopper.continueMessage();
          break;

        case '4':
          Console.WriteLine("Enter two indices to swap:");
          if (int.TryParse(Console.ReadLine(), out int swapIndexOne) && int.TryParse(Console.ReadLine(), out int swapIndexTwo))
          {
              queueInt.swap(swapIndexOne, swapIndexTwo);
          }
          else
          {
              Console.WriteLine("Invalid indices.");
          }
          stopper.continueMessage();
          break;

        case '5':
          queueStr.print();
          stopper.continueMessage();
          break;

        case '6':
          Console.WriteLine("Quitting Queue");
          queueRunning = false;
          break;

        default:
          Console.WriteLine("Invalid option");
          break;
      }
    } 
  }
}
