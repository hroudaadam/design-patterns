namespace ConsoleApp.Behavioral.Memento;

public static class MementoExample
{
    public static void Run()
    {
        TextEditor textEditor = new();

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("W - write | U - undo | any - exit");
            Console.Write(textEditor.Buffer);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    textEditor.Write(Console.ReadLine());
                    break;
                case ConsoleKey.U:
                    textEditor.Undo();
                    break;
                default:
                    exit = true;
                    break;
            }
        }
    }
}

// originator
public class TextBuffer
{
    public string State { get; private set; }

    public void Write(string value)
    {
        State += value;
    }

    public TextBufferMemento Save()
    {
        return new TextBufferMemento(State);
    }

    public void Restore(TextBufferMemento memento)
    {
        State = memento.State;
    }
}

// memento
public class TextBufferMemento
{
    public string State { get; }
 
    public TextBufferMemento(string state)
    {
        State = state;
    }
}

// caretaker
public class TextEditor
{
    private readonly TextBuffer _buffer = new();
    private readonly Stack<TextBufferMemento> _history = new();

    public string Buffer
    {
        get 
        {
            return _buffer.State; 
        }
    }

    public TextEditor()
    {
        _history.Push(_buffer.Save());
    }

    public void Write(string value)
    {
        _buffer.Write(value);
        _history.Push(_buffer.Save());
    }

    public void Undo()
    {
        if (_history.Count <= 1) return;
        _history.Pop();
        _buffer.Restore(_history.Peek());
    }
}