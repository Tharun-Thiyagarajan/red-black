using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redblackBalancedTree.Models
{

public enum rbNodeColor
{
Red,
Black
}

class rbNode
{
public int key;
public rbNodeColor color;
public rbNode left, right, parent;


public rbNode(int item)
{
key = item;
color = rbNodeColor.Red;
left = right = parent = null;

/* left = null;
right = null;
parent = null;*/

}
}

class rbTree
{
public rbNode root;
private rbNode nullNode;

public rbTree()
{
nullNode = new rbNode(0);
nullNode.color = rbNodeColor.Black;
root = nullNode;
}

public void insert(int key)
{
rbNode newNode = new rbNode(key);

//
InsertNode(newNode);

FixInsert(newNode);
}

private void FixInsert(rbNode newNode)
{
while (newNode.parent.color == rbNodeColor.Red)
{
if (newNode.parent == newNode.parent.parent.left)
{
rbNode uncle = newNode.parent.parent.right;
if (uncle.color == rbNodeColor.Red) // Flip
{
newNode.parent.color = rbNodeColor.Black;
uncle.color = rbNodeColor.Black;
newNode.parent.parent.color = rbNodeColor.Black;
newNode = newNode.parent.parent;
}
else
{

if (newNode == newNode.parent.right)
{
newNode = newNode.parent;
//Rotate left
RotateLeft(newNode);

}
newNode.parent.color = rbNodeColor.Black;
newNode.parent.parent.color = rbNodeColor.Red;

// Rotate Right
RotateRight(newNode.parent.parent);

}
}
else
{
rbNode uncle = newNode.parent.parent.left;
if (uncle.color == rbNodeColor.Red) // Flip
{
newNode.parent.color = rbNodeColor.Black;
uncle.color = rbNodeColor.Black;
newNode.parent.parent.color = rbNodeColor.Black;
newNode = newNode.parent.parent;
}
else
{

if (newNode == newNode.parent.left)
{
newNode = newNode.parent;
//Rotate right
RotateRight(newNode);

}
newNode.parent.color = rbNodeColor.Black;
newNode.parent.parent.color = rbNodeColor.Red;

// Rotate left
RotateLeft(newNode.parent.parent);
}
}


}
root.color = rbNodeColor.Black;
}

private void RotateLeft(rbNode x)
{
rbNode y = x.right;
x.right = y.left;

if (y.left != nullNode)
{
y.left.parent = x;
}

y.parent = x.parent;

if (x.parent == nullNode)
{
root = y;
}else if (x == x.parent.left)
{
x.parent.left = y;
}
else
{
x.parent.right = y;
}

y.left = x;
x.parent = y;


}
private void RotateRight(rbNode x)
{
rbNode y = x.left;
x.left = y.right;

if (y.right != nullNode)
{
y.right.parent = x;
}

y.parent = x.parent;

if (x.parent == nullNode)
{
root = y;
}
else if (x == x.parent.right)
{
x.parent.right = y;
}
else
{
x.parent.left = y;
}

y.right = x;
x.parent = y;
}

private void InsertNode(rbNode newNode)
{
rbNode current = root;
rbNode parent = nullNode;

while (current != nullNode)
{

parent = current;
if (newNode.key < current.key)
{
current = current.left;
}
else
{
current = current.right;
}


}

newNode.parent = parent;

if (parent == nullNode)


{
root = newNode;
}
else if (newNode.key < parent.key)
{
parent.left = newNode;
}
else
{
parent.right = newNode;
}

newNode.left = nullNode;
newNode.right = nullNode;
newNode.color = rbNodeColor.Red;
}
}

internal class RedBlackTree
{
}
}