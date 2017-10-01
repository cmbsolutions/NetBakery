<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class connection_editor
    Inherits DevComponents.DotNetBar.OfficeForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(connection_editor))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnTryConnection = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnOk = New DevComponents.DotNetBar.ButtonX()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonX()
        Me.txtDescription = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtUser = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtPassword = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.SuperValidator1 = New DevComponents.DotNetBar.Validator.SuperValidator()
        Me.RequiredFieldValidator1 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Required")
        Me.isUniqueValidator = New DevComponents.DotNetBar.Validator.CustomValidator()
        Me.RequiredFieldValidator3 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Required")
        Me.RequiredFieldValidator4 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Required")
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.txtHost = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.RequiredFieldValidator2 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Required")
        Me.sbSsl = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.StyleManagerAmbient1 = New DevComponents.DotNetBar.StyleManagerAmbient(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnTryConnection, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnOk, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDelete, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(24, 160)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(378, 31)
        Me.TableLayoutPanel1.TabIndex = 12
        '
        'btnTryConnection
        '
        Me.btnTryConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnTryConnection.AntiAlias = True
        Me.btnTryConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnTryConnection.Location = New System.Drawing.Point(3, 3)
        Me.btnTryConnection.Name = "btnTryConnection"
        Me.btnTryConnection.Size = New System.Drawing.Size(138, 25)
        Me.btnTryConnection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnTryConnection.Symbol = ""
        Me.btnTryConnection.SymbolColor = System.Drawing.SystemColors.Highlight
        Me.btnTryConnection.TabIndex = 13
        Me.btnTryConnection.Text = "Try connection"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.AntiAlias = True
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(303, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(73, 25)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.Symbol = ""
        Me.btnCancel.SymbolColor = System.Drawing.Color.Red
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOk.AntiAlias = True
        Me.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(225, 3)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(72, 25)
        Me.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnOk.Symbol = ""
        Me.btnOk.SymbolColor = System.Drawing.Color.Lime
        Me.btnOk.TabIndex = 5
        Me.btnOk.Text = "Save"
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDelete.AntiAlias = True
        Me.btnDelete.CausesValidation = False
        Me.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(147, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 25)
        Me.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDelete.Symbol = ""
        Me.btnDelete.SymbolColor = System.Drawing.Color.Red
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = "Delete"
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtDescription.Border.Class = "TextBoxBorder"
        Me.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescription.DisabledBackColor = System.Drawing.Color.Black
        Me.txtDescription.ForeColor = System.Drawing.Color.White
        Me.txtDescription.Location = New System.Drawing.Point(141, 10)
        Me.txtDescription.MaxLength = 255
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.PreventEnterBeep = True
        Me.txtDescription.Size = New System.Drawing.Size(261, 25)
        Me.txtDescription.TabIndex = 0
        Me.SuperValidator1.SetValidator1(Me.txtDescription, Me.RequiredFieldValidator1)
        Me.SuperValidator1.SetValidator2(Me.txtDescription, Me.isUniqueValidator)
        Me.txtDescription.WatermarkText = "Enter a description..."
        '
        'txtUser
        '
        Me.txtUser.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtUser.Border.Class = "TextBoxBorder"
        Me.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUser.DisabledBackColor = System.Drawing.Color.Black
        Me.txtUser.ForeColor = System.Drawing.Color.White
        Me.txtUser.Location = New System.Drawing.Point(141, 66)
        Me.txtUser.MaxLength = 25
        Me.txtUser.Name = "txtUser"
        Me.txtUser.PreventEnterBeep = True
        Me.txtUser.Size = New System.Drawing.Size(261, 25)
        Me.txtUser.TabIndex = 2
        Me.SuperValidator1.SetValidator1(Me.txtUser, Me.RequiredFieldValidator3)
        Me.txtUser.WatermarkText = "Enter a username..."
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(10, 10)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(125, 20)
        Me.LabelX1.TabIndex = 7
        Me.LabelX1.Text = "Description"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtPassword.Border.Class = "TextBoxBorder"
        Me.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPassword.ButtonCustom.Symbol = "59552"
        Me.txtPassword.ButtonCustom.SymbolColor = System.Drawing.SystemColors.Highlight
        Me.txtPassword.ButtonCustom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.txtPassword.ButtonCustom.Tooltip = "Toggle visibility"
        Me.txtPassword.ButtonCustom.Visible = True
        Me.txtPassword.DisabledBackColor = System.Drawing.Color.Black
        Me.txtPassword.ForeColor = System.Drawing.Color.White
        Me.txtPassword.Location = New System.Drawing.Point(141, 94)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.PreventEnterBeep = True
        Me.txtPassword.Size = New System.Drawing.Size(261, 25)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.UseSystemPasswordChar = True
        Me.SuperValidator1.SetValidator1(Me.txtPassword, Me.RequiredFieldValidator4)
        Me.txtPassword.WatermarkText = "Enter a password..."
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(10, 38)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(125, 20)
        Me.LabelX2.TabIndex = 8
        Me.LabelX2.Text = "Host name or ip"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(10, 66)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(125, 20)
        Me.LabelX3.TabIndex = 9
        Me.LabelX3.Text = "Username"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(10, 94)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(125, 20)
        Me.LabelX4.TabIndex = 10
        Me.LabelX4.Text = "Password"
        '
        'SuperValidator1
        '
        Me.SuperValidator1.ContainerControl = Me
        Me.SuperValidator1.ErrorProvider = Me.ErrorProvider1
        Me.SuperValidator1.Highlighter = Me.Highlighter1
        Me.SuperValidator1.ValidationType = DevComponents.DotNetBar.Validator.eValidationType.ValidatingEventOnContainer
        '
        'RequiredFieldValidator1
        '
        Me.RequiredFieldValidator1.ErrorMessage = "Required"
        Me.RequiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'isUniqueValidator
        '
        Me.isUniqueValidator.ErrorMessage = "This name is already in use"
        Me.isUniqueValidator.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator3
        '
        Me.RequiredFieldValidator3.ErrorMessage = "Required"
        Me.RequiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator4
        '
        Me.RequiredFieldValidator4.ErrorMessage = "Required"
        Me.RequiredFieldValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.Icon = CType(resources.GetObject("ErrorProvider1.Icon"), System.Drawing.Icon)
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        '
        'txtHost
        '
        Me.txtHost.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtHost.Border.Class = "TextBoxBorder"
        Me.txtHost.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHost.DisabledBackColor = System.Drawing.Color.Black
        Me.txtHost.ForeColor = System.Drawing.Color.White
        Me.txtHost.Location = New System.Drawing.Point(141, 38)
        Me.txtHost.MaxLength = 255
        Me.txtHost.Name = "txtHost"
        Me.txtHost.PreventEnterBeep = True
        Me.txtHost.Size = New System.Drawing.Size(261, 25)
        Me.txtHost.TabIndex = 1
        Me.SuperValidator1.SetValidator1(Me.txtHost, Me.RequiredFieldValidator1)
        Me.txtHost.WatermarkText = "Enter a hostname or ip..."
        '
        'RequiredFieldValidator2
        '
        Me.RequiredFieldValidator2.ErrorMessage = "Required"
        Me.RequiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'sbSsl
        '
        '
        '
        '
        Me.sbSsl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbSsl.Location = New System.Drawing.Point(141, 122)
        Me.sbSsl.Name = "sbSsl"
        Me.sbSsl.OffBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sbSsl.OffText = "NO"
        Me.sbSsl.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sbSsl.OnText = "YES"
        Me.sbSsl.OnTextColor = System.Drawing.Color.Black
        Me.sbSsl.Size = New System.Drawing.Size(74, 23)
        Me.sbSsl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbSsl.SwitchClickTogglesValue = True
        Me.sbSsl.TabIndex = 4
        Me.sbSsl.ValueFalse = "Prefered"
        Me.sbSsl.ValueObject = "Prefered"
        Me.sbSsl.ValueTrue = "Required"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(10, 123)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(125, 20)
        Me.LabelX5.TabIndex = 11
        Me.LabelX5.Text = "Use SSL?"
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)))
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'connection_editor
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(413, 203)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.sbSsl)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "connection_editor"
        Me.RenderFormIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New connection"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtDescription As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtUser As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtPassword As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperValidator1 As DevComponents.DotNetBar.Validator.SuperValidator
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents RequiredFieldValidator4 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator2 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator3 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents RequiredFieldValidator1 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents sbSsl As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents txtHost As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnTryConnection As DevComponents.DotNetBar.ButtonX
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents StyleManagerAmbient1 As DevComponents.DotNetBar.StyleManagerAmbient
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents isUniqueValidator As DevComponents.DotNetBar.Validator.CustomValidator
    Friend WithEvents Timer1 As Timer
End Class
