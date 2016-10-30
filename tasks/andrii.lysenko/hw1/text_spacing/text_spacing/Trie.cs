namespace text_spacing
{
    public enum NodeExistance
    {
        NotExists,
        IsTransit,
        IsWord
    }

    public class Trie
    {
        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode {IsWord = false, Key = ""};
        }

        public void Add(string key)
        {
            Add(_root, key);
        }

        public NodeExistance Contains(string key)
        {
            return Contains(_root, key);
        }

        private NodeExistance Contains(TrieNode node, string key)
        {
            string rest = key.Substring(1);
            string symbol = key.Substring(0, 1);
            foreach (var child in node.Children)
            {
                if (child.Key == symbol)
                {
                    if (key.Length == 1)
                    {
                        return child.IsWord ? NodeExistance.IsWord : NodeExistance.IsTransit;
                    }
                    return Contains(child, rest);
                }
            }

            return NodeExistance.NotExists;
        }

        private void Add(TrieNode node, string key)
        {
            if (string.IsNullOrEmpty(key)) return;
            string rest = key.Substring(1);
            string symbol = key.Substring(0, 1);
            foreach (var child in node.Children)
            {
                if (child.Key == symbol)
                {
                    if (key.Length == 1)
                    {
                        child.IsWord = true;
                        return;
                    }
                    Add(child, rest);
                    return;
                }
            }

            var newNode = new TrieNode {IsWord = key.Length == 1, Key = symbol};
            node.AddChild(newNode);
            if (key.Length != 1)
            {
                Add(newNode, rest);
            }
        }
    }
}