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

        If (TextBox2.Text = "") Then
            TextBox2.BackColor = Color.Red
            returnValue = False
        End If
        If (TextBox3.Text = "") Then
            TextBox3.BackColor = Color.Red
            returnValue = False
        End If

        Return returnValue
    End Function


    Private Function GetModifiedDate(ByVal filepath As String) As Date
        Return System.IO.File.GetLastWriteTime(filepath) '.ToString("yyyy-mm-dd HH:mm:ss")
    End Function


    ' LOGAR TEXTO EM ARQUIVO
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
                TextBox2.Text = reader.ReadLine
                TextBox3.Text = reader.ReadLine
            End Using
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Process.Start("http://www.eduardomaia.com/cgi-bin/redirect.pl?redirect=maiaclone")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim files As New StringCollection
        Dim newdir As New StringCollection

        'TODO: kindly check if directories really exist.

        'SAVE TEXTBOXES TO A TEXT FILE
        Dim objWriter As New System.IO.StreamWriter(Directory.GetCurrentDirectory() + "\config.ini")
        objWriter.WriteLine(TextBox2.Text)
        objWriter.WriteLine(TextBox3.Text)
        objWriter.Close()

        files.Clear()
        newdir.Clear()

        If (Not ValidateForm()) Then
            Exit Sub
        End If

        Label1.Text = "Searching for files to backup..."

        'DISABLE ALL FORM ELEMENTS
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        Button1.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False

        loga("---------------------------------------------")
        loga("Backup session start at " & DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss "))
        loga("Getting files and directories from source " & TextBox2.Text & "...")
        newdir.Add(TextBox2.Text)

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
            Dim novo_destino As String = File.Replace(TextBox2.Text, TextBox3.Text)
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
        If (CheckBox1.Checked) Then

            dir_destino.Add(TextBox3.Text)

            While (dir_destino.Count > 0)
                Application.DoEvents()
                ListAll(dir_destino(0), dir_destino, files_destino)
                TempDir = dir_destino(0)
                TempDir = TempDir.Replace(TextBox3.Text, TextBox2.Text)
                If (Not System.IO.Directory.Exists(TempDir)) Then
                    TempDir = TempDir.Replace(TextBox2.Text, TextBox3.Text)
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
                files_destino(i) = files_destino(i).Replace(TextBox3.Text, TextBox2.Text)
                If (Not files.Contains(files_destino(i))) Then
                    files_destino(i) = files_destino(i).Replace(TextBox2.Text, TextBox3.Text)
                    loga("Removed " & files_destino(i))
                    If (System.IO.File.Exists(files_destino(i))) Then
                        System.IO.File.Delete(files_destino(i))
                    End If
                End If
            Next

        End If

        'TODO: CHECANDO SE EXISTE ARQUIVOS NA ORIGEM QUE NÃO ESTÃO NO DESTINO
        'this is just a double check

        'ENABLE ALL FORM ELEMENTS
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        Button1.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True

        Label1.Text = "Done."

        files.Clear()
        newdir.Clear()
        files_destino.Clear()
        dir_destino.Clear()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If FolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If FolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TextBox3.Text = FolderBrowserDialog1.SelectedPath
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
End Class
