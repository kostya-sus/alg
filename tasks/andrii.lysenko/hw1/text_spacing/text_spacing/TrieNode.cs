using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_spacing
{
    public class TrieNode
    {
        private readonly List<TrieNode> _children = new List<TrieNode>();
        public string Key { get; set; }
        public bool IsWord { get; set; }

        public List<TrieNode> Children
        {
            get { return _children; }
        }

        public void AddChild(TrieNode node)
        {
            _children.Add(node);
        }

        public void RemoveChild(TrieNode node)
        {
            _children.Remove(node);
        }
    }
}