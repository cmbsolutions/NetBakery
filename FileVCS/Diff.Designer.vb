<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Diff
    Inherits DevComponents.DotNetBar.OfficeForm

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
        Me.DiffViewer1 = New DiffPlex.WindowsForms.Controls.DiffViewer()
        Me.SuspendLayout()
        '
        'DiffViewer1
        '
        Me.DiffViewer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DiffViewer1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DiffViewer1.BorderWidth = New System.Windows.Forms.Padding(0)
        Me.DiffViewer1.ChangeTypeForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DiffViewer1.CollapseUnchangedSectionsToggleTitle = "_Collapse unchanged sections"
        Me.DiffViewer1.ContextLinesMenuItemsTitle = "_Lines for context"
        Me.DiffViewer1.DeletedBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.DiffViewer1.DeletedForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DiffViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DiffViewer1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiffViewer1.FontFamilyNames = "Consolas"
        Me.DiffViewer1.FontSize = 11.0R
        Me.DiffViewer1.FontStretch = System.Windows.FontStretch.FromOpenTypeStretch(5)
        Me.DiffViewer1.FontWeight = 400
        Me.DiffViewer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.DiffViewer1.HeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DiffViewer1.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DiffViewer1.HeaderHeight = 28.0R
        Me.DiffViewer1.IgnoreCase = False
        Me.DiffViewer1.IgnoreUnchanged = False
        Me.DiffViewer1.IgnoreWhiteSpace = True
        Me.DiffViewer1.ImaginaryBackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DiffViewer1.InlineModeToggleTitle = "_Unified view"
        Me.DiffViewer1.InsertedBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.DiffViewer1.InsertedForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.DiffViewer1.IsFontItalic = False
        Me.DiffViewer1.IsSideBySide = True
        Me.DiffViewer1.LineNumberForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DiffViewer1.LinesContext = 1
        Me.DiffViewer1.Location = New System.Drawing.Point(0, 0)
        Me.DiffViewer1.Margin = New System.Windows.Forms.Padding(0)
        Me.DiffViewer1.Name = "DiffViewer1"
        Me.DiffViewer1.NewText = Nothing
        Me.DiffViewer1.NewTextHeader = Nothing
        Me.DiffViewer1.OldText = Nothing
        Me.DiffViewer1.OldTextHeader = Nothing
        Me.DiffViewer1.SideBySideModeToggleTitle = "_Split view"
        Me.DiffViewer1.Size = New System.Drawing.Size(1271, 635)
        Me.DiffViewer1.SplitterBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DiffViewer1.SplitterBorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DiffViewer1.SplitterBorderWidth = New System.Windows.Forms.Padding(0)
        Me.DiffViewer1.SplitterWidth = 5.0R
        Me.DiffViewer1.TabIndex = 0
        Me.DiffViewer1.UnchangedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DiffViewer1.UnchangedForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        '
        'Diff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionFont = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(1271, 635)
        Me.Controls.Add(Me.DiffViewer1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Diff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Diff"
        Me.TitleText = "Diff viewer"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DiffViewer1 As DiffPlex.WindowsForms.Controls.DiffViewer
End Class
