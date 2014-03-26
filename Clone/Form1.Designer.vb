<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ButtonFindBackupDirectory = New System.Windows.Forms.Button()
        Me.TextBoxBackupDirectory = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButtonFindSourceDirectory = New System.Windows.Forms.Button()
        Me.TextBoxSourceDirectory = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonFullBackup = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox = New System.Windows.Forms.CheckBox()
        Me.ButtonWatch = New System.Windows.Forms.Button()
        Me.ButtonHelp = New System.Windows.Forms.Button()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MainContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitApp = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.MainContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.Filter = "Text files (*.txt)|*.txt|All files|*"
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.AutoScroll = True
        Me.ContentPanel.Size = New System.Drawing.Size(605, 234)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ButtonFindBackupDirectory)
        Me.GroupBox3.Controls.Add(Me.TextBoxBackupDirectory)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(2, 94)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(578, 85)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        '
        'ButtonFindBackupDirectory
        '
        Me.ButtonFindBackupDirectory.Image = CType(resources.GetObject("ButtonFindBackupDirectory.Image"), System.Drawing.Image)
        Me.ButtonFindBackupDirectory.Location = New System.Drawing.Point(492, 16)
        Me.ButtonFindBackupDirectory.Name = "ButtonFindBackupDirectory"
        Me.ButtonFindBackupDirectory.Size = New System.Drawing.Size(75, 58)
        Me.ButtonFindBackupDirectory.TabIndex = 11
        Me.ButtonFindBackupDirectory.UseVisualStyleBackColor = True
        '
        'TextBoxBackupDirectory
        '
        Me.TextBoxBackupDirectory.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxBackupDirectory.Location = New System.Drawing.Point(9, 54)
        Me.TextBoxBackupDirectory.Name = "TextBoxBackupDirectory"
        Me.TextBoxBackupDirectory.Size = New System.Drawing.Size(468, 20)
        Me.TextBoxBackupDirectory.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(287, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "The directory or hard drive where your back up will be done"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Backup Directory"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonFindSourceDirectory)
        Me.GroupBox2.Controls.Add(Me.TextBoxSourceDirectory)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(578, 85)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        '
        'ButtonFindSourceDirectory
        '
        Me.ButtonFindSourceDirectory.Image = CType(resources.GetObject("ButtonFindSourceDirectory.Image"), System.Drawing.Image)
        Me.ButtonFindSourceDirectory.Location = New System.Drawing.Point(492, 16)
        Me.ButtonFindSourceDirectory.Name = "ButtonFindSourceDirectory"
        Me.ButtonFindSourceDirectory.Size = New System.Drawing.Size(75, 58)
        Me.ButtonFindSourceDirectory.TabIndex = 11
        Me.ButtonFindSourceDirectory.UseVisualStyleBackColor = True
        '
        'TextBoxSourceDirectory
        '
        Me.TextBoxSourceDirectory.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxSourceDirectory.Location = New System.Drawing.Point(9, 54)
        Me.TextBoxSourceDirectory.Name = "TextBoxSourceDirectory"
        Me.TextBoxSourceDirectory.Size = New System.Drawing.Size(468, 20)
        Me.TextBoxSourceDirectory.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(261, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Where are located your files that you need to back up"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Source Directory"
        '
        'ButtonFullBackup
        '
        Me.ButtonFullBackup.Location = New System.Drawing.Point(360, 193)
        Me.ButtonFullBackup.Name = "ButtonFullBackup"
        Me.ButtonFullBackup.Size = New System.Drawing.Size(83, 23)
        Me.ButtonFullBackup.TabIndex = 16
        Me.ButtonFullBackup.Text = "Full Backup"
        Me.ButtonFullBackup.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 20
        '
        'CheckBox
        '
        Me.CheckBox.AutoSize = True
        Me.CheckBox.Location = New System.Drawing.Point(8, 199)
        Me.CheckBox.Name = "CheckBox"
        Me.CheckBox.Size = New System.Drawing.Size(338, 17)
        Me.CheckBox.TabIndex = 21
        Me.CheckBox.Text = "Remove files from backup folder that don't exist in source directory"
        Me.CheckBox.UseVisualStyleBackColor = True
        '
        'ButtonWatch
        '
        Me.ButtonWatch.Location = New System.Drawing.Point(449, 193)
        Me.ButtonWatch.Name = "ButtonWatch"
        Me.ButtonWatch.Size = New System.Drawing.Size(59, 23)
        Me.ButtonWatch.TabIndex = 22
        Me.ButtonWatch.Text = "Watch"
        Me.ButtonWatch.UseVisualStyleBackColor = True
        '
        'ButtonHelp
        '
        Me.ButtonHelp.Location = New System.Drawing.Point(514, 193)
        Me.ButtonHelp.Name = "ButtonHelp"
        Me.ButtonHelp.Size = New System.Drawing.Size(66, 23)
        Me.ButtonHelp.TabIndex = 23
        Me.ButtonHelp.Text = "Help"
        Me.ButtonHelp.UseVisualStyleBackColor = True
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.MainContextMenu
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "Maia Cloneme 1.0"
        '
        'MainContextMenu
        '
        Me.MainContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowWindow, Me.ExitApp})
        Me.MainContextMenu.Name = "MainContextMenu"
        Me.MainContextMenu.Size = New System.Drawing.Size(149, 48)
        '
        'ShowWindow
        '
        Me.ShowWindow.Name = "ShowWindow"
        Me.ShowWindow.Size = New System.Drawing.Size(152, 22)
        Me.ShowWindow.Text = "Show window"
        '
        'ExitApp
        '
        Me.ExitApp.Name = "ExitApp"
        Me.ExitApp.Size = New System.Drawing.Size(152, 22)
        Me.ExitApp.Text = "Exit"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 252)
        Me.Controls.Add(Me.ButtonHelp)
        Me.Controls.Add(Me.ButtonWatch)
        Me.Controls.Add(Me.CheckBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ButtonFullBackup)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Maia Cloneme 1.0"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MainContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonFindBackupDirectory As System.Windows.Forms.Button
    Friend WithEvents TextBoxBackupDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonFindSourceDirectory As System.Windows.Forms.Button
    Friend WithEvents TextBoxSourceDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonFullBackup As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonWatch As System.Windows.Forms.Button
    Friend WithEvents ButtonHelp As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents MainContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExitApp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowWindow As System.Windows.Forms.ToolStripMenuItem

End Class
