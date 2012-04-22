﻿// 
// RTreeNode.cs
//  
// Author:
//       Andriy Kupershmidt <kuper133@googlemail.com>
// 
// Copyright (c) 2011 Henning Rauch
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fallen8.API.Index.Spatial.Implementation.SpatialContainer;

namespace Fallen8.API.Index.Spatial.Implementation.RTree
{
    /// <summary>
    /// internal node of r-tree
    /// </summary>
    public class RTreeNode : ARTreeContainer
    {
        public RTreeNode()
        {
            this.Children = new List<ARTreeContainer>();
        }
        public RTreeNode(IMBR myMBR, IEnumerable<ARTreeContainer> children = null, ARTreeContainer parent = null)
        {
            if (parent != null)
                this.Parent = parent;
            this.LowerPoint = myMBR.LowerPoint;
            this.UpperPoint = myMBR.UpperPoint;
            if (children != null)
                this.Children = new List<ARTreeContainer>(children);
            else
                this.Children = new List<ARTreeContainer>();
        }

        public RTreeNode(Double[] lower,
                        Double[] upper, IEnumerable<ARTreeContainer> children = null, ARTreeContainer parent = null)
        {
            if (parent != null)
                this.Parent = parent;
            this.LowerPoint = lower;
            this.UpperPoint = upper;
            if (children != null)
                this.Children = new List<ARTreeContainer>(children);
            else
                this.Children = new List<ARTreeContainer>();
        }
        override public Boolean IsLeaf { get { return false; } }
        public List<ARTreeContainer> Children { get; set; }


        public override void Dispose()
        {
            this.Children.Clear();
            Children = null;
            Parent = null;
            this.LowerPoint = null;
            this.UpperPoint = null;
        }
    }
}
