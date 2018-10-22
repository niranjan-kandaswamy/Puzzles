using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    public class Puzzle21
    {

        BTNode _rootNode = null;
        LinkedList _currItem = null;
        LinkedList _startItem = null;

        public Puzzle21()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 21.");
            Console.WriteLine("This program Creates Binary Tree, Prints, converts BT to Double linked list ");

            int[] arr = GenerateArray(10, 50);//new int[] { 10, 7, 5, 12 };
            PrintArray(arr);
            BuildBinaryTree(arr);
        }

        private int[] GenerateArray(int length, int maxValue)
        {
            Random r = new Random();
            int[] arr = new int[length];
            int n = 0;
            for (int i = 0; i < length; i++)
            {
                do
                {
                    n = r.Next(maxValue);
                } while (Contains(arr, n));
                arr[i] = n;
            }
            return arr;
        }

        private bool Contains(int[] arr, int n)
        {
            foreach ( int a in arr)
            {
                if ( a == n)
                {
                    return true;
                }
            }
            return false;
        }

        private void PrintArray(int[] arr)
        {
            Console.WriteLine("Printing Array");
            foreach (int i in arr)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
        }

        private void BuildBinaryTree(int[] arr)
        {
            _rootNode = new BTNode();
            _rootNode.Data = arr[0];
            BuildTree(_rootNode, arr, 1);
            PrintTree(_rootNode);
            Console.WriteLine("");
            Console.WriteLine("Converting to Linked List");
            ConvertToLinkedList(_rootNode);
            PrintLinkedList();
        }

        private void BuildTree(BTNode rootNode, int[] arr, int index)
        {
            if (index >= arr.Length || rootNode == null )
            {
                return;
            }

            BTNode node = SearchTree(rootNode, arr[index]);
            if ( node != null )
            {
                if ( arr[index] > node.Data)
                {
                    node.Right = new BTNode();
                    node.Right.Data = arr[index];
                }
                else if (arr[index] < node.Data)
                {
                    node.Left = new BTNode();
                    node.Left.Data = arr[index];
                }
                else
                {
                    Console.WriteLine("Number '{0}' already found, skipping index = {1} ", arr[index], index);
                    index++;
                }
            }

            if (index < arr.Length)
            {
                BuildTree(rootNode, arr, ++index);
            }
        }

        private void PrintTree(BTNode node)
        {
            if (node != null)
            {
                Console.Write("{0} ", node.Data);
            }

            if (node.Left != null)
            {
                Console.WriteLine("Left =>");
                PrintTree(node.Left);
            }

            if ( node.Right != null )
            {
                Console.WriteLine("Right =>");
                PrintTree(node.Right);
            }
        }

        private BTNode SearchTree(BTNode node, int data)
        {
            if (node != null)
            {
                if (data > node.Data)
                {
                    if (node.Right != null)
                    {
                        return SearchTree(node.Right, data);
                    }
                }
                else if (data < node.Data)
                {
                    if (node.Left != null)
                    {
                        return SearchTree(node.Left, data);
                    }
                }
            }

            return node;
        }

        private void ConvertToLinkedList(BTNode node)
        {
            if ( node == null)
            {
                return;
            }

            ConvertToLinkedList(node.Left);
            AddNewLinkedListItem(node.Data);
            ConvertToLinkedList(node.Right);
        }

        private void AddNewLinkedListItem(int data)
        {
            //Console.Write("{0} ", data);
            if ( _currItem == null)
            {
                _currItem = new LinkedList();
                _startItem = _currItem;
                _currItem.Data = data;
            }
            else
            {
                LinkedList item = new LinkedList();
                item.Data = data;
                _currItem.NextItem = item;
                item.PrevItem = _currItem;
                _currItem = item;
            }
        }

        private void PrintLinkedList()
        {
            Console.WriteLine("Printing Linked List in forward direction:");
            
            for(_currItem = _startItem; _currItem != null ; _currItem = _currItem.NextItem)
            {
                Console.Write("{0} ", _currItem.Data);
            }

            Console.WriteLine("\r\nPrinting Linked List in reverse direction:");
            for (_currItem = _startItem; _currItem.NextItem != null; _currItem = _currItem.NextItem) ;

            for (; _currItem != null; _currItem = _currItem.PrevItem)
            {
                Console.Write("{0} ", _currItem.Data);
            }

        }

        /*
        private void ConvertToDLL(BTNode rootNode)
        {
            _currItem = new LinkedList();
            BuildDLL(rootNode);
        }

        private BTNode BuildDLL(BTNode rootNode)
        {
            if (rootNode == null)
            {
                return rootNode;
            }
            rootNode = GetLeftMostNode(rootNode);

            return rootNode;

        }

        private BTNode GetLeftMostNode(BTNode rootNode)
        {
            BTNode leftNode = rootNode;
            for (; leftNode.Left != null; leftNode = leftNode.Left) ;

            return leftNode;
        }

        */
        //private void BuildDLL(LinkedList dll, BTNode node, BTNode parentNode, bool rightFlag)
        //{
        //    if (node != null)
        //    {
        //        if (rightFlag == false)
        //        {
        //            if (node.Left != null)
        //            {
        //                parentNode = node;
        //                BuildDLL(dll, node.Left, parentNode, false);
        //                dll.NextItem = new LinkedList();
        //                dll.NextItem.Data = node.Data;
        //                dll.NextItem.PrevItem = dll;
        //                dll = dll.NextItem;
        //            }
        //            else
        //            {
        //                dll.Data = node.Data;
        //                dll.PrevItem = null;
        //                return;
        //            }
        //        }

        //        if (node.Right != null)
        //        {
        //            parentNode = node;
        //            BuildDLL(dll, node.Right, parentNode, true);
        //            dll.NextItem = null;
        //            //dll.NextItem.Data = node.Data;
        //        }
        //        else
        //        {
        //            dll.NextItem = new LinkedList();
        //            dll.NextItem.Data = node.Data;
        //            dll.NextItem.PrevItem = dll;
        //            dll = dll.NextItem;
        //        }
        //    }
        //}

        private LinkedList GetLinkedListItem(BTNode node)
        {
            LinkedList item = new LinkedList
            {
                Data = node.Data,
                PrevItem = null,
                NextItem = null
            };

            return item;
        }

        /*
        private void BuildTree_OLD(BTNode rootNode, BTNode currNode, int[] arr, int index)
        {
            if (index >= arr.Length || rootNode == null || currNode == null)
            {
                return;
            }

            if (currNode.Data == arr[index])
            {
                Console.WriteLine("Number '{0}' already found, skipping index = {1} ", arr[index], index);
                index++;
                BuildTree_OLD(rootNode, currNode, arr, ++index);
            }

            if (arr[index] > currNode.Data)
            {
                if (currNode.Right != null)
                {
                    BuildTree_OLD(rootNode, currNode.Right, arr, index);
                }
                else
                {
                    currNode.Right = new BTNode();
                    currNode.Right.Data = arr[index];
                    currNode = currNode.Right;
                }
            }
            else if (arr[index] < currNode.Data)
            {
                if (currNode.Left != null)
                {
                    BuildTree_OLD(rootNode, currNode.Left, arr, index);
                }
                else
                {
                    currNode.Left = new BTNode();
                    currNode.Left.Data = arr[index];
                    currNode = currNode.Left;
                }
            }

            if (index < arr.Length)
            {
                BuildTree_OLD(rootNode, currNode, arr, ++index);
            }
        }
        */
    }


    internal class BTNode
    {
        BTNode _left = null;
        BTNode _right = null;
        int _data;

        public BTNode()
        {
            _left = _right = null;
        }

        public BTNode(BTNode left, BTNode right, int data)
        {
            _left = left;
            _right = right;
            _data = data;
        }

        public BTNode Left
        {
            get { return _left; }
            set { _left = value; }
        }
        public BTNode Right
        {
            get { return _right; }
            set { _right = value; }
        }
        public int Data
        {
            get { return _data; }
            set { _data = value; }
        }

    }

    internal class LinkedList
    {
        public LinkedList()
        {

        }

        private LinkedList _prevItem = null;
        private LinkedList _nextItem = null;
        private int _data;

        public LinkedList PrevItem
        {
            get { return _prevItem; }
            set { _prevItem = value; }
        }

        public LinkedList NextItem
        {
            get { return _nextItem; }
            set { _nextItem = value; }
        }

        public int Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
