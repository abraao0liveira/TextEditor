namespace TextEditor
{
  class Program
  {
    static void Main(string[] args)
    {
      Menu();
    }

    static void Menu()
    {
      Console.Clear();

      Console.WriteLine("Choose an option:");
      Console.WriteLine("1. Open file");
      Console.WriteLine("2. Create new file");
      Console.WriteLine("0. Exit");
      Console.WriteLine("---------------------------");

      short option = short.Parse(Console.ReadLine() ?? "0");

      switch (option)
      {
        case 0: Environment.Exit(0); break;
        case 1: Open(); break;
        case 2: Create(); break;
        default: Menu(); break;
      }
    }

    static void Open()
    {
      Console.Clear();

      Console.WriteLine("What's the path of the file?");
      Console.WriteLine("---------------------------");
      var path = Console.ReadLine();

      using (var file = new StreamReader(path ?? "")) // abre e fecha o arquivo
      {
        string text = file.ReadToEnd(); //le o arquivo inteiro
        Console.WriteLine(text);
      }

      Console.WriteLine("---------------------------");
      Thread.Sleep(2000);
      Menu();
    }

    static void Create()
    {
      Console.Clear();

      Console.WriteLine("Type your text: (ESC to exit)");
      Console.WriteLine("---------------------------");
      string text = "";

      do //faz ate o usuario apertar ESC
      {
        text += Console.ReadLine(); //le a linha e adiciona ao texto
        text += Environment.NewLine; //adiciona uma nova linha
      }
      while (Console.ReadKey().Key != ConsoleKey.Escape); //enquanto o usuario nao apertar ESC

      Save(text);
    }

    static void Save(string text)
    {
      Console.Clear();

      Console.WriteLine("What's the path?");
      Console.WriteLine("---------------------------");
      var path = Console.ReadLine();

      using (var file = new StreamWriter(path ?? "")) // abre e fecha o arquivo
      {
        file.Write(text); //escreve o texto no arquivo
      }

      Console.WriteLine("---------------------------");
      Console.WriteLine($"File {path} saved with success!");
      Thread.Sleep(2000);
      Menu();
    }
  }
}