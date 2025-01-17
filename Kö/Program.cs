public class InputException : Exception{
  string message = "Faulty input";
    public override string ToString()
    {
        return message;
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
/// Adds a element to the end of the queue
/// </summary>
/// <param name="y"></param>
  public void add(T y){
    {
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
  }

/// <summary>
/// Removes a element on the given index
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
/// Swaps the places of two element on two given indexes
/// </summary>
/// <param name="n"></param>
/// <param name="m"></param>
  public void swap(int n, int m){
     if (n >= 0 && n <= last && m >= 0 && m <= last)
        {
            T temp = items[n];
            items[n] = items[m];
            items[m] = temp;
        }
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
    T minElement = items[0];
    for (int i = 1; i < last; i++){
      if (items[i].CompareTo(minElement) < 0){
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
                Console.Write($"{items[i]} ");
            }
            Console.WriteLine();
        }
    }
  }


public class Program{
  static void Main(){
    Queue<int> queueInt = new Queue<int>();
    Queue<string> queueStr = new Queue<string>();

    Queue<int> queueOne = new Queue<int>();
    Queue<int> queueTwo = new Queue<int>();

    bool ProgramRunning = true;

    Console.WriteLine("Welcome to the queue! \n Press any button to continue:");
    Console.ReadKey(true);
    while (ProgramRunning){
      Console.Clear();
      Console.WriteLine("What do you want to do?: ");
      Console.WriteLine("1) Add\n 2) Remove\n 3) Compare\n 4) Swap");
      switch (Console.ReadKey(true).KeyChar){
        case '1':
        string itemAdd = Console.ReadLine();
        if (itemAdd == null || itemAdd.All(Char.IsDigit)){
          throw new InputException();
      }
      queueStr.add(itemAdd);
      break;

      case '2':
        string indexRemove = Console.ReadLine();
        if (int.Parse(indexRemove) < queueInt.len || indexRemove.All(char.IsAsciiLetter)){
          throw new InputException();
        }
        queueInt.remove(int.Parse(indexRemove));
        break;

      case '3':
        Console.WriteLine(queueOne.CompareTo(queueTwo));
        break;

      case '4':
        char swapIndexOne = Console.ReadKey().KeyChar;
        char swapIndexTwo = Console.ReadKey().KeyChar;
        if (swapIndexOne == null && swapIndexTwo == null || char.IsAsciiLetter(swapIndexOne) && char.IsAsciiLetter(swapIndexTwo)){
          throw new InputException();
        }
        queueInt.swap(swapIndexOne, swapIndexTwo);
        break;
    }
  } 
}
}