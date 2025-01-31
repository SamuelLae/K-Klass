namespace QueueSystem;

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
    Console.WriteLine($"{items[n]} is your first item, {items[m]} is your second item");
    if (n >= 0 && n <= last && m >= 0 && m <= last)
    {
        T temp = items[n];
        items[n] = items[m];
        items[m] = temp;
    }
    Console.WriteLine($"{items[n]} is now your first item, {items[m]} is your second item");
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