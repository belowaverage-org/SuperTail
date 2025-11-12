using System.Diagnostics;
using System.Text.RegularExpressions;
using Timer = System.Windows.Forms.Timer;

namespace SuperTail
{
    public partial class fMain : Form
    {
        private List<string> CheckedItems = new();
        private List<string> SelectedFiles = new();
        private SemaphoreSlim EnumFilesInScopeSS = new(1);
        private Process CurrentProcess = Process.GetCurrentProcess();
        private double LastTotalProcessorTime = 0;
        private Timer UpdateIndicatorsTimer = new()
        {
            Enabled = true,
            Interval = 500
        };
        public fMain()
        {
            InitializeComponent();
            tvMain.BeforeExpand += TvMain_BeforeExpand;
            UpdateIndicatorsTimer.Tick += UpdateIndicatorsTimer_Tick;
            tbPath_TextChanged(null, null);
        }

        private void UpdateIndicatorsTimer_Tick(object? sender, EventArgs e)
        {
            CurrentProcess.Refresh();
            tsslMemory.Text = $"Mem: {CurrentProcess.PrivateMemorySize64 / 1024 / 1024} MB";
            tsslCPU.Text = $"CPU: {(int)(CurrentProcess.TotalProcessorTime.TotalMicroseconds - LastTotalProcessorTime) / 50000}%";
            LastTotalProcessorTime = CurrentProcess.TotalProcessorTime.TotalMicroseconds;
        }

        private void TvMain_BeforeExpand(object? sender, TreeViewCancelEventArgs e)
        {
            e.Node?.Nodes.Clear();
            if (e.Node != null && e.Node.Tag != null)
            {
                EnumerateTree(e.Node.Nodes, (DirectoryInfo)e.Node.Tag);
                UpdateNodeCheckedStatus(e.Node);
            }
        }
        private void AddNode(TreeNodeCollection ParentNode, DirectoryInfo Directory)
        {
            TreeNode node = new()
            {
                Text = Directory.Name,
                Tag = Directory
            };
            node.Nodes.Add("Loading...");
            ParentNode.Add(node);
        }
        private void AddNode(TreeNodeCollection ParentNode, FileInfo File)
        {
            TreeNode node = new()
            {
                Text = File.Name,
                Tag = File
            };
            if (Regex.IsMatch(File.Name, tbFilter.Text))
            {
                ParentNode.Add(node);
            }
        }
        private void UpdateNodeCheckedStatus(TreeNode Node, bool SkipRoot = false)
        {
            if (!SkipRoot)
            {
                string path = string.Empty;
                if (Node.Tag?.GetType() == typeof(FileInfo)) path = ((FileInfo)Node.Tag).FullName;
                if (Node.Tag?.GetType() == typeof(DirectoryInfo))
                {
                    path = ((DirectoryInfo)Node.Tag).FullName;
                    if (!Path.EndsInDirectorySeparator(path)) path += '\\';
                }
                Node.Checked = CheckedItems.Contains(path) || SelectedFiles.Contains(path);
            }
            foreach (TreeNode child in Node.Nodes)
            {
                UpdateNodeCheckedStatus(child);
            }
        }
        private void EnumerateTree(TreeNodeCollection Node, DirectoryInfo Directory)
        {
            try
            {
                foreach (DirectoryInfo dir in Directory.GetDirectories())
                {
                    AddNode(Node, dir);
                }
                foreach (FileInfo file in Directory.GetFiles())
                {
                    AddNode(Node, file);
                }
            }
            catch { }
        }
        private void tbPath_TextChanged(object? sender, EventArgs? e)
        {
            tvMain.Nodes.Clear();
            try
            {
                AddNode(tvMain.Nodes, new DirectoryInfo(tbPath.Text));
                tvMain.Nodes[0].Expand();
            }
            catch { }
        }

        private async void tvMain_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown) return;
            tlpFileTree.Enabled = false;
            _ = StopWatcher();
            string path = string.Empty;
            bool dirEvent = false;
            if (e.Node?.Tag?.GetType() == typeof(FileInfo))
            {
                path = ((FileInfo)e.Node.Tag).FullName;
                if (e.Node!.Checked)
                {
                    SelectedFiles.Remove(path);
                }
                else
                {
                    SelectedFiles.Add(path);
                }
            }
            if (e.Node?.Tag?.GetType() == typeof(DirectoryInfo))
            {
                dirEvent = true;
                path = ((DirectoryInfo)e.Node.Tag).FullName;
                if (!Path.EndsInDirectorySeparator(path)) path += '\\';
            }
            if (e.Node!.Checked)
            {
                CheckedItems.Remove(path);
            }
            else
            {
                CheckedItems.Add(path);
            }
            if (dirEvent) await EnumerateFilesInScope(CheckedItems, tbFilter.Text, SelectedFiles, EnumFilesInScopeSS);
            UpdateNodeCheckedStatus(e.Node, true);
            tsslSelected.Text = $"Selected: {SelectedFiles.Count}";
            _ = StartWatcher();
            tlpFileTree.Enabled = true;
        }
        private async Task StartWatcher()
        {
            //rtbMain.
            
            foreach (string file in SelectedFiles)
            {
                //rtbMain.AppendText(await File.ReadAllTextAsync(file));
                StreamReader sr = File.OpenText(file);
                while (sr.EndOfStream == false)
                {
                    rtbMain.AppendText(await sr.ReadLineAsync() + '\n');
                }
            }
        }
        private async Task StopWatcher()
        {
            rtbMain.Text = string.Empty;
        }
        private async Task EnumerateFilesInScope(List<string> DirectoriesAndFiles, string Filter, List<string> OutFilesInScope, SemaphoreSlim SS)
        {
            OutFilesInScope.Clear();
            foreach (string item in DirectoriesAndFiles)
            {
                if (Path.EndsInDirectorySeparator(item))
                {
                    await EnumerateFilesInScopeWorker(new DirectoryInfo(item), Filter, OutFilesInScope, SS);
                }
                else
                {
                    OutFilesInScope.Add(item);
                }
            }
        }
        private Task EnumerateFilesInScopeWorker(DirectoryInfo StartingDirectory, string Filter, List<string> OutFilesInScope, SemaphoreSlim SS)
        {
            return Task.Run(() =>
            {
                //if (Main.Canceled) return 0;
                if (StartingDirectory.Attributes.HasFlag(FileAttributes.ReparsePoint)) return;
                try
                {
                    List<Task> childTasks = new List<Task>();
                    foreach (DirectoryInfo subDir in StartingDirectory.EnumerateDirectories())
                    {
                        //if (Main.Canceled) return 0;
                        childTasks.Add(EnumerateFilesInScopeWorker(subDir, Filter, OutFilesInScope, SS));
                        SS.Wait();
                        Invoke(() => { tsslSelected.Text = $"Selecting: {OutFilesInScope.Count}"; });
                        SS.Release();
                    }
                    foreach (FileInfo file in StartingDirectory.EnumerateFiles())
                    {
                        //if (Main.Canceled) return 0;
                        SS.Wait();
                        bool exists = OutFilesInScope.Contains(file.FullName);
                        SS.Release();
                        //Check if file is in scope placeholder
                        if (!exists && Regex.IsMatch(file.Name, Filter))
                        {
                            SS.Wait();
                            OutFilesInScope.Add(file.FullName);
                            SS.Release();
                        }
                    }
                    Task.WaitAll(childTasks.ToArray());
                }
                catch (Exception e)
                {
                    //Logger.Exception(e, Language.Get("Class/FileOperations/Log/Failed/GetFolderSize"));
                }
            });
        }

        private void tsmiShowFileTree_Click(object sender, EventArgs e)
        {
            tsmiShowFileTree.Checked = !tsmiShowFileTree.Checked;
            scMain.Panel1Collapsed = !tsmiShowFileTree.Checked;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
