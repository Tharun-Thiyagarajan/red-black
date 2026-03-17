using redblackBalancedTree.Models;

namespace redblackBalancedTree
{
public partial class Form1 : Form
{
// instance of rbTree class
rbTree rbtree = new rbTree();
public Form1()
{
InitializeComponent();
treeViewRB.ImageList = imageList1; // assign imagelist
}

private void InsertBTN_Click(object sender, EventArgs e)
{
if (InputNumber.Text.Length > 0)
{
rbtree.insert(Convert.ToInt16(InputNumber.Text)); // convert text to integer

DisplayInOrderTree(rbtree);
}
}

void DisplayInOrderTree(rbTree tree)
{
int TempColor = 0;
if (rbtree.root.color == rbNodeColor.Black)
{
TempColor = 0;
}
else
{
TempColor = 1;
}

TreeNode trTemp = new TreeNode("Root: " + rbtree.root.key);
trTemp.ImageIndex = GetColor(rbtree.root.color);
trTemp.SelectedImageIndex = GetColor(rbtree.root.color);
treeViewRB.Nodes.Add(trTemp);

ShowNode(rbtree.root, trTemp);

}

void ShowNode(rbNode node, TreeNode treeNode)
{
if (node.left != null)
{
int TempColor = 0;
if (rbtree.root.color == rbNodeColor.Black)
{
TempColor = 0;
}
else
{
TempColor = 1;
}

TreeNode trTemp = new TreeNode("Left: " + node.left.key);


trTemp.ImageIndex = GetColor(node.left.color);
trTemp.SelectedImageIndex = GetColor(node.left.color);
treeNode.Nodes.Add(trTemp);
ShowNode(node.left, trTemp);
}

if (node.right != null)
{
int TempColor = 0;
if (rbtree.root.color == rbNodeColor.Black)
{
TempColor = 0;
}
else
{
TempColor = 1;
}
TreeNode trTemp = new TreeNode("Rightt: " + node.right.key);


trTemp.ImageIndex = GetColor(node.right.color);
trTemp.SelectedImageIndex = GetColor(node.right.color);
treeNode.Nodes.Add(trTemp);
ShowNode(node.right, trTemp);
}
}

public int GetColor(rbNodeColor nodeColor)
{
int indexValue = 0;
if (nodeColor == rbNodeColor.Black)
{
indexValue = 0;
}
else
{
indexValue = 1;
}

return indexValue;
}

private void clearBTN_Click(object sender, EventArgs e)
{
treeViewRB.Nodes.Clear();
}
}
}