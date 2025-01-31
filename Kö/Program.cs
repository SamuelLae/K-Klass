namespace QueueSystem;

public class InputException : Exception{
  string message = "Faulty input";
    public override string ToString()
    {
        return message;
    }
}

public class Program{
  static void Main(){
    ContinueStopper stopper = new ContinueStopper();
    Queue<string> queueStr = new Queue<string>(3);

    Queue<int> queueOne = new Queue<int>(2);
    Queue<int> queueTwo = new Queue<int>(3);

    bool queueRunning = true;
    Console.WriteLine("Welcome to the queue!\nPress any button to continue:");
    Console.ReadKey(true);
    while (queueRunning){
      Console.WriteLine("What do you want to do?: ");
      Console.WriteLine("1) Add\n2) Remove\n3) Compare\n4) Swap\n5) Print Queue\n6) Smalest item\n7) Exit");
      switch (Console.ReadKey(true).KeyChar){
        case '1':
          Console.WriteLine("Enter the item you want to add");
          string itemAdd = Console.ReadLine();
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
          if (int.TryParse(Console.ReadLine(), out int indexRemove) && indexRemove <= queueStr.last && indexRemove >= 0)
          {
              queueStr.remove(indexRemove);
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
              queueStr.swap(swapIndexOne, swapIndexTwo);
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
        Console.WriteLine($"The smallest item in the queue is {queueStr.min()}");
        break;

        case '7':
          Console.WriteLine("Exeting Queue");
          queueRunning = false;
          break;

        default:
          Console.WriteLine("Invalid option, please try again!");
          break;
      }
    } 
  }
}
