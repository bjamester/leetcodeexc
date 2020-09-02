using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExc
{
    class RemoveLinkedListElements : IRunnable
    {
        public void Run()
        {
            RunWith(new int[] { 6, 1, 2, 6, 3, 4, 5, 6 }, 6);
        }

        public void RunWith(int[] elements, int ivalidValue)
        {
            var inputList = BuildList(elements);
            var inputListInString = ConvertToString(inputList);
            var outputList = RemoveElements(inputList, ivalidValue);

            Console.WriteLine($"       Input: [{inputListInString}] <-- {ivalidValue}");
            Console.WriteLine($"       Result: [{ConvertToString(outputList)}]");
        }

        private ListNode BuildList(int[] elements)
        {
            var head = new ListNode();
            var current = head;
            ListNode prev = null;
            
            foreach(var element in elements)
            {
                current.val = element;

                if (prev != null)
                    prev.next = current;

                prev = current;
                current = new ListNode();
            }

            return head;
        }

        private string ConvertToString(ListNode list)
        {
            ListNode curr = list;
            var resultList = new List<int>();
            while(curr != null)
            {
                resultList.Add(curr.val);
                curr = curr.next;
            }

            return string.Join(',', resultList);
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode first = head;
            ListNode prev = null;
            ListNode curr = null;

            MoveWhileInvalid(ref first, val);
            curr = first;

            while (curr != null)
            {
                MoveWhileInvalid(ref curr, val);

                if (prev != null)
                {
                    prev.next = curr;
                }
                
                prev = curr;
                curr = curr?.next;
            }

            return first;
        }

        private void MoveWhileInvalid(ref ListNode curr, int val)
        {
            while (curr != null && curr.val == val)
            {
                curr = curr.next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            return $"ListNode: val:{val}; hasNext:{next != null}";
        }
    }
}
