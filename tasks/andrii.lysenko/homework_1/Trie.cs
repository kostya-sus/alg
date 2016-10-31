namespace text_spacing
{
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
                    if (KeyIsLastSymbol(key))
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
                    if (KeyIsLastSymbol(key))
                    {
                        child.IsWord = true;
                        return;
                    }
                    Add(child, rest);
                    return;
                }
            }

            var newNode = new TrieNode {IsWord = KeyIsLastSymbol(key), Key = symbol};
            node.AddChild(newNode);
            if (KeyIsLastSymbol(key))
            {
                Add(newNode, rest);
            }
        }

        private bool KeyIsLastSymbol(string key)
        {
            return key.Length == 1;
        }
    }
}