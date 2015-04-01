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
        Me.ButtonWatch = New System.Windows.Forms.Button()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MainContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitApp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonFullBackup = New System.Windows.Forms.Button()
        Me.CheckBox = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.LabelStatus = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.MainContextMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
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
        Me.GroupBox3.Location = New System.Drawing.Point(5, 104)
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
        Me.TextBoxBackupDirectory.BackColor = System.Drawing.Color.White
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
        Me.GroupBox2.Location = New System.Drawing.Point(5, 19)
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
        Me.TextBoxSourceDirectory.BackColor = System.Drawing.Color.White
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
        'ButtonWatch
        '
        Me.ButtonWatch.Image = CType(resources.GetObject("ButtonWatch.Image"), System.Drawing.Image)
        Me.ButtonWatch.Location = New System.Drawing.Point(490, 10)
        Me.ButtonWatch.Name = "ButtonWatch"
        Me.ButtonWatch.Size = New System.Drawing.Size(80, 68)
        Me.ButtonWatch.TabIndex = 22
        Me.ButtonWatch.UseVisualStyleBackColor = True
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.MainContextMenu
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "Localbox Easy Backup"
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
        Me.ShowWindow.Size = New System.Drawing.Size(148, 22)
        Me.ShowWindow.Text = "Show window"
        '
        'ExitApp
        '
        Me.ExitApp.Name = "ExitApp"
        Me.ExitApp.Size = New System.Drawing.Size(148, 22)
        Me.ExitApp.Text = "Exit"
        '
        'ButtonFullBackup
        '
        Me.ButtonFullBackup.Image = CType(resources.GetObject("ButtonFullBackup.Image"), System.Drawing.Image)
        Me.ButtonFullBackup.Location = New System.Drawing.Point(492, 12)
        Me.ButtonFullBackup.Name = "ButtonFullBackup"
        Me.ButtonFullBackup.Size = New System.Drawing.Size(80, 65)
        Me.ButtonFullBackup.TabIndex = 16
        Me.ButtonFullBackup.UseVisualStyleBackColor = True
        '
        'CheckBox
        '
        Me.CheckBox.AutoSize = True
        Me.CheckBox.Location = New System.Drawing.Point(13, 54)
        Me.CheckBox.Name = "CheckBox"
        Me.CheckBox.Size = New System.Drawing.Size(338, 17)
        Me.CheckBox.TabIndex = 21
        Me.CheckBox.Text = "Remove files from backup folder that don't exist in source directory"
        Me.CheckBox.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Full Backup"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(306, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "This will copy all files from Source Directory to Backup Directory"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ButtonFullBackup)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CheckBox)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 190)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(578, 83)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.ButtonWatch)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 275)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(578, 83)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(6, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(458, 26)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "This will watch Source Directory for modifications. Once a new file is created, m" & _
            "odified or deleted, this operation will be automatically applied to the Backup D" & _
            "irectory."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Watch"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkRed
        Me.Label10.Location = New System.Drawing.Point(12, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 15)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Localbox Easy Backup"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(587, 24)
        Me.MenuStrip1.TabIndex = 27
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.HelpToolStripMenuItem1.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.LabelStatus)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 359)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(578, 37)
        Me.GroupBox5.TabIndex = 28
        Me.GroupBox5.TabStop = False
        '
        'LabelStatus
        '
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatus.Location = New System.Drawing.Point(9, 15)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(0, 13)
        Me.LabelStatus.TabIndex = 21
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 408)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Localbox Easy Backup"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MainContextMenu.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
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
    Friend WithEvents ButtonWatch As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents MainContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExitApp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonFullBackup As System.Windows.Forms.Button
    Friend WithEvents CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelStatus As System.Windows.Forms.Label

End Class
