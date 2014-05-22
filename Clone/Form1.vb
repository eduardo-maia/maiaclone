Imports System
Imports System.IO
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Form1

    Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs

    Private Function ValidateForm() As Boolean
        Dim returnValue As Boolean
        returnValue = True

        If (TextBoxSourceDirectory.Text = "") Then
            TextBoxSourceDirectory.BackColor = Color.Red
            returnValue = False
        End If
        If (TextBoxBackupDirectory.Text = "") Then
            TextBoxBackupDirectory.BackColor = Color.Red
            returnValue = False
        End If

        Return returnValue
    End Function


    Private Function GetModifiedDate(ByVal filepath As String) As Date
        Return System.IO.File.GetLastWriteTime(filepath) '.ToString("yyyy-mm-dd HH:mm:ss")

    End Function


    ' LOG TO A TEXT FILE
    Public Shared Sub loga(ByVal msg As String)
        Try
            Using sw As StreamWriter = File.AppendText("clone.log")
                sw.WriteLine(msg)
            End Using
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetFileSize(ByVal filepath As String)
        If (Not System.IO.File.Exists(filepath)) Then
            Return 0
        Else
            Dim a As IO.FileInfo = New IO.FileInfo(filepath)
            Return a.Length
        End If
    End Function

    Private Sub ListAll(ByVal Directory As String, ByVal newdir As StringCollection, ByVal files As StringCollection)
        Try

            ' LIST FILES
            Dim di As New IO.DirectoryInfo(Directory)
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo
            For Each dra In diar1
                files.Add(Directory & "\" & dra.ToString())
                Application.DoEvents()
            Next

            ' LIST DIRECTORIES
            Dim di2 = New IO.DirectoryInfo(Directory)
            Dim diar2 As IO.DirectoryInfo() = di2.GetDirectories()
            Dim dra2 As IO.DirectoryInfo
            For Each dra2 In diar2
                newdir.Add(Directory & "\" & dra2.ToString)
                Application.DoEvents()
            Next
        Catch ex As Exception
            loga(ex.Message)
        End Try


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim config_ini_path As String
        config_ini_path = IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\config.ini"
        config_ini_path = config_ini_path.Replace("file:\", "")

        If (System.IO.File.Exists(config_ini_path)) Then
            Using reader As StreamReader = New StreamReader(config_ini_path)
                TextBoxSourceDirectory.Text = reader.ReadLine
                TextBoxBackupDirectory.Text = reader.ReadLine
            End Using
        End If

        NotifyIcon.Visible = False

        LabelStatus.Text = "Not watching. Not running a full back up."
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFullBackup.Click
        Dim files As New StringCollection
        Dim newdir As New StringCollection

        'CONFIRM if user really wants to proceed with a full back up
        If MsgBox("Really proceed with a full back up?", MsgBoxStyle.YesNo, My.Application.Info.ProductName) = MsgBoxResult.No Then
            Exit Sub
        End If

        'TODO: kindly check if directories really exist.

        ButtonWatch.Enabled = False
        ButtonFullBackup.Enabled = False

        'SAVE TEXTBOXES TO A TEXT FILE
        Dim objWriter As New System.IO.StreamWriter(Directory.GetCurrentDirectory() + "\config.ini")
        objWriter.WriteLine(TextBoxSourceDirectory.Text)
        objWriter.WriteLine(TextBoxBackupDirectory.Text)
        objWriter.Close()

        files.Clear()
        newdir.Clear()

        If (Not ValidateForm()) Then
            Exit Sub
        End If

        LabelStatus.Text = "Searching for files to backup..."

        'DISABLE ALL FORM ELEMENTS
        TextBoxSourceDirectory.Enabled = False
        TextBoxBackupDirectory.Enabled = False
        ButtonFullBackup.Enabled = False
        ButtonFindSourceDirectory.Enabled = False
        ButtonFindBackupDirectory.Enabled = False

        loga("---------------------------------------------")
        loga("Backup session start at " & DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss "))
        loga("Getting files and directories from source " & TextBoxSourceDirectory.Text & "...")
        newdir.Add(TextBoxSourceDirectory.Text)

        'TODO: open new thread for this, to stop freezing the main thread while copying files
        While (newdir.Count > 0)
            ListAll(newdir(0), newdir, files)
            newdir.RemoveAt(0)
            Application.DoEvents()
        End While
        loga("Found a total of " & files.Count & " files.")

        LabelStatus.Text = "Found a total of " & files.Count & " files. Checking paths sizes..."


        'CHECKING IF ANY PATH LENGTH > 256. IF sO, ASK TO SHRINK IT
        'TODO: use better class than System.IO, without this limitation
        Dim found260 As Boolean = False
        For Each File As String In files
            If (File.Length() >= 260) Then
                If (found260 = False) Then
                    found260 = True
                    loga("One or more paths contain more than 260 characters. Please, shrink these paths:")
                End If
                loga(File)
            End If
        Next
        If (found260) Then
            MsgBox("Found some paths longer than 260 characters. Process stopped. Please check clone.log for more information.")
            LabelStatus.Text = "Please check clone.log"
            EnableAll()
            Exit Sub
        End If


        ' SEARCHING FILES TO BE COPIED TO BACK UP DIRECTORY
        'TODO: open new thread for copying files, to stop freezing the main thread while copying files
        loga("Searching files to be copied to the backup directory")
        Dim processed_files As Integer = 0
        For Each File As String In files
            processed_files = processed_files + 1
            'TODO: inform also time remaining instead of just number of files
            LabelStatus.Text = "Processing file " & processed_files & " of " & files.Count & "..."
            Application.DoEvents()
            Dim novo_destino As String = File.Replace(TextBoxSourceDirectory.Text, TextBoxBackupDirectory.Text)
            If (System.IO.File.Exists(novo_destino) And GetModifiedDate(File) > GetModifiedDate(novo_destino) And GetFileSize(File) > GetFileSize(novo_destino)) Then
                loga("IMPORTANT WARNING, POSSIBLE DISK ERROR: " & File & " AND " & novo_destino & " HAVE THE SAME MODIFIED DATE, BUT SIZES OF THESE FILES ARE DIFFERENT.")
            End If
            If (Not (System.IO.File.Exists(novo_destino)) Or GetModifiedDate(File) > GetModifiedDate(novo_destino) Or GetFileSize(File) > GetFileSize(novo_destino)) Then
                loga(File & " => " & novo_destino)
                ' BEGIN CHECK MKDIR
                Dim dirs As String() = novo_destino.Split(New Char() {"\"c})
                Dim full_mkdir_path As String = ""
                Dim i As Integer
                For i = 0 To dirs.Length - 2
                    full_mkdir_path = full_mkdir_path & dirs(i)
                    If (Not System.IO.Directory.Exists(full_mkdir_path)) Then
                        System.IO.Directory.CreateDirectory(full_mkdir_path)
                    End If
                    full_mkdir_path = full_mkdir_path & "\"
                    Application.DoEvents()
                Next
                ' END MKDIR CHECK

                'TODO: try catch, sometimes files can't be copied, for an example: disk full, bad blocks, and such
                System.IO.File.Copy(File, novo_destino, True)
            End If
        Next


        Dim files_destino As New StringCollection
        Dim dir_destino As New StringCollection
        Dim TempDir As String

        'TODO: files must be deleted first to avoid issues when the empty space is minimum
        'REMOVENDO EM DESTINO OS ARQUIVOS QUE FORAM REMOVIDOS DA ORIGEM
        LabelStatus.Text = "Removing files from backup directory that were removed from source directory..."
        If (CheckBox.Checked) Then

            dir_destino.Add(TextBoxBackupDirectory.Text)

            While (dir_destino.Count > 0)
                Application.DoEvents()
                ListAll(dir_destino(0), dir_destino, files_destino)
                TempDir = dir_destino(0)
                TempDir = TempDir.Replace(TextBoxBackupDirectory.Text, TextBoxSourceDirectory.Text)
                If (Not System.IO.Directory.Exists(TempDir)) Then
                    TempDir = TempDir.Replace(TextBoxSourceDirectory.Text, TextBoxBackupDirectory.Text)
                    If (System.IO.Directory.Exists(TempDir)) Then
                        Try
                            System.IO.Directory.Delete(TempDir, "true")
                        Catch ex As Exception
                            loga(ex.Message)
                        End Try
                    End If
                End If

                dir_destino.RemoveAt(0)
            End While
            For i = 0 To files_destino.Count - 1
                Application.DoEvents()
                files_destino(i) = files_destino(i).Replace(TextBoxBackupDirectory.Text, TextBoxSourceDirectory.Text)
                If (Not files.Contains(files_destino(i))) Then
                    files_destino(i) = files_destino(i).Replace(TextBoxSourceDirectory.Text, TextBoxBackupDirectory.Text)
                    loga("Removed " & files_destino(i))
                    If (System.IO.File.Exists(files_destino(i))) Then
                        System.IO.File.Delete(files_destino(i))
                    End If
                End If
            Next

        End If

        'TODO: check if there are files on the source directory that don't exist on the destination
        'this is just a double check

        'ENABLE ALL FORM ELEMENTS
        EnableAll()

        LabelStatus.Text = "Full backup completed. Watching."

        files.Clear()
        newdir.Clear()
        files_destino.Clear()
        dir_destino.Clear()

        Watch(TextBoxSourceDirectory.Text)
    End Sub

    Private Sub EnableAll()
        'ENABLE ALL FORM ELEMENTS
        TextBoxSourceDirectory.Enabled = True
        TextBoxBackupDirectory.Enabled = True
        ButtonFullBackup.Enabled = True
        ButtonFindSourceDirectory.Enabled = True
        ButtonFindBackupDirectory.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindSourceDirectory.Click
        If FolderBrowserDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TextBoxSourceDirectory.Text = FolderBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindBackupDirectory.Click
        If FolderBrowserDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TextBoxBackupDirectory.Text = FolderBrowserDialog.SelectedPath
        End If

    End Sub

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        For i As Integer = 0 To CommandLineArgs.Count - 1
            If (CommandLineArgs(i) = "/go") Then
                Application.DoEvents()
                Button1_Click(Nothing, Nothing)
            End If
        Next

    End Sub


    Private Sub buttonWatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWatch.Click
        'SAVE TEXTBOXES TO A TEXT FILE
        Dim objWriter As New System.IO.StreamWriter(Directory.GetCurrentDirectory() + "\config.ini")
        objWriter.WriteLine(TextBoxSourceDirectory.Text)
        objWriter.WriteLine(TextBoxBackupDirectory.Text)
        objWriter.Close()

        LabelStatus.Text = "Watching."
        Watch(TextBoxSourceDirectory.Text)
        ButtonWatch.Enabled = False
        ButtonFullBackup.Enabled = False
    End Sub


    Private Shared Sub Watch(ByVal dirPath As String)

        ' Create a new FileSystemWatcher and set its properties. 
        Dim watcher As New FileSystemWatcher()
        watcher.Path = dirPath
        ' Watch for changes in LastAccess and LastWrite times, and 
        ' the renaming of files or directories. 
        watcher.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName)
        ' Watch all files.
        watcher.Filter = "*"
        watcher.IncludeSubdirectories = True


        ' Add event handlers. 
        AddHandler watcher.Changed, AddressOf OnChanged
        AddHandler watcher.Created, AddressOf OnChanged
        AddHandler watcher.Deleted, AddressOf OnChanged
        AddHandler watcher.Renamed, AddressOf OnRenamed

        ' Begin watching.
        watcher.EnableRaisingEvents = True

        Console.WriteLine("Watching " + dirPath)
    End Sub


    ' Specify what is done when a file is changed, created, or deleted
    Private Shared Sub OnChanged(ByVal source As Object, ByVal e As FileSystemEventArgs)
        ' e.ChangeType is a magic number, where
        ' 1 = new archive or folder was created
        ' 2 = archive was deleted
        ' 4 = directory or file was changed

        'TODO: stop copy and paste
        Static from_local As String = ""
        Static to_local As String = ""

        If (from_local = "" Or to_local = "") Then
            Dim config_ini_path As String
            config_ini_path = IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\config.ini"
            config_ini_path = config_ini_path.Replace("file:\", "")

            If (System.IO.File.Exists(config_ini_path)) Then
                Using reader As StreamReader = New StreamReader(config_ini_path)
                    from_local = reader.ReadLine
                    to_local = reader.ReadLine
                End Using
            Else
                MsgBox("Cannot find config.ini file")
                Application.Exit()
            End If
        End If

        Dim destiny As String
        destiny = e.FullPath
        destiny = destiny.Replace(from_local, to_local)

        If (e.FullPath.Length() >= 260) Then
            MsgBox(e.FullPath & "\n\n" & "This location has more than 260 characters. Can't continue.")
            Exit Sub
        End If

        If (destiny.Length() >= 260) Then
            MsgBox(destiny & "\n\n" & "This location has more than 260 characters. Can't continue.")
            Exit Sub
        End If

        Select Case e.ChangeType

            Case 1
                ' directory was created
retrycopydir:
                If (System.IO.Directory.Exists(e.FullPath)) Then
                    If (Not System.IO.Directory.Exists(destiny)) Then
                        Try
                            System.IO.Directory.CreateDirectory(destiny)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If

                    'copy all files from the new created directory to the back up directory
                    Try
                        My.Computer.FileSystem.CopyDirectory(e.FullPath, destiny, True)
                    Catch ex As Exception
                        Thread.Sleep(1000)
                        GoTo retrycopydir
                    End Try

                End If

                ' archive was created
                If (System.IO.File.Exists(e.FullPath)) Then
                    Dim trd = New Thread(Sub() CopyFile(e.FullPath, destiny))
                    trd.IsBackground = True
                    trd.Start()
                End If

                ' archive was deleted
            Case 2
retrydeldir:
                If (System.IO.Directory.Exists(destiny)) Then
                    Try
                        System.IO.Directory.Delete(destiny, True)
                    Catch ex As Exception
                        Thread.Sleep(1000)
                        GoTo retrydeldir
                    End Try
                End If
retrydelfile:
                If (System.IO.File.Exists(destiny)) Then
                    Try
                        System.IO.File.Delete(destiny)
                    Catch ex As Exception
                        Thread.Sleep(1000)
                        GoTo retrydelfile
                    End Try
                End If

                ' archive was modified
            Case 4
retrycopyfile:
                Try
                    If (System.IO.File.Exists(destiny)) Then
                        Dim trd = New Thread(Sub() CopyFile(e.FullPath, destiny))
                        trd.IsBackground = True
                        trd.Start()
                    End If
                Catch ex As Exception
                    Thread.Sleep(1000)
                    GoTo retrycopyfile
                End Try

        End Select




        Console.WriteLine("File: " & e.FullPath & " " & e.ChangeType)
    End Sub


    Private Shared Sub CopyFile(ByVal from_location As String, ByVal to_location As String)
        Try
            System.IO.File.Copy(from_location, to_location, True)
        Catch ex As Exception
            loga(ex.Message)
            'if file is being written by another application, after this file is written, Sub OnChanged will be called again, so we don't need to sleep and start the CopyFile again
        End Try
    End Sub




    ' Specify what is done when a file is renamed.
    Private Shared Sub OnRenamed(ByVal source As Object, ByVal e As RenamedEventArgs)
        Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath)

        If (e.FullPath.Length() >= 256) Then
            MsgBox(e.FullPath & "\n\n" & "This location has more than 256 characters. Can't proceed")
            Exit Sub
        End If

        If (e.OldFullPath.Length() >= 256) Then
            MsgBox(e.OldFullPath & "\n\n" & "This location has more than 256 characters. Can't proceed")
            Exit Sub
        End If



        'TODO: stop copy and paste
        Static from_local As String = ""
        Static to_local As String = ""

        If (from_local = "" Or to_local = "") Then
            Dim config_ini_path As String
            config_ini_path = IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\config.ini"
            config_ini_path = config_ini_path.Replace("file:\", "")

            If (System.IO.File.Exists(config_ini_path)) Then
                Using reader As StreamReader = New StreamReader(config_ini_path)
                    from_local = reader.ReadLine
                    to_local = reader.ReadLine
                End Using
            Else
                MsgBox("Cannot find config.ini file")
                Application.Exit()
            End If
        End If

        Dim old_name As String
        old_name = e.OldFullPath
        old_name = old_name.Replace(from_local, to_local)

        Dim new_name As String
        new_name = e.FullPath
        new_name = new_name.Replace(from_local, to_local)

        If (System.IO.Directory.Exists(e.FullPath)) Then
            Try
                System.IO.Directory.Move(old_name, new_name)
            Catch ex As Exception
                loga("ERROR: can't rename directory >> " & ex.Message)
                MsgBox(ex.Message)
            End Try
        End If

        If (System.IO.File.Exists(old_name)) Then
            Try
                System.IO.File.Move(old_name, new_name)
            Catch ex As Exception
                loga("ERROR: can't rename file >> " & ex.Message)
                MsgBox(ex.Message)
            End Try
        End If


    End Sub




    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If (Me.Visible) Then
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
            e.Cancel = True
            NotifyIcon.Visible = True
        Else
            e.Cancel = False
        End If


    End Sub



    Private Sub ShowWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon.MouseDoubleClick
        ShowApp()
    End Sub

    Private Sub CloseApp() Handles ExitApp.MouseDown
        Application.Exit()
    End Sub

    Private Sub ShowApp() Handles ShowWindow.MouseDown
        NotifyIcon.Visible = False
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub


    Private Sub HelpToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem1.Click
        Process.Start("https://github.com/eduardo-maia/maiaclone/wiki")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Localbox Easy Backup" & Chr(10) & "Version: 0.01" & Chr(10) & "Build date: " & "2014-05-01")
    End Sub
End Class
