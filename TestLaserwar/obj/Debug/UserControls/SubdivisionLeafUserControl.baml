   M S B A M L   `   `   `  ����G  CTestLaserwar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:TestLaserwar.UserControlsTestLaserwar.UserControls  5      :    4TestLaserwar.UserControls.SubdivisionLeafUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:TestLaserwar.UserControls     5      .��5	      � .+�5
   
   ��    ButtonTemplate#��[  6   $��<-��69   $
��Left=�6b   $��	28,24,0,0q�6}   $	��Top=�6�   $��49��6�   $��36��6�   $
��Bold"�6�   $��16(�6�   $��Showcard Gothic)�6�   ��6I   �� *Back+6�   �� 5   
   $
��Left=�64   $��
121,24,0,0q�6O   $	��Top=�6c     J� RenderTransformOrigin$  0.141,0.087&�6{   $��36��6�   $��65��6�   $
��Bold"�6�   $��18(�6�   ��6   �� *SubdivisionName+6�   &   System.Windows.Controls.DataGrid  5   
   $��	0,82,0,84q�6      
IsReadOnly .    AutoGenerateColumns .   �� SelectedItem 68   �� *SelectedEmployee+��6b   �� *EmployeeList+   RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5      �� 5       �� Binding 6&   ��  �� Path$ Position�	 �� Value	 DeptManager6H   .a�5      �� 
 �� Property
 � �� �� Value �	#FF92FF926;   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6f      Width5  /System.Windows.Controls.DataGridLengthConverter$	 205 6t   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $
 Name�   ClipboardContentBinding 6C   Z� 6t     5      $ Position��6j   $	 205 6|    6%   �� $ Position� 6G   Z� 6|     5      $ Phone��6g   $	 203 6v    6%   �� $ Phone� 6D   Z� 6v   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Action��6)      CellTemplate 5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6)   .+�5   "   �� #��[  6)   $��80��6�   ��6Q   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType"  $ DataContext.EditEmployee�.��6�   Edit6�   �� 5   "   #��[  6)   $��80��6�   ��6Q   ��  �� $ FindAncestor=�"  $  DataContext.DeleteEmployee�.��6�   Remove6�   5       5!      5#      5%      �� 5&   
   #��[  6   $	��Add��6Y   $��	28,0,0,26q�6g   $	��110��6z   $��29��6�   $��Bottom=�6�   $
��Left=�6�   ��69   �� *AddEmployee+6�   5'      5(      