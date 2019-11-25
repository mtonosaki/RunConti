using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tono;
using Tono.GuiWinForm;

namespace RunConti
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            comboBoxCommand.Text = ConfigRegister.Current["com", ""] as string;


            var fsp = new FormShapePersister(this);
            fsp.Loaded += fsp_Loaded;
        }

        private void fsp_Loaded(object sender, EventArgs e)
        {
            textBoxLog.Text = "Drag & drop files into the middle box.\r\n\r\n";
            LoadConfig();
        }

        private void listBoxComs_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBoxComs_DragDrop(object sender, DragEventArgs e)
        {
            ComBak();
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var file in files)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    Proc1(file, comboBoxCommand.Text);
                }
                else
                {
                    procN(file);
                }
            }
        }

        private void ComBak()
        {
            var com = comboBoxCommand.Text;
            ConfigRegister.Current["com"] = com;
        }

        private void AddLog(string txt)
        {
            textBoxLog.Text += txt + "\r\n";
            textBoxLog.SelectionStart = textBoxLog.Text.Length;
            textBoxLog.Focus();
            textBoxLog.ScrollToCaret();
        }

        private class ListViewItemComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                var v1 = ((ListViewItem)x).SubItems[0].Text;
                var v2 = ((ListViewItem)y).SubItems[0].Text;
                return int.Parse(v1) - int.Parse(v2);
            }
        }

        /// <summary>
        /// Change priority (Up)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prioUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l2 = listViewPatterns.SelectedIndices[0];
            var l1 = l2 - 1;
            var tmp = listViewPatterns.Items[l2].SubItems[0].Text;
            listViewPatterns.Items[l2].SubItems[0].Text = listViewPatterns.Items[l1].SubItems[0].Text;
            listViewPatterns.Items[l1].SubItems[0].Text = tmp;
            listViewPatterns.ListViewItemSorter = new ListViewItemComparer();
            listViewPatterns.Sort();
            SaveConfig();
        }

        /// <summary>
        /// Enable/Disable of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStripAddPattern_Opening(object sender, CancelEventArgs e)
        {
            tsmiDelPattern.Enabled = listViewPatterns.SelectedItems.Count > 0;
            editToolStripMenuItem.Enabled = listViewPatterns.SelectedItems.Count == 1;
            if (listViewPatterns.SelectedItems.Count == 1)
            {
                var lvi = listViewPatterns.SelectedItems[0];
                var prio = int.Parse(lvi.SubItems[0].Text);
                prioUpToolStripMenuItem.Enabled = prio > 1;
            }
        }

        private void listViewPatterns_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            SaveConfig();
        }

        private int maxItemNo = 0;


        private void SaveConfig()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"nPattern={listViewPatterns.Items.Count}");
            sb.AppendLine($"maxPatternNo={maxItemNo}");
            int no = 0;
            foreach (ListViewItem lvi in listViewPatterns.Items)
            {
                var key = $"Pattern.{++no}";
                var ed = lvi.Checked ? "enabled" : "disabled";
                var line = $"{key}\t{ed}\t{lvi.SubItems[0].Text}\t{lvi.SubItems[1].Text}\t{lvi.SubItems[2].Text}\t{lvi.SubItems[3].Text}\t{lvi.SubItems[4].Text}";
                sb.AppendLine(line);
            }
            var ininame = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "RunConti.ini");
            try
            {
                File.WriteAllText(ininame, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadConfig()
        {
            var ininame = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "RunConti.ini");
            try
            {
                var lines = File.ReadLines(ininame, Encoding.UTF8);
                var n = lines.Count();

                var lvis = new Dictionary<int, ListViewItem>();

                for (var i = 0; i < n; i++)
                {
                    var line = lines.ElementAt(i).Trim();
                    if (line.StartsWith("maxPatternNo=", StringComparison.CurrentCultureIgnoreCase))
                    {
                        maxItemNo = int.Parse(line.Substring(13));
                    }
                    if (line.StartsWith("Pattern.", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var coms = line.Substring(8).Trim().Split('\t');
                        if (coms.Length == 7)
                        {
                            int pri = int.Parse(coms[2]);
                            var lvi = new ListViewItem(new string[]{
                                pri.ToString(),
                                coms[3].Trim(),
                                coms[4].Trim(),
                                coms[5].Trim(),
                                coms[6].Trim(),
                            })
                            {
                                Checked = DbUtil.ToBoolean(coms[1], true)
                            };
                            lvis[pri] = lvi;
                        }
                        else
                        {
                            AddLog($"Error : Unknown format RunConti.ini");
                        }
                    }
                }
                var keys = new List<int>(lvis.Keys);
                keys.Sort();
                listViewPatterns.Items.Clear();
                for (int i = 0; i < keys.Count; i++)
                {
                    listViewPatterns.Items.Add(lvis[keys[i]]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Add pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAddPattern_Click(object sender, EventArgs e)
        {
            var fp = new FormPattern();
            fp.textBoxName.Text = $"Pattern {++maxItemNo}";
            fp.textBoxPatternReg.Text = ".*";
            fp.textBoxPatternExec.Text = "";
            fp.textBoxCommand.Text = (string)ConfigRegister.Current["com2", ""];
            if (fp.ShowDialog(this) == DialogResult.OK)
            {
                var lvi = new ListViewItem(new string[]{
                    $"{listViewPatterns.Items.Count + 1}",
                    fp.textBoxName.Text,
                    fp.textBoxPatternReg.Text,
                    fp.textBoxPatternExec.Text,
                    fp.textBoxCommand.Text,
                })
                {
                    Checked = true
                };
                listViewPatterns.Items.Add(lvi);
                SaveConfig();
            }
        }

        /// <summary>
        /// Remove pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDelPattern_Click(object sender, EventArgs e)
        {
            var dels = new List<ListViewItem>();
            foreach (ListViewItem id in listViewPatterns.SelectedItems)
            {
                dels.Add(id);
            }
            for (int i = dels.Count - 1; i >= 0; i--)
            {
                listViewPatterns.Items.Remove(dels[i]);
            }
            if (dels.Count > 0)
            {
                if (listViewPatterns.Items.Count == 0)
                {
                    maxItemNo = 0;
                }
                SaveConfig();
            }
        }

        /// <summary>
        /// Edit pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lvi = listViewPatterns.SelectedItems[0];
            var fp = new FormPattern();
            fp.textBoxName.Text = lvi.SubItems[1].Text;
            fp.textBoxPatternReg.Text = lvi.SubItems[2].Text;
            fp.textBoxPatternExec.Text = lvi.SubItems[3].Text;
            fp.textBoxCommand.Text = lvi.SubItems[4].Text;
            if (fp.ShowDialog(this) == DialogResult.OK)
            {
                lvi.SubItems[1].Text = fp.textBoxName.Text;
                lvi.SubItems[2].Text = fp.textBoxPatternReg.Text;
                lvi.SubItems[3].Text = fp.textBoxPatternExec.Text;
                lvi.SubItems[4].Text = fp.textBoxCommand.Text;
                SaveConfig();
            }
        }

        /// <summary>
        /// Exec command line (If file is directory, exec the inside files)
        /// </summary>
        /// <param name="file"></param>
        /// <param name="command"></param>
        private void Proc1(string file, string command)
        {
            if (Directory.Exists(file))
            {
                var files = Directory.GetFiles(file, "*.*", SearchOption.AllDirectories);
                foreach (var f in files)
                {
                    Proc1Main(f, command);
                }
            }
            else
            {
                Proc1Main(file, command);
            }
        }

        private string PeplaceCommandPattern(string strin, string file)
        {
            strin = strin.Replace("%F", file);
            strin = strin.Replace("%f", Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file)));
            return strin;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="file"></param>
        private void Proc1Main(string file, string command)
        {
            var com = command.Split(' ')[0];
            var args = command.Substring(com.Length);

            args = PeplaceCommandPattern(args, file);

            var log = $"{com} {args}";
            int lid = listBoxComs.Items.Add(log);
            listBoxComs.SelectedIndex = lid;
            AddLog("------------------------------");
            AddLog(log);
            Process proc = new Process();
            proc.StartInfo.FileName = com;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = false;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();

            var s1 = proc.StandardOutput.ReadToEnd();
            if (s1 != "")
            {
                AddLog(s1);
            }

            s1 = proc.StandardError.ReadToEnd();
            if (s1 != "")
            {
                AddLog(s1);
            }

            proc.WaitForExit();
        }

        /// <summary>
        /// Execute proc (pattern select)
        /// </summary>
        /// <param name="file"></param>
        private void procN(string file)
        {
            if (Directory.Exists(file))
            {
                var files = Directory.GetFiles(file, "*.*", SearchOption.AllDirectories);
                foreach (var f in files)
                {
                    ProcNMain(f);
                }
            }
            else
            {
                ProcNMain(file);
            }
        }

        private readonly Dictionary<string, int> procRetCache = new Dictionary<string, int>();

        private bool CheckWithProgram(string checkerCommand)
        {
            bool isNot = checkerCommand.StartsWith("!");
            if (isNot)
            {
                checkerCommand = checkerCommand.Substring(1).Trim();
            }
            var com = checkerCommand.Split(' ')[0];
            var args = checkerCommand.Substring(com.Length);
            var cachekey = $"{com} {args}";
            var procExitCode = int.MinValue;
            if (procRetCache.ContainsKey(cachekey))
            {
                procExitCode = procRetCache[cachekey];
            }
            else
            {
                var proc = new Process();
                proc.StartInfo.FileName = com;
                proc.StartInfo.Arguments = args;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardInput = false;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();

                var s1 = proc.StandardOutput.ReadToEnd();
                if (s1 != "")
                {
                    AddLog(s1);
                }

                s1 = proc.StandardError.ReadToEnd();
                if (s1 != "")
                {
                    AddLog(s1);
                }

                procExitCode = proc.ExitCode;
                procRetCache[cachekey] = procExitCode;
            }
            bool ret = false;
            if (isNot == false)
            {
                ret = procExitCode > 0;
            }
            else
            {
                ret = procExitCode == 0;
            }
            return ret;
        }

        private void ProcNMain(string file)
        {
            var lvis = new Dictionary<int, ListViewItem>();
            foreach (ListViewItem lvi in listViewPatterns.Items)
            {
                lvis[int.Parse(lvi.SubItems[0].Text)] = lvi;
            }
            var nos = new List<int>(lvis.Keys);
            nos.Sort();
            for (int i = 0; i < nos.Count; i++) // Keep priority setting
            {
                var lvi = lvis[nos[i]];
                var name = lvi.SubItems[1].Text;
                var regexPattern = lvi.SubItems[2].Text.Trim();
                var checkerCommand = lvi.SubItems[3].Text.Trim();
                var command = lvi.SubItems[4].Text.Trim();

                if (Regex.IsMatch(file, regexPattern))
                {
                    if (checkerCommand != "")
                    {
                        var com = PeplaceCommandPattern(checkerCommand, file);
                        if (CheckWithProgram(com))
                        {
                            Proc1(file, command);
                        }
                    }
                    else
                    {
                        Proc1(file, command);
                    }
                }
            }
        }
    }
}
