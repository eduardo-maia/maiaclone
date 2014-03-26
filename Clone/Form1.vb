Imports System
Imports System.IO
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions

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
    Private Sub loga(ByVal msg As String)
        Using sw As StreamWriter = File.AppendText("clone.log")
            sw.WriteLine(msg)
        End Using
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
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFullBackup.Click
        Dim files As New StringCollection
        Dim newdir As New StringCollection

        'TODO: kindly check if directories really exist.

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

        Label1.Text = "Searching for files to backup..."

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

        While (newdir.Count > 0)
            ListAll(newdir(0), newdir, files)
            newdir.RemoveAt(0)
        End While
        loga("Found a total of " & files.Count & " files.")

        Label1.Text = "Found a total of " & files.Count & " files. Copying your files..."

        ' SEARCHING FILES TO BE COPIED TO BACK UP DIRECTORY
        loga("Searching files to be copied to the backup directory")
        For Each File As String In files
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
        Label1.Text = "Removing files from backup directory that were removed from source directory..."
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
        TextBoxSourceDirectory.Enabled = True
        TextBoxBackupDirectory.Enabled = True
        ButtonFullBackup.Enabled = True
        ButtonFindSourceDirectory.Enabled = True
        ButtonFindBackupDirectory.Enabled = True

        Label1.Text = "Full backup completed. Watching."

        files.Clear()
        newdir.Clear()
        files_destino.Clear()
        dir_destino.Clear()

        Watch(TextBoxSourceDirectory.Text)
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
        Label1.Text = "Watching."
        Watch(TextBoxSourceDirectory.Text)

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

        Select Case e.ChangeType

            ' archive was created
            Case 1
                If (System.IO.Directory.Exists(e.FullPath)) Then
                    If (Not System.IO.Directory.Exists(destiny)) Then
                        System.IO.Directory.CreateDirectory(destiny) 'TODO: try catch
                    End If
                End If

                If (System.IO.File.Exists(e.FullPath)) Then
                    System.IO.File.Copy(e.FullPath, destiny, True) 'TODO: try catch, sometimes files can't be copied, for an example: disk full, bad blocks, and such
                End If

                ' archive was deleted
            Case 2
                If (System.IO.Directory.Exists(destiny)) Then
                    System.IO.Directory.Delete(destiny) 'TODO: try catch
                End If

                If (System.IO.File.Exists(destiny)) Then
                    System.IO.File.Delete(destiny) 'TODO: try catch
                End If

                ' archive was modified
            Case 4
                If (System.IO.File.Exists(destiny)) Then
                    System.IO.File.Copy(e.FullPath, destiny, True) 'TODO: try catch, sometimes files can't be copied, for an example: disk full, bad blocks, and such
                End If


        End Select




        Console.WriteLine("File: " & e.FullPath & " " & e.ChangeType)
    End Sub


    ' Specify what is done when a file is renamed.
    Private Shared Sub OnRenamed(ByVal source As Object, ByVal e As RenamedEventArgs)
        Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath)

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
            System.IO.Directory.Move(old_name, new_name) 'TODO: try catch
        End If

        If (System.IO.File.Exists(old_name)) Then
            System.IO.File.Move(old_name, new_name) 'TODO: try catch
        End If


    End Sub


    Private Sub ButtonHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHelp.Click
        Process.Start("https://github.com/eduardo-maia/maiaclone/wiki")
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


End Class
