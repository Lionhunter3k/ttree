﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TTree
{
	/// <summary>
	/// Root of a TTree. This class delegates all calls to the root node of the TTree.
	/// The reason for using it is that as the TTree is modified and balanced the root 
	/// node will change. Without this class you would always have to call 
	/// currentNode.Root.Method(). 
	/// 
	/// Using this class means that you are always working with the root node as 
	/// you should be. 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class TTreeRoot<T> : ITTreeNode<T>
		where T : IComparable
	{
		public TTreeRoot( int minimum, int maximum )
		{
			RootNode = new TTreeNode<T>( minimum, maximum, this );
		}

		public TTreeNode<T> RootNode { get; protected internal set; }

		#region ITreeNode delegating to actual root node
		public bool AddItem( T item )
		{
			return RootNode.AddItem( item );
		}

		public T Search<TSearch>( TSearch item, Func<TSearch, T, int> comparer )
		{
			return RootNode.Search<TSearch>( item, comparer );
		}

		public T Search( T item )
		{
			return RootNode.Search( item );
		}

		public SearchResult<T> SearchFor( T item )
		{
			return RootNode.SearchFor( item );
		}

		public SearchResult<T> SearchFor<TSearch>( TSearch item, Func<TSearch, T, int> comparer )
		{
			return RootNode.SearchFor( item, comparer );
		}

		public void CopyItems( T[] destinationArray, int index )
		{
			RootNode.CopyItems( destinationArray, index );
		}

		public bool Remove( T item )
		{
			return RootNode.Remove( item );
		}

		public void Add( T item )
		{
			RootNode.Add( item );
		}

		public void Clear()
		{
			RootNode.Clear();
		}

		public bool Contains( T item )
		{
			return RootNode.Contains( item );
		}

		public void CopyTo( T[] array, int arrayIndex )
		{
			RootNode.CopyTo( array, arrayIndex );
		}

		public string ToDot( Func<T, string> toString )
		{
			return RootNode.ToDot( toString );
		}

		public string ToDot()
		{
			return RootNode.ToDot();
		}

		public TTreeNode<T> Left
		{
			get { return RootNode.Left; }
			set { RootNode.Left = value; }
		}

		public TTreeNode<T> Right
		{
			get { return RootNode.Right; }
			set { RootNode.Right = value; }
		}

		public TTreeNode<T> Parent
		{
			get { return RootNode.Parent; }
			set { RootNode.Parent = value; }
		}

		public int Count { get { return RootNode.Count; } }
		public int ItemCount { get { return RootNode.ItemCount; } }
		public int Height { get { return RootNode.ItemCount; } }
		public bool IsLeaf { get { return RootNode.IsLeaf; } }
		public bool IsHalfLeaf { get { return RootNode.IsHalfLeaf; } }
		public bool IsInternal { get { return RootNode.IsInternal; } }
		public int MaxItems { get { return RootNode.MaxItems; } }
		public TTreeRoot<T> Root { get { return RootNode.Root; } }
		public Indexer<T> NodeData { get { return RootNode.NodeData; } }
		public int BalanceFactor { get { return RootNode.BalanceFactor; } }
		public bool IsReadOnly { get { return RootNode.IsReadOnly; } }
		#endregion

		#region IEnumerable delegating to root node
		public IEnumerator<T> GetEnumerator()
		{
			return RootNode.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return RootNode.GetEnumerator();
		}
		#endregion
	}
}
