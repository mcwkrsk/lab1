// Узел дерева, содержащий значение и список дочерних узлов
public class TreeNode<T>
{
    public T Value { get; set; }
    public List<TreeNode<T>> Children { get; }

    public TreeNode(T value)
    {
        Value = value;
        Children = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> child) => Children.Add(child); 

    // Рекурсивный вывод всех значений узла и его потомков
    public void PrintAllValues(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent * 2)}{Value}");
        foreach (var child in Children)
            child.PrintAllValues(indent + 1);
    }
}