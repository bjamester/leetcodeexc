using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class AddAndSearchWord : IRunnable
    {
        public void Run()
        {
            var actions = new string[] { "WordDictionary", "AddWord", "AddWord", "AddWord", "AddWord", "Search", "Search", "AddWord", "Search", "Search", "Search", "Search", "Search", "Search" };
            var actionParams = new string[] { "", "at", "and", "an", "add", "a", ".at", "bat", ".at", "an.", "a.d.", "b.", "a.d", "." };
            // Expected:                [null,null, null,  null, null, false,false, null,  true,  true,  false, false, true, false]
            RunWith(actions, actionParams);
        }

        private void RunWith(string[] actions, string[] actionParams)
        {
            var wordDict = new WordDictionary();

            for (int i = 1; i < actions.Length; i++)
            {
                var result = CallMethod(wordDict, actions[i], actionParams[i]);
                Logger.LogLine($"{actions[i]}({actionParams[i]}) -> {result}");
            }

            Logger.LogLine(Environment.NewLine + "Same with previous WordDict solution:");
            var wordDict1 = new WordDictionary1();
            for (int i = 1; i < actions.Length; i++)
            {
                var result = CallMethod(wordDict1, actions[i], actionParams[i]);
                Logger.LogLine($"{actions[i]}({actionParams[i]}) -> {result}");
            }
        }

        private object CallMethod(object obj, string method, string param)
        {
            var methodInfo = obj.GetType().GetMethod(method);
            return methodInfo.Invoke(obj, new[] { param });
        }

        private void LogSearch(WordDictionary words, string word)
        {
            Logger.LogLine($"Search({word}) -> {words.Search(word)}");
        }
    }

    public class WordDictionary1
    {
        private SortedSet<string> _words = null;

        /** Initialize your data structure here. */
        public WordDictionary1()
        {
            _words = new SortedSet<string>();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            _words.Add(word);
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return _words.Contains(word, new WordComparer());
        }

        class WordComparer : IEqualityComparer<string>
        {
            public bool Equals([AllowNull] string x, [AllowNull] string y)
            {
                if (x == null || y == null || x.Length != y.Length)
                    return string.Equals(x, y);

                var isEqual = true;
                var pos = 0;
                while (isEqual && pos < x.Length)
                {
                    isEqual = x[pos] == y[pos] || x[pos] == '.' || y[pos] == '.';
                    pos++;
                }

                return isEqual;
            }

            public int GetHashCode([DisallowNull] string obj)
            {
                return obj.GetHashCode();
            }
        }
    }

    public class WordDictionary
    {
        private Trie _trie = null;

        /** Initialize your data structure here. */
        public WordDictionary()
        {
            _trie = new Trie();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            _trie.Insert(word);
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            // return _trie.Search(word);
            return _trie.IsMatch(word);
        }

        class Node
        {
            public char Value { get; set; }
            public List<Node> Children { get; set; }
            public Node Parent { get; set; }
            public int Depth { get; set; }

            public Node(char value, int depth, Node parent)
            {
                Value = value;
                Children = new List<Node>();
                Depth = depth;
                Parent = parent;
            }

            public bool IsLeaf()
            {
                return Children.Count == 0;
            }

            public Node FindChildNode(char c)
            {
                return Children.FirstOrDefault(n => n.Value == c);
            }

            public void DeleteChildNode(char c)
            {
                Children.RemoveAll(n => n.Value == c);
            }
        }

        class Trie
        {
            private readonly Node _root;

            public Trie()
            {
                _root = new Node('^', 0, null);
            }

            public Node Prefix(string s)
            {
                var currentNode = _root;
                var result = currentNode;

                foreach (var c in s)
                {
                    currentNode = currentNode.FindChildNode(c);
                    if (currentNode == null)
                        break;
                    result = currentNode;
                }

                return result;
            }

            public bool IsMatch(string s)
            {
                return HasMatch(s, 0, _root);
            }

            private bool HasMatch(string s, int pos, Node current)
            {
                if (s.Length == pos)
                {
                    return current.FindChildNode('$') != null;
                }

                if(s[pos] == '.')
                {
                    foreach (var child in current.Children)
                        if (HasMatch(s, pos + 1, child))
                            return true;
                }
                else
                {
                    var child = current.FindChildNode(s[pos]);
                    if (child == null)
                        return false;

                    return HasMatch(s, pos + 1, child);
                }

                return false;
            }

            public bool Search(string s)
            {
                var prefix = Prefix(s);
                return prefix.Depth == s.Length && prefix.FindChildNode('$') != null;
            }

            public void InsertRange(List<string> items)
            {
                for (int i = 0; i < items.Count; i++)
                    Insert(items[i]);
            }

            public void Insert(string s)
            {
                var commonPrefix = Prefix(s);
                var current = commonPrefix;

                for (var i = current.Depth; i < s.Length; i++)
                {
                    var newNode = new Node(s[i], current.Depth + 1, current);
                    current.Children.Add(newNode);
                    current = newNode;
                }

                current.Children.Add(new Node('$', current.Depth + 1, current));
            }

            public void Delete(string s)
            {
                if (Search(s))
                {
                    var node = Prefix(s).FindChildNode('$');

                    while (node.IsLeaf())
                    {
                        var parent = node.Parent;
                        parent.DeleteChildNode(node.Value);
                        node = parent;
                    }
                }
            }
        }
    }
        /**
         * Your WordDictionary object will be instantiated and called as such:
         * WordDictionary obj = new WordDictionary();
         * obj.AddWord(word);
         * bool param_2 = obj.Search(word);
         */

}
